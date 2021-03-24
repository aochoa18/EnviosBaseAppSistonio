<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoMasivo.aspx.cs" Inherits="Enviosbase.Producto.ProductoMasivo" %>

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
                                <i class="fas fa-camera text-primary"></i>
                            </span>
                            <h3 class="card-label">CARGUE DE PRODUCTOS</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <a class="card-title danger" href="../Archivos/BaseProductos.xlsx" download="BaseProductos"> Descargar archivo base</a>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <label>ARCHIVO</label>
                                <asp:FileUpload ID="fnArchivoCargue" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 ">
                                <label>IMAGENES</label>
                                <asp:FileUpload ID="fnImagenes" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-1" style="top:5px">
                                <br />
                                <asp:Button ID="btnUpload" CssClass="btn btn-primary" runat="server" Text="Cargar" OnClick="btnUpload_Click" />
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

    <script src="../src/js/components/datatable/core.datatable.js"></script>
    <script src="../assets/js/pages/crud/ktdatatable/base/html-table.js"></script>
</asp:Content>
