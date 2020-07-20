using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminBitacora : System.Web.UI.Page
    {
        BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDvg();
                llenarFiltroEventos();
            }
        }

        private void llenarDvg(Hashtable filtros = null)
        {
            List<BE.BE_Bitacora> registros = new List<BE.BE_Bitacora>();
            registros = gestorBitacora.listarBitacora(filtros);
            //txtCantRegistros.Text = registros.Count.ToString();

            DgvBitacora.AutoGenerateColumns = false;
            DgvBitacora.DataSource = registros;
            DgvBitacora.DataBind();
        }


        private void llenarFiltroEventos()
        {
            List<BE.BE_Evento> registros = new List<BE.BE_Evento>();
            registros = gestorBitacora.listarEventos();

            ddFiltroEvento.DataTextField = "Nombre";
            ddFiltroEvento.DataValueField = "IdEvento";
            ddFiltroEvento.DataSource = registros;
            ddFiltroEvento.DataBind();
        }
        protected void DgvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DgvBitacora.PageIndex = e.NewPageIndex;
            this.llenarDvg();
        }

        protected void DgvBitacora_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Hashtable filtros = new Hashtable();
            filtros = getFiltros();
            llenarDvg(filtros);
        }

        private Hashtable getFiltros()
        {
            Hashtable filtros = new Hashtable();
            if (filtroPalabraClave.Text != null)
            {
                filtros.Add("@Observacion", filtroPalabraClave.Text);
            }
            int idEvento;
            if (int.TryParse(ddFiltroEvento.SelectedValue, out idEvento))
            {
                idEvento = int.Parse(ddFiltroEvento.SelectedValue);
                filtros.Add("@idEvento", idEvento);
            }
            DateTime fechaDesde;
            if (DateTime.TryParse(filtroFechaDesde.Text, out fechaDesde))
            {
                fechaDesde = DateTime.Parse(filtroFechaDesde.Text);
                filtros.Add("@fechaDesde", fechaDesde);
            }
            DateTime fechaHasta;
            if (DateTime.TryParse(filtroFechaHasta.Text, out fechaHasta))
            {
                fechaHasta = DateTime.Parse(filtroFechaHasta.Text);
                filtros.Add("@fechaHasta", fechaHasta);
            }
            return filtros;
        }
    }
}