using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DColor.Entities
{
    public class RecuperarPassword
    {
        public string token { get; set; }
        [Required]
        public string contraseña { get; set; }

        [Compare("Contraseña")]
        [Required]
        public string contraseña2 { get; set; }


        [EmailAddress]
        [Required]
        public string correo { get; set; }
    }
}