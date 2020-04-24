using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Aplication;
using UI.Desktop.ViewModel;

namespace UI.Desktop.ApplicationController
{
    class ClienteController
    {
        public IEnumerable<ClienteViewModel> GetClientesAll(string filter)
        {
            var clienteList = new ClienteService().GetClientes(filter);
            //Mapear datos
            List<ClienteViewModel> viewModel = new List<ClienteViewModel>();

            foreach(Cliente item in clienteList)
            {
                viewModel.Add(new ClienteViewModel
                {
                    ID = item.ID,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Direccion = item.Direccion,
                    Ciudad = item.Ciudad,
                    Email = item.Email,
                    Telefono = item.Telefono,
                    Ocupacion = item.Ocupacion
                });
            }
            return viewModel;
        }
    }
}
