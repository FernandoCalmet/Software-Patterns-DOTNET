﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class ConexionSQL
    {
        protected SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-Q0QT8H3\KHANAKAT;Initial Catalog=Pruebas ;User ID=fernando;Password=FcalmetR89;Integrated Security=true");
    }
}
