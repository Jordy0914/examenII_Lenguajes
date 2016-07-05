//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;// permite realizar validaciones a nuestra clase a nivel del models
using System.Globalization;//biblioteca de configuracion del uso de varios idiomas


namespace examenII_Lenguajes
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbUsuario
    {
        public int idUsuario { get; set; }



        [Required]
        [EmailAddress]//valida un correo electronico automaticamente
        [StringLength(100)]//longuitud del campo
        [Display(Name = "Correo Electronico")]
        public string email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Completo")]//es lo que sale en la pagina web como un label
        public string nombre { get; set; }


        [Required]
        [StringLength(500)]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }


        [Required]
        [StringLength(15)]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = "Recordar mi cuenta")]
        public bool RememberMe { get; set; }
    }
}
