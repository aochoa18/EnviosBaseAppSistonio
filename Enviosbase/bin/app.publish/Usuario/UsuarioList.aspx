<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioList.aspx.cs" Inherits="Enviosbase.Usuario.UsuarioList" %>

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
                                <i class="fas fa-user-friends text-primary"></i>
                            </span>
                            <h3 class="card-label">LISTADO USUARIOS</h3>
                        </div>
                        <div class="card-toolbar">
                            <asp:Button ID="btnNew" runat="server" Text="Nuevo Registro" CssClass="btn btn-primary" OnClick="btnNew_Click" />
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="col-lg-12">
                            <table id="example2" class="datatable datatable-bordered datatable-head-custom">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Nombres</th>
                                        <th>Apellidos</th>
                                        <th>UserLogin</th>
                                        <th>Correo</th>
                                        <th>Telefono</th>
                                        <th>TipoUsuario</th>
                                        <th>Fecha Registro</th>
                                        <th>Usuario</th>
                                        <th>Acciones</th>
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
    </form>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="BodyPlug">
    <script src="../src/js/components/datatable/core.datatable.js"></script>
    <script src="../assets/js/pages/crud/ktdatatable/base/html-table.js"></script>
</asp:Content>
