using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;// permite realizar validaciones a nuestra clase a nivel del models
using System.Globalization;//biblioteca de configuracion del uso de varios idiomas

namespace examenII_Lenguajes.Models
{
    

        public class RegistrarUsuario
        {
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

        }//fin de la clase registrar usuario

        public class LogeoUsuario
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


    }

