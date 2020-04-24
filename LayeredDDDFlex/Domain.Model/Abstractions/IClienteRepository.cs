using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;

namespace Domain.Model.Abstractions
{
    public interface IClienteRepository
    {
        //Comportamientos
        int agregar(Cliente cliente);
        int editar(Cliente cliente);
        int eliminar(Cliente cliente);
        IEnumerable<Cliente> GetClientes(string filter);
    }
}
