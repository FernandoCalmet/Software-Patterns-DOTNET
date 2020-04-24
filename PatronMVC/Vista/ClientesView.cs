using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatronMVC.Controlador;

namespace PatronMVC.Vista
{
    public partial class ClientesView : Form
    {
        public ClientesView()
        {
            InitializeComponent();
            ClientesControlador controlador = new ClientesControlador(this);
        }
    }
}
