using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PatronMVC.Modelo.DAO
{
    class ConexionBD
    {
        protected SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-Q0QT8H3\KHANAKAT;Initial Catalog=Pruebas ;User ID=fernando;Password=FcalmetR89;Integrated Security=true");
    }
}
