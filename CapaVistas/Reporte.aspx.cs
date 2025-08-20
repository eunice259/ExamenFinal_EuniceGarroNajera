using System;
using System.Data;
using System.Data.SqlClient;
using ExamenFinal_EuniceGarroNajera.CapaDatos;

namespace ExamenFinal_EuniceGarroNajera.CapaVistas
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Cargar();
        }

        private void Cargar()
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spReporte_PlantasPorCategoria", con) { CommandType = CommandType.StoredProcedure })
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                con.Open(); da.Fill(dt);
                gvRep.DataSource = dt; gvRep.DataBind();
            }
        }
    }
}
