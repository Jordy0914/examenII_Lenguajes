using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;// permite realizar validaciones a nuestra clase a nivel del models
using System.Globalization;//biblioteca de configuracion del uso de varios idiomas

namespace examenII_Lenguajes.Models
{
    public class Logeo
    {
        [Required]
        [EmailAddress]//valida un correo electronico automaticamente
        [StringLength(100)]//longuitud del campo
        [Display(Name = "Correo Electronico")]
        public string email { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [Display(Name = "Recordar mi cuenta")]
        public bool RememberMe { get; set; }

    }//fin de la clase logeo usuario


    public class RegistrarUsuario
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

    }//fin de la clase registrar usuario
}
