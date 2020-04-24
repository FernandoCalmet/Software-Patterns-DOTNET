using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contratos
{
    public interface IRepositorioGenerico<Entidad> where Entidad:class
    {
        int Agregar(Entidad entidad);
        int Editar(Entidad entidad);
        int Eliminar(int id);
        IEnumerable<Entidad> ConsultarTodos();
    }
}
