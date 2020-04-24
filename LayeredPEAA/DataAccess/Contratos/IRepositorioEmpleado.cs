using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entidades;

namespace DataAccess.Contratos
{
    public interface IRepositorioEmpleado : IRepositorioGenerico<Empleado>
    {
        //Metodos adicionales
        //IEnumerable<Empleado> ObtenerPorSalario();
    }
}
