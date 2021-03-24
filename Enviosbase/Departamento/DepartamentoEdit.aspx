<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartamentoEdit.aspx.cs" Inherits="Enviosbase.Departamento.DepartamentoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="fas fa-user text-primary"></i>
                        </span>
                        <h3 class="card-label">DEPARTAMENTO</h3>
                    </div>
                </div>
                <div class="card-body">
                    <asp:Label ID="lbId" Visible="false" runat="server" CssClass="form-control-static"></asp:Label>
                    <div class="row">
                        <div class="col-md-4">
                            <label class="control-label">País</label><span style="color:red;">*</span>
                            <asp:DropDownList ID="cbIdPais" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-md-8">
                            <label class="control-label">Nombre</label><span style="color:red;">*</span>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 2)"></asp:TextBox>
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
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlug" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="../Scripts/Custom/General.js"></script>
    <script>
        function ValidarForm() {
            var str = "";
            if ($("#MainContent_cbIdPais").val() == "") {
                str += "\n - País.";
            }
            if ($("#MainContent_txtNombre").val() == "") {
                str += "\n - Nombre.";
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

