using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dao_dto_singleton.UI
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FormClientes formClientes = FormClientes.ObtenerInstancia();
            formClientes.MdiParent = this;
            formClientes.Show();
            formClientes.BringToFront();
        }

        private void LibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLibros formLibros = FormLibros.ObtenerInstancia();
            formLibros.MdiParent = this;
            formLibros.Show();
            formLibros.BringToFront();
        }
    }
}
