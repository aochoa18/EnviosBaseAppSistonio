<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DomiciliarioEdit.aspx.cs" Inherits="Enviosbase.Domiciliario.DomiciliarioEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="flaticon2-delivery-truck text-primary"></i>
                        </span>
                        <h3 class="card-label">DOMICILIARIO</h3>
                    </div>
                    <div class="card-toolbar">
                    </div>
                </div>
                <div class="card-body">
                    <asp:Label ID="lbId" runat="server" CssClass="form-control-static" Visible="false"></asp:Label>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="col-lg-4">
                                    <label class="">Foto</label>
                                </div>
                                <div class="col-lg-8">
                                    <asp:HiddenField ID="hdnFoto" runat="server" />
                                    <div class="image-input image-input-empty image-input-outline" id="kt_image_5" style="background-image: url(../assets/media/products/23.png)">
                                        <div class="image-input-wrapper" id="kt_image_load"></div>
                                        <label class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="change" data-toggle="tooltip" title="" data-original-title="Cambiar imagen">
                                            <i class="fa fa-pen icon-sm text-muted"></i>
                                            <asp:FileUpload ID="fnArchivoFoto" runat="server" accept="image/x-png,image/gif,image/jpeg"></asp:FileUpload>
                                            <asp:HiddenField ID="hdnFoto_remove" runat="server" />
                                        </label>
                                        <span class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="cancel" data-toggle="tooltip" title="Limpiar imagen">
                                            <i class="ki ki-bold-close icon-xs text-muted"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="row">
                                <div class="col-lg-4">
                                    <label class="control-label">Nombre</label><span style="color: red;">*</span>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="150" onkeypress="return check(event, 2)"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label class="control-label">Documento</label><span style="color: red;">*</span>
                                    <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <label class="control-label">Correo</label><span style="color: red;">*</span>
                                    <input type="email" name="txtCorreo" id="txtCorreo" runat="server" class="form-control" onblur="caracteresCorreoValido($(this).val(), '#xmail')" />
                                    <div id="xmail" style="display: none">
                                        <h4 class="text-danger">Ingresa un email valido</h4>
                                    </div>
                                </div>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" class="col-lg-3">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <label class="control-label">Pais</label><span style="color: red;">*</span>
                                                <asp:DropDownList ID="cbIdPais" runat="server" CssClass="form-control m-b" AutoPostBack="true" OnSelectedIndexChanged="cbIdPais_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div class="row">
                                <asp:UpdatePanel runat="server" ID="udpGeografia" UpdateMode="Conditional" class="col-lg-6">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <label class="control-label">Departamento</label><span style="color: red;">*</span>
                                                <asp:DropDownList ID="cbIdDepto" runat="server" CssClass="form-control m-b" AutoPostBack="true" OnSelectedIndexChanged="cbIdDepto_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-6">
                                                <label class="control-label">Municipio</label><span style="color: red;">*</span>
                                                <asp:DropDownList ID="cbIdMunicipio" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="cbIdPais" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="cbIdDepto" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="col-lg-4">
                                    <label class="control-label">Dirección</label><span style="color: red;">*</span>
                                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 1)"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label class="control-label">Teléfono</label>
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="7" onkeypress="return check(event, 3)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-2">
                            <label class="control-label">Celular</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Vehiculo</label><span style="color: red;">*</span>
                            <asp:DropDownList ID="cbIdTipoVehiculo" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Marca</label><span style="color: red;">*</span>
                            <asp:DropDownList ID="cbIdMarca" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <label class="control-label">Modelo</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <label class="control-label">Placa</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control" MaxLength="6" onkeypress="return check(event, 1)"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <b>
                        <label class="control-label">ANEXAR DOCUMENTOS</label></b>
                    <hr>
                    <br />
                    <div class="row">
                        <%--<div class="col-lg-2">
                            <label class="control-label">Foto</label>
                            <asp:FileUpload ID="fnArchivoFoto" runat="server" accept="image/x-png,image/gif,image/jpeg" CssClass="form-control" />
                        </div>--%>
                        <div class="col-lg-3">
                            <label class="control-label">Documento</label>
                            <asp:HiddenField ID="hdnFileDoc" runat="server" />
                            <asp:FileUpload ID="fnArchivoDoc" runat="server" accept="image/x-png,image/gif,image/jpeg" CssClass="form-control" />
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Licencia conducción</label>
                            <asp:HiddenField ID="hdnFileLic" runat="server" />
                            <asp:FileUpload ID="fnArchivoPase" runat="server" accept="image/x-png,image/gif,image/jpeg" CssClass="form-control" />
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Soat</label>
                            <asp:HiddenField ID="hdnFileSoat" runat="server" />
                            <asp:FileUpload ID="fnArchivoSoat" runat="server" accept="image/x-png,image/gif,image/jpeg" CssClass="form-control" />
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Tarjeta propiedad</label>
                            <asp:HiddenField ID="hdnFileTar" runat="server" />
                            <asp:FileUpload ID="fnArchivoTarjeta" runat="server"  accept="image/x-png,image/gif,image/jpeg" CssClass="form-control" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <span style="color: #C2C2C2; font-size:11px">* Las imagenes cargadas deben ser en formato png, jpg - el tamaño de la misma será máximo de 200kb </span>
                        </div>
                    </div>

                    <br />
                    <asp:HiddenField ID="hdEstado" runat="server" />
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
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="../Scripts/Custom/General.js"></script>
    <script>
        function ValidarForm() {
            var str = "";

            if ($("#MainContent_txtNombre").val() == "") {
                str += "\n - Nombre";
            }
            if ($("#MainContent_txtDocumento").val() == "") {
                str += "\n - Documento";
            }
            if ($("#MainContent_txtCorreo").val() == "") {
                str += "\n - Correo";
            }
            if ($("#MainContent_cbIdPais").val() == "") {
                str += "\n - País";
            }
            if ($("#MainContent_cbIdDepto").val() == "0") {
                str += "\n - Departamento";
            }
            if ($("#MainContent_cbIdMunicipio").val() == "0") {
                str += "\n - Municipio";
            }
            if ($("#MainContent_txtDireccion").val() == "") {
                str += "\n - Dirección";
            }
            //if ($("#MainContent_txtTelefono").val() == "") {
            //    str += "\n - Teléfono";
            //}
            if ($("#MainContent_txtCelular").val() == "") {
                str += "\n - Celular";
            }

            if ($("#MainContent_cbIdTipoVehiculo").val() == "") {
                str += "\n - Tipo vehiculo";
            }
            if ($("#MainContent_cbIdMarca").val() == "") {
                str += "\n - Marca";
            }
            if ($("#MainContent_txtModelo").val() == "") {
                str += "\n - Modelo";
            }
            if ($("#MainContent_txtPlaca").val() == "") {
                str += "\n - Placa";
            }
            if ($("#MainContent_fnArchivoFoto").val() == "" && $("#MainContent_hdnFoto").val() == "") {
                str += "\n - Foto";
            }
            if ($("#MainContent_fnArchivoDoc").val() == "" && $("#MainContent_hdnFileDoc").val() == "") {
                str += "\n - imagen documento";
            }
            if ($("#MainContent_fnArchivoPase").val() == "" && $("#MainContent_hdnFileLic").val() == "") {
                str += "\n - imagen pase";
            }
            if ($("#MainContent_fnArchivoSoat").val() == "" && $("#MainContent_hdnFileSoat").val() == "") {
                str += "\n - imagen soat";
            }
            if ($("#MainContent_fnArchivoTarjeta").val() == "" && $("#MainContent_hdnFileTar").val() == "") {
                str += "\n - imagen tarjeta";
            }
            if (str != "") {
                cargaSweetError("Por favor verificar los siguientes campos:" + str, 1, 5000);
                return false;
            } else {
                $('#MainContent_btnSave').click();
            }
        }

        $(function () {
            var img = $('#MainContent_fnArchivoFoto').val();
            if (img != "")
                $('#kt_image_load').css("background-image", "url('" + img + "')");
            avatar5 = new KTImageInput('kt_image_5');
        });




        //$('#MainWrapper_btnSave').click(function (e) {

        //});
    </script>
</asp:Content>
