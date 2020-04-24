using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Repositorios
{
    public abstract class Repositorio
    {
        private readonly string cadenaConexion;

        public Repositorio()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["Presentacion.Properties.Settings.MiEmpresa"].ToString();
        }

        protected SqlConnection obtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
