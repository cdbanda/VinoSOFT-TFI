using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminFamiliasEdicion : System.Web.UI.Page
    {
        BLL.BLL_Familia gestorFamilia = new BLL.BLL_Familia();
        BE.BE_Familia infoFamilia = new BE.BE_Familia();
        AdminACL gestorPermisos = new AdminACL();

        const string COD_PERMISO = "MOD_SEGURIDAD";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    if (gestorPermisos.TienePermiso(COD_PERMISO, (BE.BE_Usuario)Session["UsuarioLogueado"]))
                    {
                        CargarData();
                        cargarDdPermisos();
                        ActualizarBarraNavegacionLogin();
                    }
                    else
                    {
                        Response.Redirect("AdminLogin.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        public void ActualizarBarraNavegacionLogin()
        {
            BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            ((Backend)Master).MenuUsuarioNoLogeado = false;
            ((Backend)Master).MenuUsuarioLogeado = true;
            ((Backend)Master).NombreUsuario = "Hola, " + usuario.NOMBRE;
            ((Backend)Master).MenuInicio = true;

            ActualizarMenuesPorPermisos();
        }

        public void ActualizarMenuesPorPermisos()
        {
            BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            ((Backend)Master).MenuAdmFzas = gestorPermisos.TienePermiso("MOD_ADM_FZAS", usuario);
            ((Backend)Master).MenuSeguridad = gestorPermisos.TienePermiso("MOD_SEGURIDAD", usuario);
            ((Backend)Master).MenuVentas = gestorPermisos.TienePermiso("MOD_VENTAS", usuario);
            ((Backend)Master).MenuMkt = gestorPermisos.TienePermiso("MOD_MKT", usuario);
        }

        protected void BtnAgregarPermiso_Click(object sender, EventArgs e)
        {
            int idPermiso = int.Parse(ddPermisos.SelectedValue);
            int idFamilia = int.Parse(iptCodigo.Value);

            if (idFamilia > 0 && idPermiso > 0)
            {
                if (gestorFamilia.VerificarSiEstaFamiliaPermiso(idPermiso, idFamilia))
                {
                    ltlErrorPermiso.Visible = true;
                    ltlErrorPermiso.Text = "Rol ya asignado.";
                }
                else
                {
                    BE.BE_Permiso nuevoPermiso = new BE.BE_Permiso();
                    nuevoPermiso.IDPERMISO = idPermiso;
                    bool agregado = gestorFamilia.agregarPermiso(nuevoPermiso, idFamilia);
                    if (agregado)
                    {
                        ltlErrorPermiso.Visible = false;
                        CargarData();
                        CargarDvgPermisos(infoFamilia.LISTAPERMISO);
                    }
                    else
                    {
                        mp1.Show();
                        mjsBodyMP.Text = "Error al agregar al permiso.";
                    }

                }
            }
            else
            {
                mp1.Show();
                mjsBodyMP.Text = "Error al agregar el permiso.";
            }

        }

        protected void CargarData()
        {
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out _))
                {
                    int idFamilia = int.Parse(Request.QueryString["id"]);
                    infoFamilia = gestorFamilia.obtenerPorId(idFamilia);

                    if (infoFamilia != null)
                    {
                        iptCodigo.Value = infoFamilia.IDFAMILIA.ToString();
                        iptNombre.Text = infoFamilia.NOMBRE;
                        btnEliminar.Visible = true;
                        CargarDvgPermisos(infoFamilia.LISTAPERMISO);
                        phAsignarFamiliasPermisos.Visible = true;
                    }

                }
            }
        }

        protected void CargarDvgPermisos(List<BE.BE_Permiso> permisos)
        {
            if (permisos != null)
            {
                dgvPermisos.DataSource = null;
                dgvPermisos.DataSource = permisos;
                dgvPermisos.DataBind();
            }

        }

        protected void cargarDdPermisos()
        {
            BLL.BLL_Permiso gestorPermisos = new BLL.BLL_Permiso();
            ddPermisos.DataSource = null;
            ddPermisos.DataMember = "BE_Permiso";
            ddPermisos.DataValueField = "IdPermiso";
            ddPermisos.DataTextField = "descripcion";
            ddPermisos.DataSource = gestorPermisos.listar(null);
            ddPermisos.DataBind();
        }

        protected void dgvPermisos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = dgvPermisos.Rows[e.RowIndex];
            string idPerm = row.Cells[0].Text;

            int idFamilia = int.Parse(iptCodigo.Value);

            if (int.TryParse(idPerm, out _))
            {
                int idPermiso = int.Parse(idPerm);
                bool eliminado = gestorFamilia.quitarPermiso(idFamilia, idPermiso);
                if (eliminado)
                {
                    ltlErrorPermiso.Visible = true;
                    CargarData();
                    CargarDvgPermisos(infoFamilia.LISTAPERMISO);
                }
                else
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Error al eliminar el permiso.";
                }

            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(iptCodigo.Value, out _))
            {
                int idFamilia = int.Parse(iptCodigo.Value);
                BE.BE_Familia familia = new BE.BE_Familia();
                familia.IDFAMILIA = idFamilia;

                bool eliminado = gestorFamilia.eliminar(familia);
                if (eliminado)
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Rol eliminado Correctamente.";
                }
                else
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Error al eliminar el rol.";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE.BE_Familia familia = new BE.BE_Familia();

            familia.IDFAMILIA = (iptCodigo.Value != "") ? int.Parse(iptCodigo.Value) : 0;
            familia.NOMBRE = iptNombre.Text;

            if (familia.IDFAMILIA > 0)
            {
                bool guardado = gestorFamilia.editar(familia);
                if (guardado)
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Cambios guardados correctamente.";
                }
                else
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Error al guardar los cambios.";
                }

            }
            else
            {
                bool guardado = gestorFamilia.crear(familia);
                if (guardado)
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Rol creado correctamente";
                }
                else
                {
                    mp1.Show();
                    mjsBodyMP.Text = "Error al crear el rol.";
                }
            }
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            mp1.Hide();
            Server.Transfer("AdminFamiliasLista.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}