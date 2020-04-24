using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entidades
{
    public class Empleado
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public DateTime nacimiento { get; set; }
    }
}
