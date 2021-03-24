<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoEdit.aspx.cs" Inherits="Enviosbase.Pedido.PedidoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="fas fa-camera text-primary"></i>
                        </span>
                        <h3 class="card-label">PRODUCTO</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-3">
                            <label class="control-label">Id Pedido</label>
                            <asp:Label ID="lbId" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Cliente</label>
                            <asp:DropDownList ID="cbIdCliente" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Metodo de Pago</label>
                            <asp:TextBox ID="txtMetodoPago" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Dirección de entrega</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label class="control-label">Pais</label>
                            <asp:DropDownList ID="cbIdPais" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Departamento</label>
                            <asp:DropDownList ID="cbIdDepto" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Municipio</label>
                            <asp:DropDownList ID="cbIdMunicipio" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Observaciones</label>
                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label class="control-label">Fecha de Entrega</label>
                            <asp:TextBox type="date" ID="txtFechaEntrega" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Estado Pedido</label>
                            <asp:DropDownList ID="cbIdEstadoPedido" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <asp:HiddenField ID="hdEstado" runat="server" />
                        <div class="col-3 form-group">
                            <label class="control-label">Fecha Registro</label>
                            <div class="input-group date datetimepicker" id="datetimepicker2">
                                <div class="input-group-prepend">
                                    <span class="input-group-text fa fa-calendar"></span>
                                </div>
                                <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Domiciliario</label>
                            <asp:DropDownList ID="cbIdDomiciliario" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-4">
                            <div class="input-icon">
                                <input type="text" class="form-control" placeholder="Buscar..." id="example2_search_query">
                                <span><i class="flaticon2-search-1 text-muted"></i></span>
                            </div>
                        </div>
                        <!--begin::Dropdown-->
                        <div class="col-md-4 dropdown dropdown-inline mr-2">
                            <asp:Button CssClass="btn btn-primary" Text="Exportar Excel" runat="server" ID="btnExcel" OnClick="btnExcel_Click">
                                <%--<span class="svg-icon svg-icon-md">
                                    <i class="la la-file-excel-o"></i>
                                </span>Exportar Excel--%>
                            </asp:Button>
                        </div>
                        <!--end::Dropdown-->
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12">
                            <table id="example2" class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Producto</th>
                                        <th>Cantidad</th>
                                        <th>Precio</th>
                                        <th>Precio Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltTableItems" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
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
    <script src="../assets/js/pages/crud/ktdatatable/base/html-table.js"></script>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <script src="../assets/plugins/custom/datatables/datatables.bundle.js"></script>
    <script>
        function ValidarForm() {
            $('#MainContent_btnSave').click();
        }
    </script>
</asp:Content>
