<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminReporteVentas.aspx.cs" Inherits="VinoSOFT_TFI.AdminReporteVentas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
    <div class="container">
        <div>
            <h3>Reporte de Ventas</h3>
        </div>
        <div>
            <div>
                <h4>Cantidad de Ventas Por Estado</h4>
            </div>
            <br />
            <asp:Chart id="charEstadoVenta" runat="server" Width="400px" Height="400px">
                 <Legends>  
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                        LegendStyle="Row" />  
                </Legends>  
                <Series>
                    <asp:Series Name="Default"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>
        <hr />
        <div>
            <div>
                <h4>Cantidad de Ventas Por Producto</h4>
            </div>
            <br />
            <asp:Chart ID="chartCantVentasPorProducto" runat="server"  Width="700px" Height="300px">
                <Titles>
                    <asp:Title ShadowOffset="3" Name="Items" />
                 </Titles>
                <Series>
                    <asp:Series Name="Series1" ChartType="Bar" IsVisibleInLegend="false"
                        IsValueShownAsLabel="true" YValuesPerPoint="6"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                         <AxisX LineColor="Gray">
                            <MajorGrid LineColor="Gray" />
                        </AxisX>
                        <AxisY LineColor="Gray">
                            <MajorGrid LineColor="Gray" />
                        </AxisY>
                        
                    </asp:ChartArea>

                </ChartAreas>
                <Legends>
                    <asp:Legend>
                    </asp:Legend>
                </Legends>
            </asp:Chart>

        </div>
    </div>
</asp:Content>
