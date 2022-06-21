using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminUsuariosLista : System.Web.UI.Page
    {
        BLL.BLL_Usuario gestorUsuarios = new BLL.BLL_Usuario();
        ACL gestorPermisos = new ACL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDgv();

            }
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvUsuarios_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = dgvUsuarios.Rows[e.NewEditIndex];
            string idUsuario = row.Cells[0].Text;

            Response.Redirect("AdminUsuariosEditar.aspx?id=" + idUsuario);
        }

        protected void dgvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = dgvUsuarios.Rows[e.RowIndex];
            string idUsu = row.Cells[0].Text;
            int idUsuario = 0;

            if (int.TryParse(idUsu, out _))
            {
                idUsuario = int.Parse(idUsu);
               //if(idUsuario == gestorPermisos.GetIdUsuario())
               // {
               //     return;
               // }

                BE.BE_Usuario usuario = new BE.BE_Usuario();
                usuario.IDUSUARIO = idUsuario;
                bool eliminado = gestorUsuarios.eliminar(usuario);

                if (eliminado)
                {
                    Response.Redirect("AdminUsuariosLista.aspx");
                }

            }
        }

        protected void LlenarDgv()
        {
            List<BE.BE_Usuario> lista = new List<BE.BE_Usuario>();
            lista = gestorUsuarios.listar(null);
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = lista;
            dgvUsuarios.DataBind();

        }
    }
}