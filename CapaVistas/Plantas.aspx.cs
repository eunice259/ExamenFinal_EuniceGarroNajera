using System;
using ExamenFinal_EuniceGarroNajera.CapaLogica;
using ExamenFinal_EuniceGarroNajera.CapaModelo;

namespace ExamenFinal_EuniceGarroNajera.CapaVistas
{
    public partial class Plantas : System.Web.UI.Page
    {
        private readonly PlantaService _pl = new PlantaService();
        private readonly CategoriaService _cat = new CategoriaService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { CargarCategorias(); CargarTabla(); }
        }

        private void CargarCategorias()
        {
            ddlCategoria.DataSource = _cat.ObtenerTodas();
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- categoría --", "0"));
        }

        private void CargarTabla()
        {
            gvPlantas.DataSource = _pl.Listar();
            gvPlantas.DataBind();
            lblMsg.Text = "";
            hfId.Value = "";
            btnGuardar.Text = "Agregar";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var p = new PlantaMO
            {
                Id = string.IsNullOrEmpty(hfId.Value) ? 0 : int.Parse(hfId.Value),
                Nombre = txtNombre.Text,
                Descripcion = txtDesc.Text,
                CategoriaId = int.Parse(ddlCategoria.SelectedValue)
            };

            string r = (p.Id == 0) ? _pl.Crear(p) : _pl.Editar(p);
            lblMsg.Text = r == "OK" ? "Guardado." : r;
            if (r == "OK") { txtNombre.Text = txtDesc.Text = ""; ddlCategoria.SelectedIndex = 0; CargarTabla(); }
        }

        protected void gvPlantas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvPlantas.DataKeys[index].Value);

            if (e.CommandName == "Eliminar")
            {
                _pl.Eliminar(id); CargarTabla();
            }
            else if (e.CommandName == "Editar")
            {
                var fila = gvPlantas.Rows[index];
                hfId.Value = id.ToString();
                txtNombre.Text = fila.Cells[1].Text;
                ddlCategoria.SelectedIndex = ddlCategoria.Items.IndexOf(
                    ddlCategoria.Items.FindByText(fila.Cells[2].Text));
                txtDesc.Text = fila.Cells[3].Text.Replace("&nbsp;", "");
                btnGuardar.Text = "Actualizar";
            }
        }
    }
}
