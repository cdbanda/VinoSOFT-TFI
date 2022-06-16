using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminUsuariosEditar : System.Web.UI.Page 
    {
        BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
        BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();
        BE.BE_Usuario infoUsuario = new BE.BE_Usuario();
        ACL gestorPermisos = new ACL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInfo();
                CargarDropFamilias();
            }
        }

        protected void btnAgregarfamilia_Click(object sender, EventArgs e)
        {
            int idFamilia = int.Parse(ddFamilias.SelectedValue);
            int idUsuario = int.Parse(iptCodigo.Value);

            if(idUsuario > 0 && idFamilia > 0)
            {
                bool agregado = gestorUsuario.agregarFamilia(idFamilia, idUsuario);
                if (agregado) {
                    CargarInfo();
                    CargarDvgFamilias(infoUsuario.LISTAFAMILIA);
                    }
            }
        }

        protected void dgvFamilias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = dgvFamilias.Rows[e.RowIndex];
            int idUsuario = int.Parse(iptCodigo.Value);

            if (int.TryParse(row.Cells[0].Text, out _)) {
                int idFamilia = int.Parse(row.Cells[0].Text);
                bool eliminado = gestorUsuario.quitarFamilia(idUsuario, idFamilia);

                if (eliminado)
                {
                    CargarInfo();
                    CargarDvgFamilias(infoUsuario.LISTAFAMILIA);
                }
            }


        }

        protected void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            int idPermiso = int.Parse(ddPermisos.SelectedValue);
            int idUsuario = int.Parse(iptCodigo.Value);
            if (idUsuario > 0 && idPermiso > 0)
            {
                BE.BE_Permiso nuevoPermiso = new BE.BE_Permiso();
                nuevoPermiso.IDPERMISO = idPermiso;
                bool agregado = gestorUsuario.agregarPermiso(idUsuario, nuevoPermiso);
                if (agregado)
                {
                    CargarInfo();
                    CargarDvgPermisos(infoUsuario.LISTAPERMISO);
                }
            }
        }

        private void CargarInfo()
        {
            if(Request.QueryString["id"] != null)
            {
                if(int.TryParse(Request.QueryString["id"], out _))
                {
                    int idUsuario = int.Parse(Request.QueryString["id"]);
                    infoUsuario = gestorUsuario.getPorId(idUsuario);

                    if (infoUsuario != null)
                    {
                        iptUsuario.Text = infoUsuario.USUARIO;
                        iptCodigo.Value = infoUsuario.IDUSUARIO.ToString();
                        iptNombre.Text = infoUsuario.NOMBRE;
                        iptApellido.Text = infoUsuario.APELLIDO;
                        iptEmail.Text = infoUsuario.EMAIL;
                        iptTelefono.Text = infoUsuario.TELEFONO;
                        iptDNI.Text = infoUsuario.DNI.ToString();
                        ddActivo.SelectedValue = infoUsuario.ACTIVO ? "1" : "0";
                        btnEliminar.Visible = true;
                        iptContrasena.Visible = false;
                        txtPwdGuardada.Visible = true;
                        RequiredFieldValidator_iptContrasena.Visible = false;

                        //cargar permisos del usuario
                        CargarDvgFamilias(infoUsuario.LISTAFAMILIA);
                        CargarDvgPermisos(infoUsuario.LISTAPERMISO);

                        phAsignarFamiliaPermisos.Visible = true;
                    }
                }
            }
        }

        private void CargarDvgFamilias(List<BE.BE_Familia> familias)
        {
            if(familias != null)
            {
                dgvFamilias.DataSource = null;
                dgvFamilias.DataSource = familias;
                dgvFamilias.DataBind();
            }
        }

        private void CargarDvgPermisos(List<BE.BE_Permiso> permisos)
        {
            if(permisos != null)
            {
                dgvPermisos.DataSource = null;
                dgvPermisos.DataSource = permisos;
                dgvPermisos.DataBind();
            }
        }

        private void CargarDropPermisos()
        {
            BLL.BLL_Permiso gestorPermisos = new BLL.BLL_Permiso();
            ddPermisos.DataMember = "BE_Permiso";
            ddPermisos.DataValueField = "IdPermiso";
            ddPermisos.DataTextField = "Descripcion";
            ddPermisos.DataSource = gestorPermisos.listar(null);
            ddPermisos.DataBind();
        }

        private void CargarDropFamilias()
        {
            BLL.BLL_Familia gestorFamilia = new BLL.BLL_Familia();
            ddFamilias.DataMember = "BE_Familia";
            ddFamilias.DataValueField = "IdFamilia";
            ddFamilias.DataTextField = "Nombre";
            ddFamilias.DataSource = gestorFamilia.listar(null);
            ddFamilias.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(iptCodigo.Value, out _))
            {
                int idUsuario = int.Parse(iptCodigo.Value);
                if(idUsuario == gestorPermisos.GetIdUsuario() )
                {

                }
                else
                {
                    BE.BE_Usuario usuario = new BE.BE_Usuario();
                    usuario.IDUSUARIO = idUsuario;
                    bool eliminado = gestorUsuario.eliminar(usuario);
                    if (eliminado)
                    {
                        Response.Redirect("AdminUsuariosLista.aspx");
                    }

                }
            }
        }
    }
}