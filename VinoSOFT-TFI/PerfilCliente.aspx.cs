using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class PerfilCliente : System.Web.UI.Page
    {
        BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();
        ClienteACL gestorPermisos = new ClienteACL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    ActualizarBarraNavegacionLogin();
                    CargarDatosCliente();

                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        private void CargarDatosCliente()
        {
            BE.BE_Cliente clienteLogueado = new BE.BE_Cliente();
            clienteLogueado = (BE.BE_Cliente)Session["ClienteLogueado"];

            BE.BE_Cliente cliente = gestorCliente.getPorID(clienteLogueado.IDCLIENTE);
            if(cliente != null)
            {
                iptIdUsuario.Value = cliente.IDCLIENTE.ToString();

                iptApellido.Text = cliente.APELLIDO;
                iptNombre.Text = cliente.NOMBRE;
                iptTelefono.Text = cliente.TELEFONO;
                iptDNI.Text = cliente.DNI.ToString();
                iptCiudad.Text = cliente.CIUDAD;
                iptDomicilio.Text = cliente.DOMICILIO;

                iptUsuario.Text = cliente.EMAIL;

            }
            else
            {
                mp1.Show();
                mjsBodyMP.Text = "No existe el usuario.";
            }

        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            BE.BE_Cliente clienteLogueado = new BE.BE_Cliente();
            clienteLogueado = (BE.BE_Cliente)Session["ClienteLogueado"];

            clienteLogueado.IDCLIENTE = int.Parse(iptIdUsuario.Value);
            clienteLogueado.EMAIL = iptUsuario.Text;
            clienteLogueado.NOMBRE = iptNombre.Text;
            clienteLogueado.APELLIDO = iptApellido.Text;
            clienteLogueado.DOMICILIO = iptDomicilio.Text;
            clienteLogueado.DNI = int.Parse(iptDNI.Text);
            clienteLogueado.TELEFONO = iptTelefono.Text;
            clienteLogueado.CIUDAD = iptCiudad.Text;
            clienteLogueado.CONTRASENA = clienteLogueado.CONTRASENA;

            bool guardado = gestorCliente.editar(clienteLogueado);
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
            BE.BE_Cliente usuario = (BE.BE_Cliente)Session["ClienteLogueado"];

            ((MasterPage)Master).carritoVisible = true;
            ((MasterPage)Master).perfilUsuarioLogeado = true;
            ((MasterPage)Master).lblNombreUsuario = "Hola, " + usuario.NOMBRE;

            ((MasterPage)Master).perfilUsuarioNoLogeado = false;
        }


        protected void BtnOk_Click(object sender, EventArgs e)
        {
            mp1.Hide();
            Server.Transfer("Inicio.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnCambiarContrasenia_Click(object sender, EventArgs e)
        {
            Server.Transfer("CambiarContrasenia.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}