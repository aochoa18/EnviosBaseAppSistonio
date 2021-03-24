var avatar5;

$(function () {
    var img = $('#MainContent_hdnFileImage').val();
    if (img != "")
        $('#kt_image_load').css("background-image", "url('" + img + "')");
    avatar5 = new KTImageInput('kt_image_5');
})

$('#MainContent_txtDireccion').focus(function () {
    $('#staticBackdrop').modal('show');
});

var BuscarDireccion = function () {
    var address = $('#selDir1').val() + " " + $('#selDir2').val() + " # " + $('#selDir3').val() + " - " + $('#selDir4').val();
    $('#MainContent_txtDireccion').val(address);
    $('#staticBackdrop').modal('hide');
}

