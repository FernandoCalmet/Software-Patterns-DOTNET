using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.ApplicationController;

namespace UI.Desktop.Forms
{
    public partial class FormCliente : Form
    {
        private ClienteController cliente;
        public FormCliente()
        {
            InitializeComponent();
            cliente = new ClienteController();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cliente.GetClientesAll("");
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cliente.GetClientesAll(txtFiltrar.Text);
        }
    }
}
