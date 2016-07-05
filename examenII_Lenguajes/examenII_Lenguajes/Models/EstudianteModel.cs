using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//Biblioteca que permite validar el modelo
using System.Globalization;
//Biblioteca de configuracion del uso de varios idiomas

namespace examenII_Lenguajes.Models
{
    public class EstudianteModel
    {
       
            [Required]//valida la entrada de datos al campo
            [Display(Name = "Código Estudiante:")]
            public int idEstudiante { get; set; }

            [Required]//valida la entrada de datos al campo
            [StringLength(11)] //longitud maxima del campo
            [Display(Name = "Carnet:")]
            public string carnet { get; set; }

            [Required] //entra en validacion el campo
                       //le indico que es un string de 100, y ademas no le permito caracteres extraños
            [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Caracteres inválidos.")]
            [StringLength(100)]
            [Display(Name = "Nombre completo:")]
            public string nombre { get; set; }

            [Required] //entra en validacion el campo
                       //le indico que es un string de 50, y ademas no le permito caracteres extraños
            [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Caracteres inválidos.")]
            [StringLength(50)]
            [Display(Name = "Apellido I:")]
            public string apellido1 { get; set; }

            [Required] //entra en validacion el campo
                       //le indico que es un string de 50, y ademas no le permito caracteres extraños
            [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Caracteres inválidos.")]
            [StringLength(50)]
            [Display(Name = "Apellido II:")]
            public string apellido2 { get; set; }
        
    }
}
