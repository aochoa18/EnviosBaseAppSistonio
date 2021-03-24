<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioEdit.aspx.cs" Inherits="Enviosbase.Usuario.UsuarioEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="fas fa-user-edit text-primary"></i>
                        </span>
                        <h3 class="card-label">USUARIO</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3" style="display: none">
                            <label class="control-label">Id</label>
                            <asp:Label ID="lbId" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="col-lg-3"></div>
                        <div class="col-lg-3">
                            <label class="control-label">Nombres</label>
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Apellidos</label>
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Login</label>
                            <asp:TextBox ID="txtUserLogin" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <label class="control-label">Password</label>
                            <asp:TextBox ID="txtPasswordLogin" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Correo Electronico</label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Telefono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="col-lg-3">
                            <label class="control-label">Tipo Usuario</label>
                            <asp:DropDownList ID="cbIdTipoUsuario" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <asp:HiddenField ID="hdEstado" runat="server" />
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-between">
                    <div class="col-lg-6 d-flex justify-content-between">
                        <asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <button id="btnValidate" type="button" onclick="ValidarForm()" class="btn btn-primary">Guardar</button>
                        <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="hidden" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="BodyPlug" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>

    <script>
        function ValidarForm() {
            var str = "";

            if ($("#MainContent_txtNombres").val() == "") {
                str += "\n - Nombres";
            }
            if ($("#MainContent_txtApellidos").val() == "") {
                str += "\n - Apellidos";
            }
            if ($("#MainContent_txtUserLogin").val() == "") {
                str += "\n - Login";
            }
            if ($("#MainContent_txtPasswordLogin").val() == "") {
                str += "\n - Password";
            }
            if ($("#MainContent_cbIdTipoUsuario").val() == "") {
                str += "\n - Tipo de Usuario";
            }
            if (str != "") {
                cargaSweetError("Por favor verificar los siguientes campos:" + str, 1, 3000);
                return false;
            } else {
                $('#MainContent_btnSave').click();
            }
        };
    </script>
</asp:Content>
