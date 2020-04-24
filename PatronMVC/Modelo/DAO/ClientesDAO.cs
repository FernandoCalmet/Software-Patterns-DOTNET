using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PatronMVC.Modelo.DTO;

namespace PatronMVC.Modelo.DAO
{
    class ClientesDAO : ConexionBD
    {
        private SqlDataReader leerFilas;
        private SqlCommand comandoSql = new SqlCommand();

        public List<ClientesDTO> VerRegistros(string pCondicion)
        {
            comandoSql.Connection = Conexion;
            comandoSql.CommandText = "VerRegistros";
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.Parameters.AddWithValue("@Condicion", pCondicion);
            Conexion.Open();
            leerFilas = comandoSql.ExecuteReader();
            //PATRON DTO (lista generica, diccionario, serializacion (XML JSON Nativa))          
            List<ClientesDTO> listaClientes = new List<ClientesDTO>();
           
            while (leerFilas.Read())
            {
                listaClientes.Add(new ClientesDTO
                {
                    Id = leerFilas.GetInt32(0),
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
            return listaClientes;
        }
    }
}
