using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Abstractions;
using Domain.Model.Entities;
using Infra.DataAccess.Repository;

namespace Aplication
{
    public class ClienteService
    {
        //Proteccion para que la asignacion al campo solo puede ocurrir en el constructor de la misma clase
        readonly IClienteRepository clienteRepository;

        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        public IEnumerable<Cliente> GetClientes(string filter)
        {
            return clienteRepository.GetClientes(filter);
        }
    }
}
