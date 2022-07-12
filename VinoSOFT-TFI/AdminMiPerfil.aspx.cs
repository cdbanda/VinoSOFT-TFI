using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminMiPerfil : System.Web.UI.Page
    {
        AdminACL gestorPermisos = new AdminACL();
        BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void CargarDatosCliente()
        {
            BE.BE_Usuario usuarioLogueado = new BE.BE_Usuario();
            usuarioLogueado = (BE.BE_Usuario)Session["UsuarioLogueado"];

            BE.BE_Usuario usuario = gestorUsuario.getPorId(usuarioLogueado.IDUSUARIO);
            if (usuario != null)
            {
                iptIdUsuario.Value = usuario.IDUSUARIO.ToString();

                iptApellido.Text = usuario.APELLIDO;
                iptNombre.Text = usuario.NOMBRE;
                iptTelefono.Text = usuario.TELEFONO;
                iptDNI.Text = usuario.DNI.ToString();
                //iptCiudad.Text = usuario.CIUDAD;
                //iptDomicilio.Text = usuario.DOMICILIO;

                iptUsuario.Text = usuario.EMAIL;

            }
            else
            {
                mp1.Show();
                mjsBodyMP.Text = "No existe el usuario.";
            }

        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            BE.BE_Usuario usuarioLogueado = new BE.BE_Usuario();
            usuarioLogueado = (BE.BE_Usuario)Session["UsuarioLogueado"];

            usuarioLogueado.IDUSUARIO = int.Parse(iptIdUsuario.Value);
            usuarioLogueado.EMAIL = iptUsuario.Text;
            usuarioLogueado.NOMBRE = iptNombre.Text;
            usuarioLogueado.APELLIDO = iptApellido.Text;
            //clienteLogueado.DOMICILIO = iptDomicilio.Text;
            usuarioLogueado.DNI = int.Parse(iptDNI.Text);
            usuarioLogueado.TELEFONO = iptTelefono.Text;
            //clienteLogueado.CIUDAD = iptCiudad.Text;
            usuarioLogueado.CONTRASENA = usuarioLogueado.CONTRASENA;

            bool guardado = gestorUsuario.editar(usuarioLogueado);
            if (guardado)
            {
                mp1.Show();
                mjsBodyMP.Text = "Cambios Guardados con éxito";
            }
            else
            {
                mp1.Show();
                mjsBodyMP.Text = "Error al guardar los cambios";
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

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            mp1.Hide();
            Server.Transfer("Inicio.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}