//Admmin backup

        private void descargarArchivo(string nombreArchivo, string dirCompleto)
        {
            try
            {
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.ContentType = "application/octet-stream";
                response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo + ";");
                //response.TransmitFile(Server.MapPath("~/File/001.jpg"));
                response.TransmitFile(dirCompleto);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
        }


-----------------------------------
//Modal

<asp:HiddenField ID="hidForModel" runat="server" />

<!-- ModalPopupExtender -->
<ajaxtoolkit:ModalPopupExtender ID="mp1" runat="server" 
    PopupControlID="Panel1" 
    TargetControlID="hidForModel"
    CancelControlID="btnClose" 
    BackgroundCssClass="modalBackground">
</ajaxtoolkit:ModalPopupExtender>

<asp:Panel ID="Panel1" runat="server" CssClass="modal-content modal-sm" Style="display:none">
    <div id="body" class="modal-body">
         <asp:label runat="server" ID="mjsBodyMP"></asp:label>
    </div>
    <div id="footer" class="modal-footer">
        <asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="btn-info" />
    </div>
</asp:Panel>
<!-- ModalPopupExtender -->

