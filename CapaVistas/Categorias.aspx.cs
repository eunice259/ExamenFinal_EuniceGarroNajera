using System;
using ExamenFinal_EuniceGarroNajera.CapaLogica;
using ExamenFinal_EuniceGarroNajera.CapaModelo;

namespace ExamenFinal_EuniceGarroNajera.CapaVistas
{
    public partial class Categorias : System.Web.UI.Page
    {
        private readonly CategoriaService _srv = new CategoriaService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Cargar();
        }

        private void Cargar()
        {
            gvCat.DataSource = _srv.ObtenerTodas();
            gvCat.DataBind();
            lblMsg.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var r = _srv.Crear(txtCat.Text);
            lblMsg.Text = r == "OK" ? "Guardado." : r;
            if (r == "OK") { txtCat.Text = ""; Cargar(); }
        }

        protected void gvCat_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        { gvCat.EditIndex = e.NewEditIndex; Cargar(); }

        protected void gvCat_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        { gvCat.EditIndex = -1; Cargar(); }

        protected void gvCat_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = (int)gvCat.DataKeys[e.RowIndex].Value;
            string nombre = ((System.Web.UI.WebControls.TextBox)gvCat.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            var r = _srv.Editar(new CategoriaMO { Id = id, NombreCategoria = nombre });
            lblMsg.Text = r == "OK" ? "Actualizado." : r;
            gvCat.EditIndex = -1; Cargar();
        }

        protected void gvCat_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = (int)gvCat.DataKeys[e.RowIndex].Value;
            _srv.Eliminar(id); Cargar();
        }
    }
}
