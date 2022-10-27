let form = document.querySelector("#form"); //almacena el formulario
let boton = document.querySelector("#boton");//y el boton 
let formA = document.querySelector("#formA"); //almacena el formulario
let botonActua = document.querySelector("#botonActua");//y el botonActua 

function Habilitar() {

    let desabilitar = false;

    if (form.idRol.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.nombre.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.apellidos.value == "") {
        desabilitar = true;

    }
    if (form.correo.value == "") {
        desabilitar = true;

    }
    if (form.cedula.value == "") {
        desabilitar = true;

    }
    if (form.contraseña.value == "") {
        desabilitar = true;

    }

    if (form.telefono.value == "") {
        desabilitar = true;

    }

    if (form.idEstado.value == "") {
        desabilitar = true;

    }
    if (desabilitar == true) {
        boton.disabled = true;
       

    }
    else {
        boton.disabled = false;
       

    }

}

form.addEventListener("keyup", Habilitar) //evento para verificar que el empleado esta escribiendo




function HabilitarActua() {

    let desabilitar = false;

    if (formA.idRol.value == "") {
        desabilitar = true;

    }
    if (formA.nombre.value == "") {
        desabilitar = true;

    }
    if (formA.apellidos.value == "") {
        desabilitar = true;

    }
    if (formA.correo.value == "") {
        desabilitar = true;

    }
    if (formA.idEstado.value == "") {
        desabilitar = true;

    }

    if (formA.telefono.value == "") {
        desabilitar = true;

    }

    if (formA.cedula.value == "") {
        desabilitar = true;

    }

    if (desabilitar == true) {

        botonActua.disabled = true;

    }
    else {

        botonActua.disabled = false;

    }
    formA.addEventListener("keyup", HabilitarActua) //evento para verificar que el empleado esta escribiendo


}

function HabilitarC() {

    let desabilitar = false;

    if (form.idEstado.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.nombre.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.apellidos.value == "") {
        desabilitar = true;

    }
    if (form.correo.value == "") {
        desabilitar = true;

    }
    if (form.cedula.value == "") {
        desabilitar = true;

    }
    if (form.direccion.value == "") {
        desabilitar = true;

    }

    if (form.telefono.value == "") {
        desabilitar = true;

    }

    if (desabilitar == true) {
        boton.disabled = true;
       

    }
    else {
        boton.disabled = false;
       

    }

}

form.addEventListener("keyup", HabilitarC) //evento para verificar que el cliente esta escribiendo



function HabilitarActuaC() {

    let desabilitar = false;

    if (formA.idEstado.value == "") {
        desabilitar = true;

    }
    if (formA.nombre.value == "") {
        desabilitar = true;

    }
    if (formA.apellidos.value == "") {
        desabilitar = true;

    }
    if (formA.correo.value == "") {
        desabilitar = true;

    }
    if (formA.cedula.value == "") {
        desabilitar = true;

    }

    if (formA.direccion.value == "") {
        desabilitar = true;

    }

    if (formA.telefono.value == "") {
        desabilitar = true;

    }

    if (desabilitar == true) {

        botonActua.disabled = true;

    }
    else {

        botonActua.disabled = false;

    }
    formA.addEventListener("keyup", HabilitarActuaC) //evento para verificar que el cliente esta escribiendo


}

function HabilitarP() {

    let desabilitar = false;

    if (form.nombre.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.correo.value == "") {
        desabilitar = true;

    }
    if (form.direccion.value == "") {
        desabilitar = true;

    }

    if (form.telefono.value == "") {
        desabilitar = true;

    }

    if (desabilitar == true) {
        boton.disabled = true;


    }
    else {
        boton.disabled = false;


    }

}

form.addEventListener("keyup", HabilitarP) //evento para verificar que el proveedor esta escribiendo



function HabilitarActuaP() {

    let desabilitar = false;

    if (formA.nombre.value == "") {
        desabilitar = true;

    }
    if (formA.correo.value == "") {
        desabilitar = true;

    }
    if (formA.direccion.value == "") {
        desabilitar = true;

    }

    if (formA.telefono.value == "") {
        desabilitar = true;

    }

    if (desabilitar == true) {

        botonActua.disabled = true;

    }
    else {

        botonActua.disabled = false;

    }
    formA.addEventListener("keyup", HabilitarActuaP) //evento para verificar que el cliente esta escribiendo


}





