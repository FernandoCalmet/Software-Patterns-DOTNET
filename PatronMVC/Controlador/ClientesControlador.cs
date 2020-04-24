using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronMVC.Modelo.DAO;
using PatronMVC.Modelo.DTO;
using PatronMVC.Vista;

namespace PatronMVC.Controlador
{
    class ClientesControlador
    {
        private ClientesView Vista;

        public ClientesControlador(ClientesView pVista)
        {
            this.Vista = pVista;
            //inicializar eventos
            Vista.Load += new EventHandler(ListaClientes);
            Vista.btnBuscar.Click += new EventHandler(ListaClientes);
            Vista.txtBuscar.TextChanged += new EventHandler(ListaClientes);
        }

        private void ListaClientes(object sender, EventArgs e)
        {
            ClientesDAO dbh = new ClientesDAO();
            Vista.tablaClientes.DataSource = dbh.VerRegistros(Vista.txtBuscar.Text);
        }
    }
}
