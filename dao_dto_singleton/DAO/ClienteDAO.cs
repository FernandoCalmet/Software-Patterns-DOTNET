using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using dao_dto_singleton.DTO;

namespace dao_dto_singleton.DAO
{
    class ClienteDAO:ConexionDAO
    {
        SqlDataReader leerFilas;
        SqlCommand comandoSql = new SqlCommand();
        
        public List<ClienteDTO> VerRegistros(string pCondicion)
        {
            comandoSql.Connection = Conexion;
            comandoSql.CommandText = "VerRegistros";
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.Parameters.AddWithValue("@Condicion", pCondicion);

            Conexion.Open();

            leerFilas = comandoSql.ExecuteReader();
            List<ClienteDTO> listaGenerica = new List<ClienteDTO>();
            while(leerFilas.Read())
            {
                listaGenerica.Add(new ClienteDTO
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
            return listaGenerica;
        }

        public void Insertar() { }
        public void Editar() { }
        public void Eliminar() { }
    }
}
