using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Modelos;
using Dominio.ValorObjetos;

namespace Presentacion.Formularios
{
    public partial class FormEmpleado : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();
        public FormEmpleado()
        {
            InitializeComponent();
            panelRegistro.Enabled = false;
        }

        private void ListaEmpleados()
        {
            try
            {
                dataGridView1.DataSource = empleado.obtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refrescarPanel()
        {
            panelRegistro.Enabled = false;
            txtDni.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            ListaEmpleados();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = empleado.buscarPorDni(txtBuscar.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            empleado.Dni = txtDni.Text;
            empleado.Nombre = txtNombre.Text;
            empleado.Correo = txtCorreo.Text;
            empleado.Nacimiento = txtNacimiento.Value;

            bool validacion = new Soportes.ValidacionDatos(empleado).Validar();
            if(validacion == true)
            {
                string resultado = empleado.guardarCambios();
                MessageBox.Show(resultado);
                ListaEmpleados();
                refrescarPanel();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelRegistro.Enabled = true;
            empleado.estado = EstadoEntidad.Agregado;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                panelRegistro.Enabled = true;
                empleado.estado = EstadoEntidad.Modificado;
                empleado.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                txtDni.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtNacimiento.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
            }
            else
            {
                MessageBox.Show("Seleccionar fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {                
                empleado.estado = EstadoEntidad.Eliminado;
                empleado.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string resultado = empleado.guardarCambios();
                MessageBox.Show(resultado);
                ListaEmpleados();
            }
            else
            {
                MessageBox.Show("Seleccionar fila");
            }
        }
    }
}
