using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contratos;
using DataAccess.Entidades;
using DataAccess.Repositorios;
using Dominio.ValorObjetos;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Modelos
{
    public class ModeloEmpleado : IDisposable
    {
        private int id;
        private string dni;
        private string nombre;
        private string correo;
        private DateTime nacimiento;
        private int edad; //nuevo atributo

        private IRepositorioEmpleado repositorioEmpleado;
        public EstadoEntidad estado { private get; set; }

        private List<ModeloEmpleado> listaEmpleados;

        //Propiedades: Modelo de vista / Validar datos
        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage ="El campo del DNI es obligatorio.")]
        [RegularExpression("[0-9]+", ErrorMessage ="El DNI solo puede ser numerico.")]
        [StringLength(maximumLength:8, MinimumLength =8, ErrorMessage ="El DNI debe de tener 8 digitos.")]
        public string Dni { get => dni; set => dni = value; }
        [Required(ErrorMessage ="El campo del Nombre es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage ="El nombre solo puede ser letras.")]
        [StringLength(maximumLength:50, MinimumLength =3, ErrorMessage ="El nombre debe tener entre minimo 3 digitos y maximo 50 digitos.")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Required(ErrorMessage ="El campo del Correo es obligatorio.")]
        [EmailAddress]
        public string Correo { get => correo; set => correo = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public int Edad { get => edad; private set => edad = value; }

        public ModeloEmpleado()
        {
            repositorioEmpleado = new RepositorioEmpleado();
        }

        public string guardarCambios()
        {
            string mensaje = null;

            try
            {
                var datosModeloEmpleado = new Empleado();
                datosModeloEmpleado.id = id;
                datosModeloEmpleado.dni = dni;
                datosModeloEmpleado.nombre = nombre;
                datosModeloEmpleado.correo = correo;
                datosModeloEmpleado.nacimiento = nacimiento;

                switch (estado)
                {
                    case EstadoEntidad.Agregado: 
                        //Reglas comerciales / calculos pueden ir antes del registro
                        repositorioEmpleado.Agregar(datosModeloEmpleado);
                        mensaje = "Registro exitoso";
                        break;
                    case EstadoEntidad.Eliminado:
                        repositorioEmpleado.Eliminar(id);
                        mensaje = "Eliminado exitoso";
                        break;
                    case EstadoEntidad.Modificado:
                        repositorioEmpleado.Editar(datosModeloEmpleado);
                        mensaje = "Modificación exitosa";
                        break;
                }
            }
            catch(Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2627)
                    mensaje = "No se permite datos duplicados";
                else
                    mensaje = ex.ToString();
            }
            return mensaje;
        }

        public List<ModeloEmpleado> obtenerTodos()
        {
            var datosModeloEmpleado = repositorioEmpleado.ConsultarTodos();
            listaEmpleados = new List<ModeloEmpleado>();
            foreach(Empleado item in datosModeloEmpleado)
            {
                var cumpleanios = item.nacimiento;
                listaEmpleados.Add(new ModeloEmpleado { 
                    id = item.id,
                    dni = item.dni,
                    nombre = item.nombre,
                    correo = item.correo,
                    nacimiento = item.nacimiento,
                    edad = CalcularEdad(cumpleanios)
                });
            }
            return listaEmpleados;
        }

        public IEnumerable<ModeloEmpleado> buscarPorDni(string filtro)
        {
            return listaEmpleados.FindAll(e => e.dni.Contains(filtro) || e.nombre.Contains(filtro));
        }

        private int CalcularEdad(DateTime fecha)
        {
            DateTime fechaActual = DateTime.Now;
            return fechaActual.Year - fecha.Year;
        }

        public void Dispose()
        {
            //
        }
    }
}
