<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResponsableEdit.aspx.cs" Inherits="Enviosbase.Responsable.ResponsableEdit" %>

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
                            <i class="flaticon2-avatar text-primary"></i>
                        </span>
                        <h3 class="card-label">RESPONSABLE</h3>
                    </div>
                    <div class="card-toolbar">
                    </div>
                </div>
                <div class="card-body">
                    <asp:Label ID="lbId" runat="server" CssClass="form-control-static" Visible="false"></asp:Label>
                    <div class="row">
                        <div class="col-lg-4">
                            <label class="control-label">Nombre</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 2)"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <label class="control-label">Documento</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="ontrol-label">Correo</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
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
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="150" onkeypress="return check(event, 1)"></asp:TextBox>
                        </div>
                         <div class="col-lg-2">
                            <label class="control-label">Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="7" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-3">
                            <label class="control-label">Celular</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                    </div>
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
            if (str != "") {
                cargaSweetError("Por favor verificar los siguientes campos:" + str, 1, 5000);
                return false;
            } else {
                $('#MainContent_btnSave').click();
            }
        }
    </script>
</asp:Content>
