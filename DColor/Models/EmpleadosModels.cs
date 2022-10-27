using DColor.DB;
using DColor.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast.Selectors;

namespace DColor.Models
{
    public class EmpleadosModels
    {
        public Empleado ValidarCredenciales(Empleado obj)
        {
            Empleado empleados = new Empleado();
            List<PermisosObj> listaPermisos = new List<PermisosObj>();
            using (var contex = new DColorEntities())
            {
                try
                {
                    //validar el correo
                    var correo = ValidarCorreo(obj.correo);
                    if (correo)
                    {
                        var respuesta = (from x in contex.Empleadoes where x.correo == obj.correo && x.contraseña == obj.contraseña select x).FirstOrDefault();
                        if (respuesta != null)
                        {
                            //ResetIntentos(obj.correo);
                            var permisos = (from x in contex.Rols
                                            where x.idRol == respuesta.idRol
                                            select x).ToList();
                            empleados.nombre = respuesta.nombre;
                            empleados.apellido = respuesta.apellido;
                            empleados.correo = respuesta.correo;
                            empleados.cedula = respuesta.cedula;
                            empleados.idRol = (int)respuesta.idRol;
                            empleados.intentos = (int)respuesta.intentos;
                            foreach (var item in permisos)
                            {
                                listaPermisos.Add(new PermisosObj
                                {
                                    id = item.idRol
                                });
                            }
                            
                            empleados.listaPermisos = listaPermisos;
                            return empleados;
                        }
                        else
                        {
                            // sumar intentos
                            //SumarIntentos(obj.correo);
                            empleados.correo = "Contraseña erronea";
                            return empleados;
                        }
                    }
                    else
                    {   empleados.correo = "El correo digitado no existe";
                        return empleados;
                    }

                }
                catch(Exception ex)
                {
                    var error = ex.ToString();
                    // modeloBitacora.RegistrarError(error);
                    contex.Dispose();
                    throw ex;
                }
            }


        }

        //reset intetnos
        public void ResetIntentos(string correo)
        {
            string cadena = "Data Source=77P7063;Initial Catalog=DColor;Integrated Security=true";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Empleado SET intentos = @intentos WHERE correo = @correo", cn);
                cmd.Parameters.AddWithValue("@intentos", 0);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.ExecuteNonQuery();
            }   
        }

        // sumar intentos
        public void SumarIntentos(string correo)
        {
            int intentos = 0;
            using (var context = new DColorEntities())
            {
                try
                {
                    var select = (from x in context.Empleadoes where x.correo == correo select x).FirstOrDefault();
                    if(select.intentos > 0)
                    {
                        intentos = 1;
                    }
                    else
                    {
                        intentos = (int)(select.intentos + 1);
                    }
                    string cadena = "Data Source=77P7063;Initial Catalog=DColor;Integrated Security=true";
                    using (SqlConnection cn = new SqlConnection(cadena))
                    {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Empleado SET intentos = @intentos WHERE correo = @correo", cn);
                        cmd.Parameters.AddWithValue("@intentos", intentos);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.ExecuteNonQuery();
                    }
                } catch(Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                }
            }
        }

        //validar correo
        public bool ValidarCorreo(string correo)
        {
            bool correoStatus = false;
            using(var contex = new DColorEntities())
            {
                try
                {
                    var existe = (from x in contex.Empleadoes where x.correo == correo select x).FirstOrDefault();
                    if(existe != null)
                    {
                        correoStatus = true;
                    }
                    else
                    {
                        correoStatus = false;
                    }
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    correoStatus = false;
                }
            }
            return correoStatus;

        }
    }
}