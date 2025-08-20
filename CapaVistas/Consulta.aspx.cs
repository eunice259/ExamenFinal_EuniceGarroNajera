using System;
using ExamenFinal_EuniceGarroNajera.CapaLogica;

namespace ExamenFinal_EuniceGarroNajera.CapaVistas
{
    public partial class Consulta : System.Web.UI.Page
    {
        private readonly CategoriaService _cat = new CategoriaService();
        private readonly PlantaService _pl = new PlantaService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCat.DataSource = _cat.ObtenerTodas();
                ddlCat.DataTextField = "NombreCategoria";
                ddlCat.DataValueField = "Id";
                ddlCat.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlCat.SelectedValue);
            gvRes.DataSource = _pl.PorCategoria(id);
            gvRes.DataBind();
        }
    }
}
