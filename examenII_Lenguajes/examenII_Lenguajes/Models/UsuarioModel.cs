using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace examenII_Lenguajes.Models
{
    public class UsuarioModel
    {
        public int idCurso { get; set; }
        public string nombre { get; set; }
        public int creditos { get; set; }
        public string descripcion { get; set; }

    }


    public class EstudianteDBContext : DbContext
    {
        public DbSet<UsuarioModel> UsuarioModel { get; set; }
    }
}
