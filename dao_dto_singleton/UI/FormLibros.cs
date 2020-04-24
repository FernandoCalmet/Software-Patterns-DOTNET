using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dao_dto_singleton.DAO;

namespace dao_dto_singleton.UI
{
    public partial class FormLibros : Form
    {
        //Aplicar el Patron Singleton para evitar abrir multiples ventanas del objeto
        private static FormLibros InstanciaFormLibros = null; 
        private FormLibros()
        {
            InitializeComponent();
        }
        public static FormLibros ObtenerInstancia()
        {
            if(InstanciaFormLibros == null){InstanciaFormLibros = new FormLibros(); }
            return InstanciaFormLibros;
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            //condicion vacia para ver todos los registros
            VerRegistros("");
        }

        private void VerRegistros(string pCondicion)
        {
            ClienteDAO DaoCliente = new ClienteDAO();
            dataGridView1.DataSource = DaoCliente.VerRegistros(pCondicion);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Buscar registros al presionar el boton
            VerRegistros(txtBuscar.Text);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrar registros al ingresar texto
            VerRegistros(txtBuscar.Text);
        }
    }
}
