using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Abstractions;
using Domain.Model.Entities;

namespace Infra.DataAccess.Repository
{
    public class ClienteRepository : ConexionSQL, IClienteRepository
    {
        public int agregar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public int editar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public int eliminar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetClientes(string filter)
        {
            SqlDataReader leerFilas;
            SqlCommand comandoSql = new SqlCommand();
            comandoSql.Connection = Conexion;
            comandoSql.CommandText = "VerRegistros";
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.Parameters.AddWithValue("@Condicion", filter);
            Conexion.Open();
            leerFilas = comandoSql.ExecuteReader();
            List<Cliente> listaGenerica = new List<Cliente>();
            while (leerFilas.Read())
            {
                listaGenerica.Add(new Cliente
                {
                    ID = leerFilas.GetInt32(0),
                    Nombre = leerFilas.GetString(1),
                    Apellido = leerFilas.GetString(2),
                    Direccion = leerFilas.GetString(3),
                    Ciudad = leerFilas.GetString(4),
                    Email = leerFilas.GetString(5),
                    Telefono = leerFilas.GetString(6),
                    Ocupacion = leerFilas.GetString(7)
                });
            }
            leerFilas.Close();
            Conexion.Close();
            return listaGenerica;
        }
    }
}
