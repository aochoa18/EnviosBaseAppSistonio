var avatar5;

$(function () {
    var img = $('#MainContent_hdnFileImage').val();
    if (img != "")
        $('#kt_image_load').css("background-image", "url('" + img + "')");
    avatar5 = new KTImageInput('kt_image_5');
})

//avatar5.on('cancel', function (imageInput) {
//	swal.fire({
//		title: 'Image successfully changed !',
//		type: 'success',
//		buttonsStyling: false,
//		confirmButtonText: 'Awesome!',
//		confirmButtonClass: 'btn btn-primary font-weight-bold'
//	});
//});

//avatar5.on('change', function (imageInput) {
//	swal.fire({
//		title: 'Image successfully changed !',
//		type: 'success',
//		buttonsStyling: false,
//		confirmButtonText: 'Awesome!',
//		confirmButtonClass: 'btn btn-primary font-weight-bold'
//	});
//});

//avatar5.on('remove', function (imageInput) {
//	swal.fire({
//		title: 'Image successfully removed !',
//		type: 'error',
//		buttonsStyling: false,
//		confirmButtonText: 'Got it!',
//		confirmButtonClass: 'btn btn-primary font-weight-bold'
//	});
//});

function ValidarForm() {
    var str = "";
    debugger;
    if ($("#MainContent_txtNombre").val() == "") {
        str += "\n - Nombre";
    }
    if ($("#MainContent_txtDescripcion").val() == "") {
        str += "\n - Descripción";
    }
    if ($("#MainContent_txtPresentacion").val() == "") {
        str += "\n - Presentacion";
    }
    if ($("#MainContent_txtPrecio").val() == "") {
        str += "\n - Precio";
    }
    if ($("#MainContent_cbIdCategoria").val() == "") {
        str += "\n - Categoria";
    }
    if ($("#MainContent_txtCodigoSKU").val() == "") {
        str += "\n - Código SKU";
    }
    if ($("#MainContent_cbIdEstablecimiento").val() == "") {
        str += "\n - Establecimiento";
    }
    if ($("#MainContent_txtPrecioPromocion").val() == "") {
        str += "\n - Precio Promoción";
    }
    if ($("#MainContent_txtPorcentajePromocion").val() == "") {
        str += "\n - Procentaje Promoción";
    }
    if ($("#MainContent_txtCodigo").val() == "") {
        str += "\n - Código";
    }
    //if ($("#MainContent_hdnFileImage").val() == "") {
    //    str += "\n - Imagen";
    //}
    if (str != "") {
        cargaSweetError("Por favor verificar los siguientes campos:" + str, 1, 3000);
        return false;
    } else {
        $('#MainContent_btnSave').click();
    }
}