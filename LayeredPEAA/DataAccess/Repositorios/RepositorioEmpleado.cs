using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contratos;
using DataAccess.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositorios
{
    public class RepositorioEmpleado : RepositorioMaestro, IRepositorioEmpleado
    {
        //Campos
        private string seleccionarTodo;
        private string insertar;
        private string modificar;
        private string eliminar;

        //Propiedades
        //::

        //Constructores
        public RepositorioEmpleado()
        {
            seleccionarTodo = "SELECT * FROM Empleado";
            insertar = "INSERT INTO Empleado VALUES (@dni,@nombre,@correo,@nacimiento)";
            modificar = "UPDATE Empleado SET dni=@dni, nombre=@nombre, correo=@correo, nacimiento=@nacimiento WHERE id=@id";
            eliminar = "DELETE FROM Empleado WHERE id = @id";
        }
        
        //Metodos
        public int Agregar(Empleado entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@dni", entidad.dni));
            parametros.Add(new SqlParameter("@nombre", entidad.nombre));
            parametros.Add(new SqlParameter("@correo", entidad.correo));
            parametros.Add(new SqlParameter("@nacimiento", entidad.nacimiento));
            return ExecuteNonQuery(insertar);
        }

        public IEnumerable<Empleado> ConsultarTodos()
        {
            var resultadoTabla = ExecuteReader(seleccionarTodo);
            var listaEmpleados = new List<Empleado>();
            foreach(DataRow item in resultadoTabla.Rows)
            {
                listaEmpleados.Add(new Empleado{
                    id = Convert.ToInt32(item[0]),
                    dni = Convert.ToString(item[1]),
                    nombre = Convert.ToString(item[2]),
                    correo = Convert.ToString(item[3]),
                    nacimiento = Convert.ToDateTime(item[4])
                });
            }
            return listaEmpleados;
        }

        public int Editar(Empleado entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", entidad.id));
            parametros.Add(new SqlParameter("@dni", entidad.dni));
            parametros.Add(new SqlParameter("@nombre", entidad.nombre));
            parametros.Add(new SqlParameter("@correo", entidad.correo));
            parametros.Add(new SqlParameter("@nacimiento", entidad.nacimiento));
            return ExecuteNonQuery(modificar);
        }

        public int Eliminar(int id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            return ExecuteNonQuery(eliminar);
        }
    }
}
