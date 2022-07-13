using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace VinoSOFT_TFI
{
    public partial class AdminReporteVentas : System.Web.UI.Page
    {
        AdminACL gestorPermisos = new AdminACL();
        const string COD_PERMISO = "MOD_ADM_FZAS";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    if (gestorPermisos.TienePermiso(COD_PERMISO, (BE.BE_Usuario)Session["UsuarioLogueado"]))
                    {
                        CargarCantidadVentasPorEstado();
                        CargarCantidadProductosVendidos();
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

        private void CargarCantidadVentasPorEstado()
        {
            DataSet ds = new DataSet();
            BLL.BLL_Reporte gestorReporte = new BLL.BLL_Reporte();

            ds = gestorReporte.VentasPorEstadoCantidad();

            DataTable ChartData = ds.Tables[0];

            if (ChartData.Rows.Count > 0)
            {
                //storing total rows count to loop on each Record                          
                string[] XPoints = new string[ChartData.Rows.Count];

                int[] YPOints = new int[ChartData.Rows.Count];

                for (int count = 0; count < ChartData.Rows.Count; count++)
                {
                    // store values for X axis  
                    XPoints[count] = ChartData.Rows[count]["estado"].ToString();
                    //store values for Y Axis  
                    YPOints[count] = Convert.ToInt32(ChartData.Rows[count][1]);

                }
                //binding chart control  
                charEstadoVenta.Series[0].Points.DataBindXY(XPoints, YPOints);

                //Setting width of line  
                charEstadoVenta.Series[0].BorderWidth = 5;
                //setting Chart type   
                charEstadoVenta.Series[0].ChartType = SeriesChartType.Pie;

                charEstadoVenta.Series[0].IsValueShownAsLabel = true;
                //enable to show legend
                charEstadoVenta.Legends[0].Enabled = true;

                //show pie chart in 3d
                charEstadoVenta.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            }
            else
            {
                ltlCharEstadoVenta.Text = "No hay datos para mostrar.";
                ltlCharEstadoVenta.Visible = true;
            }
        }

        private void CargarCantidadProductosVendidos()
        {
            DataSet ds = new DataSet();
            BLL.BLL_Reporte gestorReporte = new BLL.BLL_Reporte();

            ds = gestorReporte.CantidadProductosVendidos();
            DataTable ChartData = ds.Tables[0];

            if (ChartData.Rows.Count > 0)
            {
                //storing total rows count to loop on each Record  
                string[] XPointMember = new string[ChartData.Rows.Count];
                int[] YPointMember = new int[ChartData.Rows.Count];

                for (int count = 0; count < ChartData.Rows.Count; count++)
                {
                    //storing Values for X axis  
                    XPointMember[count] = ChartData.Rows[count]["producto"].ToString();
                    //storing values for Y Axis  
                    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["cantidad"]);


                }
                //binding chart control  
                chartCantVentasPorProducto.Series[0].Points.DataBindXY(XPointMember, YPointMember);

                //Setting width of line  
                chartCantVentasPorProducto.Series[0].BorderWidth = 10;
                //setting Chart type   
                chartCantVentasPorProducto.Series[0].ChartType = SeriesChartType.Bar;
                // Chart1.Series[0].ChartType = SeriesChartType.StackedBar;  

                //Hide or show chart back GridLines  
                //Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;  
                //Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;  

                //Enabled 3D  
                //chartCantVentasPorProducto.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            }
            else
            {
                ltlchartCantVentasPorProducto.Text = "No hay datos para mostrar.";
                ltlchartCantVentasPorProducto.Visible = true;
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
    }
}