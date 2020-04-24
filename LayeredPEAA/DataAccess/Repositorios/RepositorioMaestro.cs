using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositorios
{
    public abstract class RepositorioMaestro : Repositorio
    {
        protected List<SqlParameter> parametros;

        //Ejecutar comandos de no consulta (insertar, editar, guardar datos)
        protected int ExecuteNonQuery(string transactSql) 
        {
            //Patron Dispose
            //el objeto existira en la ram solo hasta que termine el bloque using
            using (var conexion = obtenerConexion())
            {
                conexion.Open();
                using (var comandoSql = new SqlCommand())
                {
                    comandoSql.Connection = conexion;
                    comandoSql.CommandText = transactSql;
                    comandoSql.CommandType = CommandType.Text;
                    foreach(SqlParameter item in parametros)
                    {
                        comandoSql.Parameters.Add(item);
                    }
                    int resultado = comandoSql.ExecuteNonQuery();
                    parametros.Clear();
                    return resultado;
                }
            }
        }

        //Ejecutar comandos de consulta (leer filas y mostrar datos)
        protected DataTable ExecuteReader(string transactSql) 
        {
            using (var conexion = obtenerConexion())
            {
                conexion.Open();
                using (var comandoSql = new SqlCommand())
                {
                    comandoSql.Connection = conexion;
                    comandoSql.CommandText = transactSql;
                    comandoSql.CommandType = CommandType.Text;
                    SqlDataReader lectorDatos = comandoSql.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(lectorDatos);
                        lectorDatos.Dispose();
                        return tabla;
                    }                  
                }
            }
        }
    }
}
