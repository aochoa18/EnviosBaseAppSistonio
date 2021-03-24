function cargaSweetError(mensaje, tipo, tiempo) {
    switch (tipo) {
        case 1:
            swal.fire({ title: mensaje, icon: "warning", text: "", timer: tiempo, showConfirmButton: false, });
            break;
        case 2:
            swal.fire({ title: mensaje, icon: "error", text: "", timer: tiempo, showConfirmButton: false, });
            break;
        case 3:
            swal.fire({ title: mensaje, icon: "info", text: "", timer: tiempo, showConfirmButton: false, });
            break;
        case 4:
            swal.fire({ title: mensaje, icon: "success", text: "", timer: tiempo, showConfirmButton: false, });
            break;
    }
}

var cargaDataCB = function (url) {
    var item = [];
    $.ajax({
        type: "GET",
        dataType: "json",
        async: false,
        url: url,
        async: false,
        success: function (data) {
            item = data
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
    return item;
}


//#region CARGA COMBO


var cargaCombo = function (url, control, tipo) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: function (data) {
            if (tipo == "1")
                llenarCombo(data, control);
            else
                llenarComboConSeleccion(data, control);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
}

var llenarCombo = function (data, control) {
    $("#" + control).empty();
    $.each(data, function (i, row) {
        $("#" + control).append("<option value=\"" + row.Id + "\">" + row.Nombre + "</option>");
    });
}

var llenarComboConSeleccion = function (data, control) {
    $("#" + control).empty();
    $.each(data, function (i, row) {
        $("#" + control).append("<option value=\"" + row.Id + "\">" + row.Nombre + "</option>");
    });
    $("#" + control).append("<option value=\"" + 0 + "\">Seleccione...</option>");
    $("#" + control).val(0);
}

var llenarComboCB = function (data, control) {
    var lista = [];
    lista = JSON.parse(data.d);
    $("#" + control).empty();
    $.each(lista, function (i, row) {
        $("#" + control).append("<option value=\"" + row.Id + "\">" + row.Nombre + "</option>");
    });
}

var llenarComboConSeleccionCB = function (data, control) {
    var lista = [];
    lista = JSON.parse(data.d);
    $("#" + control).empty();
    $.each(lista, function (i, row) {
        $("#" + control).append("<option value=\"" + row.Id + "\">" + row.Nombre + "</option>");
    });
    $("#" + control).append("<option value=\"" + 0 + "\">Seleccione...</option>");
    $("#" + control).val(0);
}

var cargaComboCB = function (url, pTabla, control, tipo) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ tabla: pTabla }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (tipo == "1")
                llenarComboCB(data, control);
            else
                llenarComboConSeleccionCB(data, control);
        },
        error: function (jqXHR, exception) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
}

var cargaGeografiaPaisCB = function (url, control, tipo) {
    $.ajax({
        type: "GET",
        url: url,
        data: JSON.stringify({ tabla: pTabla }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (tipo == "1")
                llenarComboCB(data, control);
            else
                llenarComboConSeleccionCB(data, control);
        },
        error: function (jqXHR, exception) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
}

var cargaGeografiaDepartamentoCB = function (url, pPais, control, tipo) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ idPais: pPais }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (tipo == "1")
                llenarComboCB(data, control);
            else
                llenarComboConSeleccionCB(data, control);
        },
        error: function (jqXHR, exception) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
}

var cargaGeografiaMunicipioCB = function (url, pDepto, control, tipo) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ idDepto: pDepto }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            if (tipo == "1")
                llenarComboCB(data, control);
            else
                llenarComboConSeleccionCB(data, control);
        },
        error: function (jqXHR, exception) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
}
//#endregion

function insertarRegistroEnTabla(listaRecibida, objetoRecibido, edita) {
    var contador = 0;
    editarRegistro = edita;
    objeto = objetoRecibido;

    if (listaRecibida.length > 0) {
        $.each(listaRecibida, function (i, row) {
            if (row.ID == objeto.ID) {
                contador++;
            }
        });
    }
    if (contador > 0) {
        for (var i = 0; i < listaRecibida.length; i++) {
            if (listaRecibida[i].ID == objeto.ID) {
                listaRecibida.splice(i, 1);
            }
        }
    }
    if (contador == 0) {
        listaRecibida.push(objeto);
        return listaRecibida;
    }
    if (contador > 0 && editarRegistro == 1) {
        listaRecibida.push(objeto);
        return listaRecibida;
    }
}

function cambiarClaseValores(control, inicial, final) {
    $("#" + control).removeClass(inicial);
    $("#" + control).addClass(final);
}

//#region CAMBIOS EN CONTROLES

function resetCombo(control, valor) {
    $('#' + control).select2().val(valor).trigger('change.select2');
}

function resetSwitch(control) {
    $('#' + control).bootstrapSwitch('toogleState', true);
}

function resetIcheck(control) {
    $('Input#' + control).ICheck('check');
}


//#endregion

//#region CONVERSIONES

function curToFloat(val) {
    val = val.replace(/\./g, "");
    val = val.replace(/\$/g, "");
    val = val.replace(/\_/g, "");
    val = val.replace(/\,/g, ".");
    val = val.replace(' ', "");
    return val;
}

//function curToFloat(val) {
//    val = val.replace(/\./g, "");
//    val = val.replace(/\$/g, "");
//    val = val.replace(/\_/g, "");
//    val = val.replace(/\,/g, ".");
//    val = val.replace(' ', "");
//    return val;
//}


function curToFloatMoney(val) {
    val = val.replace(/\./g, ",");
    val = val.replace(' ', "");
    val = val.replace(/[^0-9\.-]+/g, "")
    val = val.slice(0, -2);
    return val;
}

function curToString(val) {
    val = val.replace(/\(/g, "");
    val = val.replace(/\)/g, "");
    val = val.replace(/\-/g, "");
    val = val.replace(/\_/g, "");
    val = val.replace(' ', "");
    return val;
}

//#endregion

function formatCurrency(total) {
    var neg = false;
    if (total < 0) {
        neg = true;
        total = Math.abs(total);
    }
    return (neg ? "-$" : '$') + parseFloat(total, 12).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1.").toString();
}

function formatCurrencyInt(total) {
    var neg = false;
    var valor;
    if (total < 0) {
        neg = true;
        total = Math.abs(total);
    }

    return (neg ? "-$" : '$') + total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
    //valor = (neg ? "-$" : '$') + parseFloat(total, 12).toFixed(1).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();

    //var cadena = valor, separador = ".", arregloDeSubCadenas = cadena.split(separador);
    //valor = arregloDeSubCadenas[0];
    //valor = valor.replace(",", ".");
    //return valor;
}

function formatCurrencyDec(total) {
    var neg = false;
    var valor;
    if (total < 0) {
        neg = true;
        total = Math.abs(total);
    }
    valor = (neg ? "-$" : '$') + parseFloat(total, 12).toFixed(3).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();
    return valor.replace(".", ",");
}

function formatCurrencyDec2(total) {
    var neg = false;
    if (total < 0) {
        neg = true;
        total = Math.abs(total);
    }
    return (neg ? "-$" : '$') + parseFloat(total, 12).toFixed(3).replace(/(\d)(?=(\d{3})+\.)/g, "$1.").toString();
}


function CargarArchivos(idSujeto, menu, rol, tabla) {
    var host = $("#BodyContent_hdfHostRest").val();
    var data = cargaData(host + '/' + _WcfAGServicesDesarrollo + '/Services/AGService.svc/rest/ConsultarDatosArchivosPorIdTipo/' + idSujeto + '/' + menu + '/' + rol);

    $('#' + tabla).DataTable({
        "bFilter": false,
        "destroy": true,
        "aaData": data,
        "aoColumns": [
            { "title": "Archivo", "mData": "Nombre" },
            { "title": "Tipo", "mData": "NombreTipoArchivo" },
            { "title": "Fecha", "mData": "FechaRegistro" },
            {
                "title": "", "mRender": function (data, type, full) {
                    var ruta = host + '/Optimus/' + full.CarpetaGeneralArchivo + '/' + idSujeto + '/' + full.Nombre
                    return "<a class=\"btn btn-succ/ess btn-circle btn-icon-only\" data-toggle=\"tooltip\" title=\"Descargar\" onclick=\"DescargarArchivo('" + ruta + "')\"> <i class='icon-cloud-download'></i> </a>";
                }
            }
        ],
        "iDisplayLength": 3
    });
}

function DescargarArchivo(ruta) {
    window.open(ruta);
}

var cargaData = function (url) {
    var item = [];
    $.ajax({
        type: "GET",
        dataType: "json",
        async: false,
        url: url,
        async: false,
        success: function (data) {
            item = data
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
        }
    });
    return item;
}

//#region CARGAR TABLAS

function CargarTablaGeneral(data, dataSet, tabla, tipo) {
    var column = GetEncabezados(data);
    $('#' + tabla).DataTable({
        "bFilter": true,
        "destroy": true,
        "aaData": dataSet,
        "aoColumns": column
    });
}

function GetEncabezados(data) {
    var columns = [];
    for (var i = 0; i < 1; i++) {
        for (var key in data[i]) {
            columns.push({ 'title': key.toString(), 'mData': key.toString() });
        }
    }
    return columns;
}

//#endregion

function nobackbutton() {
    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button";//chrome	
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
}

function valida(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    //Tecla de retroceso para borrar, siempre la permite
    if (tecla == 8) {
        return true;
    }

    // Patron de entrada, en este caso solo acepta numeros
    patron = /[0-9]/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}

function cargaSweetErrorIframe(mensaje, tipo, tiempo, mensajeSpan) {
    switch (tipo) {
        case 1:
            swal({ title: mensaje, type: "warning", text: "", timer: tiempo, showConfirmButton: false, });
            break;
        case 2:
            swal({ title: mensaje, type: "error", text: "", timer: tiempo, showConfirmButton: false, });
            break;
        case 3:
            swal({ title: mensaje, type: "info", text: "", timer: tiempo, showConfirmButton: false, });
            break;
        case 4:
            swal({ title: mensaje, type: "success", text: "", timer: tiempo, showConfirmButton: false, });
            break;
    }
    CargarListaDocumentos(mensajeSpan);
}

function convertirFecha(fecha) {

    var dma = "m";
    var intervalo = 3;
    var fecha = fecha;
    var nuevaFecha;
    var separador = "/" || "-";
    var arrayFecha = fecha.split(separador);
    var dia = arrayFecha[1];
    var mes = arrayFecha[0];
    var anio = arrayFecha[2];

    if (mes.length < 2) mes = '0' + mes;
    if (dia.length < 2) dia = '0' + dia;

    nuevaFecha = anio + "/" + mes + "/" + dia;

    return nuevaFecha;

}

function convertirFecha2(fecha) {

    var dma = "m";
    var intervalo = 3;
    var fecha = fecha;
    var nuevaFecha;
    var separador = "/" || "-";
    var arrayFecha = fecha.split(separador);
    var dia = arrayFecha[0];
    var mes = arrayFecha[1];
    var anio = arrayFecha[2];

    if (mes.length < 2) mes = '0' + mes;
    if (dia.length < 2) dia = '0' + dia;

    nuevaFecha = anio + "/" + mes + "/" + dia;

    return nuevaFecha;

}

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('/');
}

function cierreSession(mensaje) {
    swal({ title: mensaje, type: "error", text: "", showConfirmButton: true }, function (isConfirm) {
        if (isConfirm) {
            document.location.href = "Login.aspx";
        }
    });
}


function cambiarContraseñaGral() {
    $('#modalContrasenaMaster').modal('show');
}

function confirmarContrasenaMaster() {
    var Nuevacontrasena = $('#txtNuevaClave').val();
    var Confcontrasena = $('#txtConfirmaClave').val();
    if (Nuevacontrasena != Confcontrasena) {
        cargaSweetError("Las contraseñas no coinciden", 2, 3500);
        return false;
    }
}

function cambiarContrasenaMaster() {
    var Nuevacontrasena = $('#txtNuevaClave').val();
    $.ajax({
        type: "POST",
        url: "Login.aspx/CambiarContrasena",
        data: JSON.stringify({ password: Nuevacontrasena }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var result = data;
            if (result.d != '0') {
                cargaSweetError("Las contraseña se cambio correctamente", 3, 2500);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
        }
    });
}


function validarContrasena() {
    var valido2 = document.getElementById('campoOK2');
    valido = document.getElementById('campoOK'),
        regex = /^(?=.*\d)(?=.*[a-záéíóúüñ]).*[A-ZÁÉÍÓÚÜÑ]/;

    var longitud = $('#txtNuevaClave').val().length;

    if (regex.test($('#txtNuevaClave').val()) && (longitud >= 8 && longitud <= 12)) {
        $('#campoOK2').css({ color: "green" });
        valido2.innerText = "Ok";
        valido.innerText = "";
        $('#txtConfirmaClave').css({ display: "block" });
    } else {
        $('#campoOK').css({ color: "red" });
        valido.innerText = "Mínimo 8 caracteres y máxmo 12, debe tener al menos una mayúscula y un número";
        $('#txtConfirmaClave').css({ display: "none" });
    }
}

var getUrlVars = function () {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}


function ajax_icon_handling(message, type) {
    switch (type) {
        case 'load':
            swal.fire({
                title: '',
                html: '<div class="save_loading"><svg viewBox="0 0 140 140" width="140" height="140"><g class="outline"><path d="m 70 28 a 1 1 0 0 0 0 84 a 1 1 0 0 0 0 -84" stroke="rgba(0,0,0,0.1)" stroke-width="4" fill="none" stroke-linecap="round" stroke-linejoin="round"></path></g><g class="circle"><path d="m 70 28 a 1 1 0 0 0 0 84 a 1 1 0 0 0 0 -84" stroke="#71BBFF" stroke-width="4" fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-dashoffset="200" stroke-dasharray="300"></path></g></svg></div><br /><div><h4>' + message + '</h4></div>',
                showConfirmButton: false,
                allowOutsideClick: false
            });
            break;
        case false:
            setTimeout(function () {
                $('#swal2-content').html('<div class="sa"><div class="sa-error"><div class="sa-error-x"><div class="sa-error-left"></div><div class="sa-error-right"></div></div><div class="sa-error-placeholder"></div><div class="sa-error-fix"></div></div></div><br /><div><h4>' + message + '</h4></div><button class="swal2-confirm btn btn-error" onClick="swal.closeModal()" style="display: inline-block;">OK</button>');
            }, 1000);
            $('.swal-close').click(function () { swal.closeModal(); });
            break;
        case true:
            setTimeout(function () {
                $('#swal2-content').html('<div class="sa"><div class="sa-success"><div class="sa-success-tip"></div><div class="sa-success-long"></div><div class="sa-success-placeholder"></div><div class="sa-success-fix"></div></div></div><br /><div><h4>' + message + '</h4></div>');
            }, 1000);
            setTimeout(function () {
                swal.closeModal();
            }, 3000);
            break;
    }
}



function check(e, tipo) {
    tecla = (document.all) ? e.keyCode : e.which;

    //Tecla de retroceso para borrar, siempre la permite
    if (tecla == 8 || tecla == 32) {
        return true;
    }

    switch (tipo) {
        // alfanumerico
        case 1:
            patron = /[,áéíóúñA-Za-z0-9]/;
            tecla_final = String.fromCharCode(tecla);
            return patron.test(tecla_final);
            break;
        // alfabetico
        case 2:
            var key = e.keyCode || e.which,
                tecla = String.fromCharCode(key).toLowerCase(),
                letras = " áéíóúabcdefghijklmnñopqrstuvwxyz",
                especiales = [8, 37, 39, 46],
                tecla_especial = false;

            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
            break;
        // numerico
        case 3:
            var key = e.keyCode || e.which,
                tecla = String.fromCharCode(key).toLowerCase(),
                letras = "1234567890",
                especiales = [8, 37, 39, 46],
                tecla_especial = false;

            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
            break;
            break;
    }

    // Patron de entrada, en este caso solo acepta numeros y letras

}


function caracteresCorreoValido(email, div) {
    console.log(email);

    var caract = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/);

    if (!caract.test(email)) {
        $(div).css("display", "block");
        return false;
    } else {
        $(div).css("display", "none");
        return true;
    }
}