<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstablecimientoEdit.aspx.cs" Inherits="Enviosbase.Establecimiento.EstablecimientoEdit" EnableEventValidation="false" %>

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
                            <i class="flaticon2-notepad text-primary"></i>
                        </span>
                        <h3 class="card-label">ESTABLECIMIENTO</h3>
                    </div>
                    <%--<div class="card-toolbar">
                        <a href="#" class="btn btn-sm btn-success font-weight-bold">
                            <i class="flaticon2-cube"></i>Reports
                        </a>
                    </div>--%>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3" style="display: none">
                            <label class="control-label">Id</label>
                            <asp:Label ID="lbId" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Nombre</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 2)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">NIT</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Categoria</label><span style="color: red;">*</span>
                            <asp:DropDownList ID="cbIdCategoria" runat="server" CssClass="form-control m-b"></asp:DropDownList>
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
                        <%--<div class="col-lg-1">
                                <br />
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#staticBackdrop">
                                    Ingresar Dirección
                                </button>
                            </div>--%>
                        <div class="col-lg-3">
                            <label class="control-label">Dirección</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" onkeypress="return check(event, 2)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Reponsable</label><span style="color: red;">*</span>
                            <asp:DropDownList ID="cbIdResponsable" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-3">
                            <label class="control-label">Teléfono</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="7" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Celular</label><span style="color: red;">*</span>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return check(event, 3)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label class="control-label">Correo</label><span style="color: red;">*</span>
                            <input type="email" name="txtCorreo" id="txtCorreo" runat="server" class="form-control" onblur="caracteresCorreoValido($(this).val(), '#xmail')" />
                            <div id="xmail" style="display: none">
                                <h4 class="text-danger">Ingresa un email valido</h4>
                            </div>
                            <%--<asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>--%>
                        </div>
                        <asp:HiddenField ID="hdEstado" runat="server" />
                        <div class="col-lg-1">
                            <label class="control-label">Imagen</label>
                        </div>
                        <div class="col-lg-2">
                            <asp:HiddenField ID="hdnFileImage" runat="server" />
                            <div class="image-input image-input-empty image-input-outline" id="kt_image_5" style="background-image: url(../assets/media/products/23.png)">
                                <div class="image-input-wrapper" id="kt_image_load"></div>
                                <label class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="change" data-toggle="tooltip" title="" data-original-title="Cambiar imagen">
                                    <i class="fa fa-pen icon-sm text-muted"></i>
                                    <asp:FileUpload ID="fnImagen" runat="server" accept="image/x-png,image/gif,image/jpeg"></asp:FileUpload>
                                    <asp:HiddenField ID="hdnFileImage_remove" runat="server" />
                                </label>
                                <span class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="cancel" data-toggle="tooltip" title="Limpiar imagen">
                                    <i class="ki ki-bold-close icon-xs text-muted"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <span style="color: #515151; font-size: 11px">* Las imagenes cargadas deben ser en formato png, jpg - el tamaño de la misma será máximo de 200kb </span>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <label>HORARIOS </label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                         <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <label>Lunes</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioLunes" runat="server" readonly="readonly"  type="text" value="8:00:00" />
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinLunes" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <label>Martes</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioMartes" runat="server" readonly="readonly" value="8:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinMartes" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                         <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <label>Miercoles</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioMiercoles" runat="server" readonly="readonly" value="8:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinMiercoles" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <label>Jueves</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioJueves" runat="server" readonly="readonly" value="8:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinJueves" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                         <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <label>Viernes</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioViernes" runat="server" readonly="readonly" value="8:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinViernes" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <label>Sabado</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioSabado" runat="server" readonly="readonly" value="8:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinSabado" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <label>Domingo</label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraInicioDomingo" runat="server" readonly="readonly" value="8:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group timepicker">
                                <input class="form-control kt_timepicker_2" id="txtHoraFinDomingo" runat="server" readonly="readonly" value="18:00:00" type="text">
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-clock-o"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
                <div class="card-footer">
                    <div class="row">
                        <div class="col-md-9"></div>
                        <div class="col-md-3">
                            <asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                            <button id="btnValidate" type="button" onclick="ValidarFormulario()" class="btn btn-primary">Guardar</button>
                            <%if (lbId.Text != "")
                                {%>
                            <asp:Button ID="btnSendMail" CssClass="btn btn-primary" Text="Reenviar correo" OnClick="btnSendMail_Click" runat="server" />
                            <% } %>
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="hidden" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal-->
        <div class="modal fade" id="staticBackdrop" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdrop" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Escribe tu dirección de entrega</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <i aria-hidden="true" class="ki ki-close"></i>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6">
                                <select id="selDir1" aria-label="select-field" class="form-control">
                                    <option value="Calle">Calle </option>
                                    <option value="Carrera">Carrera </option>
                                    <option value="Autopista">Autopista </option>
                                    <option value="Avenida">Avenida </option>
                                    <option value="Avenida Carrera">Avenida Carrera </option>
                                    <option value="Avenida Calle">Avenida Calle </option>
                                    <option value="Circular">Circular </option>
                                    <option value="Circunvalar">Circunvalar </option>
                                    <option value="Diagonal">Diagonal </option>
                                    <option value="Manzana">Manzana </option>
                                    <option value="Transversal">Transversal </option>
                                    <option value="Vía">Vía </option>
                                </select>
                            </div>
                            <div class="col-md-6">
                                <input id="selDir2" aria-label="input-field" placeholder="23A Sur" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <input id="selDir3" aria-label="input-field" placeholder="# 00" class="form-control" />
                            </div>
                            <div class="col-md-6">
                                <input id="selDir4" aria-label="input-field" placeholder=" - 00" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-light-primary font-weight-bold" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-primary font-weight-bold" onclick="BuscarDireccion()">Guardar Dirección</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="BodyPlug" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="../Scripts/Custom/Establecimiento.js"></script>
    <script src="../Scripts/Custom/General.js"></script>
    <script>
        function ValidarFormulario() {
            var str = "";
            if ($("#MainContent_txtNombre").val() == "") {
                str += "\n - Nombre";
            }
            if ($("#MainContent_txtDocumento").val() == "") {
                str += "\n - NIT";
            }
            if ($("#MainContent_txtDireccion").val() == "") {
                str += "\n - Dirección";
            }
            if ($("#MainContent_cbIdPais").val() == "0") {
                str += "\n - Pais";
            }
            if ($("#MainContent_cbIdDepto").val() == "0") {
                str += "\n - Departamento";
            }
            if ($("#MainContent_cbIdMunicipio").val() == "0") {
                str += "\n - Municipio";
            }
            if ($("#MainContent_txtTelefono").val() == "") {
                str += "\n - Telefono";
            }
            if ($("#MainContent_txtCelular").val() == "") {
                str += "\n - Celular";
            }
            if ($("#MainContent_txtCorreo").val() == "") {
                str += "\n - Correo";
            }
            if ($("#MainContent_cbIdResponsable").val() == "") {
                str += "\n - Responsable";
            }
            if ($("#MainContent_cbIdCategoria").val() == "") {
                str += "\n - Categoria";
            }
            if ($("#MainContent_fnImagen").val() == "" && $("#MainContent_hdnFileImage").val() == "") {
                str += "\n - foto";
            }

            if (str != "") {
                cargaSweetError("Por favor verificar los siguientes campos:" + str, 1, 3000);
                return false;
            } else {
                $('#MainContent_btnSave').click();
            }
        }



    </script>
    <script src="../assets/js/pages/crud/forms/widgets/bootstrap-timepicker.min.js"></script>


</asp:Content>
