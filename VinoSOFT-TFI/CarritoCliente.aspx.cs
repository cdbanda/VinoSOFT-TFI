using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class CarritoCliente : System.Web.UI.Page
    {
        BE.BE_Venta venta = new BE.BE_Venta();
        ClienteACL gestorPermisos = new ClienteACL();

        BE.BE_Cliente cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(gestorPermisos.EstaLogueado())
                {
                    //pruebaCliente();
                    CargarDataCarrito();
                    ActualizarBarraNavegacionLogin();

                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
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

        private void CargarDataCarrito()
        {
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];

            if (cliente != null)
            {
                BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
                BE.BE_Venta carrito = gestorVentas.GetCarrito(cliente.IDCLIENTE);
                
                if (carrito != null)
                {
                    carrito.ITEMS = AgregarFormatoImagenes(carrito.ITEMS);
                    dgvCarrito.DataSource = null;
                    dgvCarrito.DataMember = "BE_Venta_Detalle";
                    dgvCarrito.DataSource = carrito.ITEMS;
                    dgvCarrito.DataBind();
                    lblTotalMonto.Text = CalcularTotal(carrito.ITEMS).ToString();
                }
            }
        }

        private float CalcularTotal(List<BE.BE_Venta_Detalle> lista)
        {
            float total = 0;
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    foreach (BE.BE_Venta_Detalle vtaDetalle in lista)
                    {
                        total = total + vtaDetalle.SUBTOTAL;
                    }
                    return total;
                }
                else
                {
                    return total;
                }
            }
            else
            {
                return total;
            }
        }

        private List<BE.BE_Venta_Detalle> AgregarFormatoImagenes(List<BE.BE_Venta_Detalle> lista)
        {
            string formato = "data:image/jpeg;base64,";
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    foreach (BE.BE_Venta_Detalle vtaDetalle in lista)
                    {
                        vtaDetalle.PRODUCTO.IMAGEN = formato + vtaDetalle.PRODUCTO.IMAGEN;
                    }
                    return lista;
                }
            }
            return lista;
        }

        //private void pruebaCliente()
        //{

        //    if (Session["UsuarioLogueado"] == null)
        //    {
        //        BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();
        //        clientePrueba = gestorCliente.getPorID(3);
        //        Session["UsuarioLogueado"] = clientePrueba;
        //    }
        //    else
        //    {
        //        clientePrueba = new BE.BE_Cliente();
        //        clientePrueba = (BE.BE_Cliente)Session["UsuarioLogueado"];
        //    }
        //}

        protected void dgvCarrito_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BLL.BLL_Venta gestorVenta = new BLL.BLL_Venta();

            GridViewRow row = dgvCarrito.Rows[e.NewEditIndex];
            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
            HiddenField fieldVtaDetalle = (HiddenField)row.FindControl("idVentaDetalle");


            //do something with details 
            string cantidad = txtCantidad.Text;
            if(int.TryParse(cantidad, out _) && !string.IsNullOrEmpty(cantidad) && !string.IsNullOrEmpty(cantidad))
            {
                int cant = int.Parse(cantidad);
                if (cant > 0 && cant < 6)
                {
                    string strVtaDetalle = fieldVtaDetalle.Value;
                    int idVtaDetalle = int.Parse(strVtaDetalle);
                    BE.BE_Venta_Detalle vtaDetalle = new BE.BE_Venta_Detalle();
                    vtaDetalle.IDVENTADETALLE = idVtaDetalle;
                    vtaDetalle.CANTIDAD = cant;

                    bool guardado = gestorVenta.EditarItem(vtaDetalle);
                    if (guardado)
                    {
                        //pruebaCliente();
                        CargarDataCarrito();
                    }
                }
            }
            else
            {
                Response.Redirect(Request.RawUrl,false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void dgvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BLL.BLL_Venta gestorVenta = new BLL.BLL_Venta();

            GridViewRow row = dgvCarrito.Rows[e.RowIndex];
            HiddenField fieldVtaDetalle = (HiddenField)row.FindControl("idVentaDetalle");
            string vtaDetalle = fieldVtaDetalle.Value;
            

            //do something with details 
            if (int.TryParse(vtaDetalle, out _) && !string.IsNullOrEmpty(vtaDetalle) && !string.IsNullOrEmpty(vtaDetalle))
            {
                   int id = int.Parse(vtaDetalle);

                    BE.BE_Venta_Detalle vtaDet = new BE.BE_Venta_Detalle();
                    vtaDet.IDVENTADETALLE = id;

                    bool guardado = gestorVenta.EliminarItem(vtaDet);
                    if (guardado)
                    {
                        //pruebaCliente();
                        CargarDataCarrito();
                    }
                }
            }

        protected void btnSeguirComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagar.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

    }
