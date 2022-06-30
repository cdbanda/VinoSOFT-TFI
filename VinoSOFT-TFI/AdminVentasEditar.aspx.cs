using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminVentasEditar : System.Web.UI.Page
    {
        BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInfo();
            }
        }


        private void CargarInfo()
        {

            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out _))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    BE.BE_Venta venta;
                    venta = gestorVentas.GetPorID(id);

                    if (venta != null)
                    {
                        ltlCliente.Text = venta.NOMBRECLIENTE;
                        ltlFecha.Text = venta.FECHA.ToString();
                        ltlMontoTotal.Text = venta.MONTOTOTAL.ToString();
                        ddEstado.SelectedValue = venta.ESTADO;
                        iptCodigo.Value = venta.IDVENTA.ToString();
                    }
                }
                else
                {
                    return;
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idVenta = int.Parse(iptCodigo.Value);
            bool guardado = gestorVentas.ActualizarEstado(idVenta, ddEstado.SelectedValue);
            if (guardado)
            {
                Response.Redirect("AdminVentasLista.aspx");
            }
        }
    }
}