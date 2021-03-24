<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteList.aspx.cs" Inherits="Enviosbase.Cliente.ClienteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="card card-custom">
                    <div class="card-header">
                        <div class="card-title">
                            <span class="card-icon">
                                <i class="flaticon2-position text-primary"></i>
                            </span>
                            <h3 class="card-label">LISTADO CLIENTES</h3>
                        </div>
                        <div class="card-toolbar">
                            <%--<asp:Button ID="btnNew" runat="server" Text="Nuevo Registro" CssClass="btn btn-primary" OnClick="btnNew_Click" />--%>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row align-items-center">
                            <div class="col-md-4">
                                <div class="input-icon">
                                    <input type="text" class="form-control" placeholder="Buscar..." id="example2_search_query">
                                    <span><i class="flaticon2-search-1 text-muted"></i></span>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-12">
                                <table id="example2" class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>NOMBRE</th>
                                            <th>DOCUMENTO</th>
                                            <th>CORREO</th>
                                            <th>TEL�FONO</th>
                                            <th>CELULAR</th>
                                            <th>DIRECCI�N</th>
                                            <th>ESTADO</th>
                                            <th>ACCIONES</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Literal ID="ltTableItems" runat="server"></asp:Literal>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="BodyPlug">
    <script src="../assets/js/pages/crud/ktdatatable/base/html-table.js"></script>
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="../assets/plugins/custom/datatables/datatables.bundle.js"></script>
</asp:Content>