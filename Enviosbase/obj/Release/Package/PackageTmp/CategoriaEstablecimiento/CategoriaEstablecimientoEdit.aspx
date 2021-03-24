<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaEstablecimientoEdit.aspx.cs" Inherits="Enviosbase.CategoriaEstablecimiento.CategoriaEstablecimientoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="flaticon-notepad text-primary"></i>
                        </span>
                        <h3 class="card-label">CATEGORIA ESTABLECIMIENTO</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <label class="control-label">Nombre</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 2)"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label class="control-label">Descripción</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="2000" onkeypress="return check(event, 1)"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-lg-1">
                                <label class="control-label">Imagen</label>
                            </div>
                            <asp:HiddenField ID="hdnFileImage" runat="server" />
                            <div class="col-lg-2">
                                <%--<asp:TextBox ID="txtImagen" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                <div class="image-input image-input-empty image-input-outline" id="kt_image_5" style="background-image: url(../assets/media/products/23.png)">
                                    <div class="image-input-wrapper" id="kt_image_load"></div>
                                    <label class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="change" data-toggle="tooltip" title="" data-original-title="Cambiar imagen">
                                        <i class="fa fa-pen icon-sm text-muted"></i>
                                        <asp:FileUpload ID="fnImagen" runat="server" accept="image/*"></asp:FileUpload>
                                        <asp:HiddenField ID="fnImagen_remove" runat="server" />
                                    </label>
                                    <span class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="cancel" data-toggle="tooltip" title="Limpiar imagen">
                                        <i class="ki ki-bold-close icon-xs text-muted"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3" style="display: none">
                            <asp:Label ID="lbId" runat="server" Visible="false" CssClass="form-control-static"></asp:Label>
                        </div>
                        <asp:HiddenField ID="hdEstado" runat="server" />
                    </div>
                </div>
                 <div class="card-footer">
                    <div class="row">
                        <div class="col-md-9"></div>
                        <div class="col-md-3">
                            <asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                            <button id="btnValidate" type="button" onclick="ValidarForm()" class="btn btn-primary">Guardar</button>
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="hidden" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="BodyPlug" runat="server">
    <script src="../assets/plugins/global/plugins.bundle.js"></script>
    <script src="../assets/plugins/custom/prismjs/prismjs.bundle.js"></script>
    <script src="../assets/js/scripts.bundle.js"></script>
    <script src="../Scripts/Custom/Producto.js"></script>
    <script src="../Scripts/Custom/General.js"></script>
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script>
        function ValidarForm() {
            var str = "";
            debugger;
            if ($("#MainContent_txtNombre").val() == "") {
                str += "\n - Nombre";
            }
            if ($("#MainContent_txtDescripcion").val() == "") {
                str += "\n - Descripcion";
            }
            if (str != "") {
                cargaSweetError("Por favor verificar los siguientes campos:" + str, 1, 3000);
                return false;
            } else {
                $('#MainContent_btnSave').click();
            }
        }


      

    </script>
</asp:Content>
