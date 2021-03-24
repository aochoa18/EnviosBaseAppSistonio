<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoEdit.aspx.cs" Inherits="Enviosbase.Producto.ProductoEdit" %>

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
                        <div class="col-lg-3">
                            <label class=" control-label">Id</label>
                            <asp:Label ID="lbId" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 2)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="1000" onkeypress="return check(event, 1)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Presentación</label>
                            <asp:TextBox ID="txtPresentacion" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 1)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <label class="control-label">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Categoría</label>
                            <asp:DropDownList ID="cbIdCategoria" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Codígo SKU</label>
                            <asp:TextBox ID="txtCodigoSKU" runat="server" CssClass="form-control" MaxLength="15" onkeypress="return check(event, 1)">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Precio Promoción</label>
                            <asp:TextBox ID="txtPrecioPromocion" runat="server" CssClass="form-control" MaxLength="15" onkeypress="return check(event, 3)">0</asp:TextBox>
                        </div>
                        <%--<div class="col-lg-3">
                            <label class="control-label">Establecimiento</label>
                            <asp:DropDownList ID="cbIdEstablecimiento" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>--%>
                        <asp:HiddenField ID="hdEstado" runat="server" />
                        <asp:HiddenField ID="hdIdEstablecimiento" runat="server" />
                    </div>
                    <div class="row">

                        <div class="col-lg-3">
                            <label class="control-label">Porcentaje Promoción</label>
                            <asp:TextBox ID="txtPorcentajePromocion" runat="server" CssClass="form-control" MaxLength="2" onkeypress="return check(event, 3)">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Codígo</label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" MaxLength="15" onkeypress="return check(event, 1)">0</asp:TextBox>
                        </div>
                    </div>
                    <br />
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
                                    <asp:FileUpload ID="fnImagen" runat="server" accept="image/x-png,image/gif,image/jpeg"></asp:FileUpload>
                                    <asp:HiddenField ID="fnImagen_remove" runat="server" />
                                </label>
                                <span class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="cancel" data-toggle="tooltip" title="Limpiar imagen">
                                    <i class="ki ki-bold-close icon-xs text-muted"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <span style="color: #C2C2C2; font-size: 11px">* Las imagenes cargadas deben ser en formato png, jpg - el tamaño de la misma será máximo de 200kb </span>
                        </div>
                    </div>

                    <br />
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
    <script src="../assets/plugins/global/plugins.bundle.js"></script>
    <script src="../assets/plugins/custom/prismjs/prismjs.bundle.js"></script>
    <script src="../assets/js/scripts.bundle.js"></script>
    <script src="../Scripts/Custom/General.js"></script>
    <script src="../Scripts/Custom/Producto.js"></script>
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
</asp:Content>
