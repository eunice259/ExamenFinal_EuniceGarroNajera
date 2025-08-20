using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ExamenFinal_EuniceGarroNajera.CapaDatos
{
    public class Conexion
    {
        public static string Cadena =>
           ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
    }
}