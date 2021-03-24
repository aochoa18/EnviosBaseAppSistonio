var rutaEstablecimiento = "";
var rutaEstablecimientoEdicion = "";
var rutaListas = "";

$(document).ready(function () {
    cargarMenuPorRol();
});

function cargarMenuPorRol() {

    var controles = '';

    controles += "<ul class=\"menu-nav\">";

    menuInicio = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Default.aspx\" class=\"menu-link\">" +
        "<span class=\"svg-icon svg-icon-primary menu-icon\">" +
        "<!--begin::Svg Icon | path:/metronic/theme/html/demo1/dist/assets/media/svg/icons/Design/Layers.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<polygon points=\"0 0 24 0 24 24 0 24\"></polygon>" +
        "<path d=\"M12.9336061,16.072447 L19.36,10.9564761 L19.5181585,10.8312381 C20.1676248,10.3169571 20.2772143,9.3735535 19.7629333,8.72408713 C19.6917232,8.63415859 19.6104327,8.55269514 19.5206557,8.48129411 L12.9336854,3.24257445 C12.3871201,2.80788259 11.6128799,2.80788259 11.0663146,3.24257445 L4.47482784,8.48488609 C3.82645598,9.00054628 3.71887192,9.94418071 4.23453211,10.5925526 C4.30500305,10.6811601 4.38527899,10.7615046 4.47382636,10.8320511 L4.63,10.9564761 L11.0659024,16.0730648 C11.6126744,16.5077525 12.3871218,16.5074963 12.9336061,16.072447 Z\" fill=\"#000000\" fill-rule=\"nonzero\"></path>" +
        "<path d=\"M11.0563554,18.6706981 L5.33593024,14.122919 C4.94553994,13.8125559 4.37746707,13.8774308 4.06710397,14.2678211 C4.06471678,14.2708238 4.06234874,14.2738418 4.06,14.2768747 L4.06,14.2768747 C3.75257288,14.6738539 3.82516916,15.244888 4.22214834,15.5523151 C4.22358765,15.5534297 4.2250303,15.55454 4.22647627,15.555646 L11.0872776,20.8031356 C11.6250734,21.2144692 12.371757,21.2145375 12.909628,20.8033023 L19.7677785,15.559828 C20.1693192,15.2528257 20.2459576,14.6784381 19.9389553,14.2768974 C19.9376429,14.2751809 19.9363245,14.2734691 19.935,14.2717619 L19.935,14.2717619 C19.6266937,13.8743807 19.0546209,13.8021712 18.6572397,14.1104775 C18.654352,14.112718 18.6514778,14.1149757 18.6486172,14.1172508 L12.9235044,18.6705218 C12.377022,19.1051477 11.6029199,19.1052208 11.0563554,18.6706981 Z\" fill=\"#000000\" opacity=\"0.3\"></path>" +
        "</g>" +
        "</svg>" +
        "<!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\"  > Inicio </span>" +
        "</a>" +
        "</li>";

    menuAdmin = "<li class=\"menu-section\">" +
        "<h4 class=\"menu-text\" >Administrador</h4>" +
        "<i class=\"menu-icon ki ki-bold-more-hor icon-md\"></i>" +
        "</li>";

    menuAdmin1 = "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"javascript:;\" class=\"menu-link menu-toggle\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\" >" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/Map/Position.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\" style=\"color:#DFFF00\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\" />" +
        "<path d=\"M19,11 L21,11 C21.5522847,11 22,11.4477153 22,12 C22,12.5522847 21.5522847,13 21,13 L19,13 C18.4477153,13 18,12.5522847 18,12 C18,11.4477153 18.4477153,11 19,11 Z M3,11 L5,11 C5.55228475,11 6,11.4477153 6,12 C6,12.5522847 5.55228475,13 5,13 L3,13 C2.44771525,13 2,12.5522847 2,12 C2,11.4477153 2.44771525,11 3,11 Z M12,2 C12.5522847,2 13,2.44771525 13,3 L13,5 C13,5.55228475 12.5522847,6 12,6 C11.4477153,6 11,5.55228475 11,5 L11,3 C11,2.44771525 11.4477153,2 12,2 Z M12,18 C12.5522847,18 13,18.4477153 13,19 L13,21 C13,21.5522847 12.5522847,22 12,22 C11.4477153,22 11,21.5522847 11,21 L11,19 C11,18.4477153 11.4477153,18 12,18 Z\" fill=\"#000000\" fill-rule=\"nonzero\" opacity=\"0.3\" />" +
        "<circle fill=\"#000000\" opacity=\"0.3\" cx=\"12\" cy=\"12\" r=\"2\" />" +
        "<path d=\"M12,17 C14.7614237,17 17,14.7614237 17,12 C17,9.23857625 14.7614237,7 12,7 C9.23857625,7 7,9.23857625 7,12 C7,14.7614237 9.23857625,17 12,17 Z M12,19 C8.13400675,19 5,15.8659932 5,12 C5,8.13400675 8.13400675,5 12,5 C15.8659932,5 19,8.13400675 19,12 C19,15.8659932 15.8659932,19 12,19 Z\" fill=\"#000000\" fill-rule=\"nonzero\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon--></span>" +
        "<span class=\"menu-text\" >Geografia</span>" +
        "<i class=\"menu-arrow\"></i>" +
        "</a>" +
        "<div class=\"menu-submenu\">" +
        "<ul class=\"menu-subnav\">" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/Pais/PaisList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Pais</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Departamento/DepartamentoList.aspx\" class=\"menu-link\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Departamento</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Municipio/MunicipioList.aspx\" class=\"menu-link\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Municipio</span>" +
        "</a>" +
        "</li>" +
        "</ul>" +
        "</div>" +
        "</li>";

    menuAdmin2 = "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"javascript:;\" class=\"menu-link menu-toggle\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/General/Clipboard.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\" />" +
        "<path d=\"M8,3 L8,3.5 C8,4.32842712 8.67157288,5 9.5,5 L14.5,5 C15.3284271,5 16,4.32842712 16,3.5 L16,3 L18,3 C19.1045695,3 20,3.8954305 20,5 L20,21 C20,22.1045695 19.1045695,23 18,23 L6,23 C4.8954305,23 4,22.1045695 4,21 L4,5 C4,3.8954305 4.8954305,3 6,3 L8,3 Z\" fill=\"#000000\" opacity=\"0.3\" />" +
        "<path d=\"M11,2 C11,1.44771525 11.4477153,1 12,1 C12.5522847,1 13,1.44771525 13,2 L14.5,2 C14.7761424,2 15,2.22385763 15,2.5 L15,3.5 C15,3.77614237 14.7761424,4 14.5,4 L9.5,4 C9.22385763,4 9,3.77614237 9,3.5 L9,2.5 C9,2.22385763 9.22385763,2 9.5,2 L11,2 Z\" fill=\"#000000\" />" +
        "<rect fill=\"#000000\" opacity=\"0.3\" x=\"7\" y=\"10\" width=\"5\" height=\"2\" rx=\"1\" />" +
        "<rect fill=\"#000000\" opacity=\"0.3\" x=\"7\" y=\"14\" width=\"9\" height=\"2\" rx=\"1\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon--></span>" +
        "<span class=\"menu-text\">Tipos</span>" +
        "<i class=\"menu-arrow\"></i>" +
        "</a>" +
        "<div class=\"menu-submenu\">" +
        "<ul class=\"menu-subnav\">" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/TipoVehiculo/TipoVehiculoList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Tipo Vehículo</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/TipoUsuario/TipoUsuarioList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Tipo Usuario</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/MedioPago/MedioPagoList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Medios de Pago</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/EstadoPedido/EstadoPedidoList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Estado Pedido</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/Marca/MarcaList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Marca</span>" +
        "</a>" +
        "</li>" +
        "</ul>" +
        "</div>" +
        "</li>";

    menuAdmin3 = "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"javascript:;\" class=\"menu-link menu-toggle\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/metronic/theme/html/demo1/dist/assets/media/svg/icons/Home/Library.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\"></rect>" +
        "<path d=\"M5,3 L6,3 C6.55228475,3 7,3.44771525 7,4 L7,20 C7,20.5522847 6.55228475,21 6,21 L5,21 C4.44771525,21 4,20.5522847 4,20 L4,4 C4,3.44771525 4.44771525,3 5,3 Z M10,3 L11,3 C11.5522847,3 12,3.44771525 12,4 L12,20 C12,20.5522847 11.5522847,21 11,21 L10,21 C9.44771525,21 9,20.5522847 9,20 L9,4 C9,3.44771525 9.44771525,3 10,3 Z\" fill=\"#000000\"></path>" +
        "<rect fill=\"#000000\" opacity=\"0.3\" transform=\"translate(17.825568, 11.945519) rotate(-19.000000) translate(-17.825568, -11.945519)\" x=\"16.3255682\" y=\"2.94551858\" width=\"3\" height=\"18\" rx=\"1\"></rect>" +
        "</g>" +
        "</svg>" +
        "<!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\">Categorias</span>" +
        "<i class=\"menu-arrow\"></i>" +
        "</a>" +
        "<div class=\"menu-submenu\">" +
        "<ul class=\"menu-subnav\">" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/CategoriaProducto/CategoriaProductoList.aspx\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Categorias Producto</span>" +
        "</a>" +
        "</li>" +
        //"<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        //"<a href=\"/CategoriaEstablecimiento/CategoriaEstablecimientoList.aspx\" class=\"menu-link menu-toggle\">" +
        //"<i class=\"menu-bullet menu-bullet-dot\">" +
        //"<span></span>" +
        //"</i>" +
        //"<span class=\"menu-text\">Categorias Establecimiento</span>" +
        //"</a>" +
        //"</li>" +
        "</ul>" +
        "</div>" +
        "</li>";
    menuAdmin4 = "";
    //menuAdmin4 = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
    //    "<a href=\"/Establecimiento/EstablecimientoList.aspx\" class=\"menu-link\">" +
    //    "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
    //    "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/Shopping/Cart2.svg-->" +
    //    "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
    //    "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
    //    "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\" />" +
    //    "<path d=\"M12,4.56204994 L7.76822128,9.6401844 C7.4146572,10.0644613 6.7840925,10.1217854 6.3598156,9.76822128 C5.9355387,9.4146572 5.87821464,8.7840925 6.23177872,8.3598156 L11.2317787,2.3598156 C11.6315738,1.88006147 12.3684262,1.88006147 12.7682213,2.3598156 L17.7682213,8.3598156 C18.1217854,8.7840925 18.0644613,9.4146572 17.6401844,9.76822128 C17.2159075,10.1217854 16.5853428,10.0644613 16.2317787,9.6401844 L12,4.56204994 Z\" fill=\"#000000\" fill-rule=\"nonzero\" opacity=\"0.3\" />" +
    //    "<path d=\"M3.28077641,9 L20.7192236,9 C21.2715083,9 21.7192236,9.44771525 21.7192236,10 C21.7192236,10.0817618 21.7091962,10.163215 21.6893661,10.2425356 L19.5680983,18.7276069 C19.234223,20.0631079 18.0342737,21 16.6576708,21 L7.34232922,21 C5.96572629,21 4.76577697,20.0631079 4.43190172,18.7276069 L2.31063391,10.2425356 C2.17668518,9.70674072 2.50244587,9.16380623 3.03824078,9.0298575 C3.11756139,9.01002735 3.1990146,9 3.28077641,9 Z M12,12 C11.4477153,12 11,12.4477153 11,13 L11,17 C11,17.5522847 11.4477153,18 12,18 C12.5522847,18 13,17.5522847 13,17 L13,13 C13,12.4477153 12.5522847,12 12,12 Z M6.96472382,12.1362967 C6.43125772,12.2792385 6.11467523,12.8275755 6.25761704,13.3610416 L7.29289322,17.2247449 C7.43583503,17.758211 7.98417199,18.0747935 8.51763809,17.9318517 C9.05110419,17.7889098 9.36768668,17.2405729 9.22474487,16.7071068 L8.18946869,12.8434035 C8.04652688,12.3099374 7.49818992,11.9933549 6.96472382,12.1362967 Z M17.0352762,12.1362967 C16.5018101,11.9933549 15.9534731,12.3099374 15.8105313,12.8434035 L14.7752551,16.7071068 C14.6323133,17.2405729 14.9488958,17.7889098 15.4823619,17.9318517 C16.015828,18.0747935 16.564165,17.758211 16.7071068,17.2247449 L17.742383,13.3610416 C17.8853248,12.8275755 17.5687423,12.2792385 17.0352762,12.1362967 Z\" fill=\"#000000\" />" +
    //    "</g>" +
    //    "</svg><!--end::Svg Icon-->" +
    //    "</span>" +
    //    "<span class=\"menu-text\">Establecimientos</span>" +
    //    "</a>" +
    //    "</li>";

    menuAdmin5 = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Usuario/UsuarioList.aspx\" class=\"menu-link\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/General/User.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<polygon points=\"0 0 24 0 24 24 0 24\" />" +
        "<path d=\"M12,11 C9.790861,11 8,9.209139 8,7 C8,4.790861 9.790861,3 12,3 C14.209139,3 16,4.790861 16,7 C16,9.209139 14.209139,11 12,11 Z\" fill=\"#000000\" fill-rule=\"nonzero\" opacity=\"0.3\" />" +
        "<path d=\"M3.00065168,20.1992055 C3.38825852,15.4265159 7.26191235,13 11.9833413,13 C16.7712164,13 20.7048837,15.2931929 20.9979143,20.2 C21.0095879,20.3954741 20.9979143,21 20.2466999,21 C16.541124,21 11.0347247,21 3.72750223,21 C3.47671215,21 2.97953825,20.45918 3.00065168,20.1992055 Z\" fill=\"#000000\" fill-rule=\"nonzero\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\">Usuarios</span>" +
        "</a>" +
        "</li>";

    menuAdmin5 = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Domiciliario/DomiciliarioList.aspx\" class=\"menu-link\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\"><!--begin::Svg Icon | path:C:\wamp64\www\keenthemes\themes\metronic\theme\html\demo5\dist/../src/media/svg/icons\Communication\Shield-user.svg--><svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\"/>" +
        "<path d=\"M4,4 L11.6314229,2.5691082 C11.8750185,2.52343403 12.1249815,2.52343403 12.3685771,2.5691082 L20,4 L20,13.2830094 C20,16.2173861 18.4883464,18.9447835 16,20.5 L12.5299989,22.6687507 C12.2057287,22.8714196 11.7942713,22.8714196 11.4700011,22.6687507 L8,20.5 C5.51165358,18.9447835 4,16.2173861 4,13.2830094 L4,4 Z\" fill=\"#000000\" opacity=\"0.3\"/>" +
        "<path d=\"M12,11 C10.8954305,11 10,10.1045695 10,9 C10,7.8954305 10.8954305,7 12,7 C13.1045695,7 14,7.8954305 14,9 C14,10.1045695 13.1045695,11 12,11 Z\" fill=\"#000000\" opacity=\"0.3\"/>" +
        "<path d=\"M7.00036205,16.4995035 C7.21569918,13.5165724 9.36772908,12 11.9907452,12 C14.6506758,12 16.8360465,13.4332455 16.9988413,16.5 C17.0053266,16.6221713 16.9988413,17 16.5815,17 C14.5228466,17 11.463736,17 7.4041679,17 C7.26484009,17 6.98863236,16.6619875 7.00036205,16.4995035 Z\" fill=\"#000000\" opacity=\"0.3\"/>" +
        "</g>" +
        "</svg><!--end::Svg Icon--></span>" +
        "<span class=\"menu-text\">Domiciliarios</span>" +
        "</a>" +
        "</li>";

    menuAdmin6 = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Responsable/ResponsableList.aspx\" class=\"menu-link\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/General/User.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<polygon points=\"0 0 24 0 24 24 0 24\" />" +
        "<path d=\"M12,11 C9.790861,11 8,9.209139 8,7 C8,4.790861 9.790861,3 12,3 C14.209139,3 16,4.790861 16,7 C16,9.209139 14.209139,11 12,11 Z\" fill=\"#000000\" fill-rule=\"nonzero\" opacity=\"0.3\" />" +
        "<path d=\"M3.00065168,20.1992055 C3.38825852,15.4265159 7.26191235,13 11.9833413,13 C16.7712164,13 20.7048837,15.2931929 20.9979143,20.2 C21.0095879,20.3954741 20.9979143,21 20.2466999,21 C16.541124,21 11.0347247,21 3.72750223,21 C3.47671215,21 2.97953825,20.45918 3.00065168,20.1992055 Z\" fill=\"#000000\" fill-rule=\"nonzero\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\">Responsables</span>" +
        "</a>" +
        "</li>";

    menuAdmin7 = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Cliente/ClienteList.aspx\" class=\"menu-link\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/General/Smile.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<polygon points=\"0 0 24 0 24 24 0 24\" />" +
        "<path d=\"M12,11 C9.790861,11 8,9.209139 8,7 C8,4.790861 9.790861,3 12,3 C14.209139,3 16,4.790861 16,7 C16,9.209139 14.209139,11 12,11 Z\" fill=\"#000000\" fill-rule=\"nonzero\" opacity=\"0.3\" />" +
        "<path d=\"M3.00065168,20.1992055 C3.38825852,15.4265159 7.26191235,13 11.9833413,13 C16.7712164,13 20.7048837,15.2931929 20.9979143,20.2 C21.0095879,20.3954741 20.9979143,21 20.2466999,21 C16.541124,21 11.0347247,21 3.72750223,21 C3.47671215,21 2.97953825,20.45918 3.00065168,20.1992055 Z\" fill=\"#000000\" fill-rule=\"nonzero\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\">Clientes</span>" +
        "</a>" +
        "</li>";

    menuEstab = "<li class=\"menu-section\">" +
        "<h4 class=\"menu-text\">Establecimiento</h4>" +
        "<i class=\"menu-icon ki ki-bold-more-hor icon-md\"></i>" +
        "</li>";

    menuEstab1 = "<li class=\"menu-item\" aria-haspopup=\"true\">" +
        "<a href=\"/Producto/ProductoList.aspx\" class=\"menu-link\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/General/User.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\" />" +
        "<path d=\"M6.5,16 L7.5,16 C8.32842712,16 9,16.6715729 9,17.5 L9,19.5 C9,20.3284271 8.32842712,21 7.5,21 L6.5,21 C5.67157288,21 5,20.3284271 5,19.5 L5,17.5 C5,16.6715729 5.67157288,16 6.5,16 Z M16.5,16 L17.5,16 C18.3284271,16 19,16.6715729 19,17.5 L19,19.5 C19,20.3284271 18.3284271,21 17.5,21 L16.5,21 C15.6715729,21 15,20.3284271 15,19.5 L15,17.5 C15,16.6715729 15.6715729,16 16.5,16 Z\" fill=\"#000000\" opacity=\"0.3\" />" +
        "<path d=\"M5,4 L19,4 C20.1045695,4 21,4.8954305 21,6 L21,17 C21,18.1045695 20.1045695,19 19,19 L5,19 C3.8954305,19 3,18.1045695 3,17 L3,6 C3,4.8954305 3.8954305,4 5,4 Z M15.5,15 C17.4329966,15 19,13.4329966 19,11.5 C19,9.56700338 17.4329966,8 15.5,8 C13.5670034,8 12,9.56700338 12,11.5 C12,13.4329966 13.5670034,15 15.5,15 Z M15.5,13 C16.3284271,13 17,12.3284271 17,11.5 C17,10.6715729 16.3284271,10 15.5,10 C14.6715729,10 14,10.6715729 14,11.5 C14,12.3284271 14.6715729,13 15.5,13 Z M7,8 L7,8 C7.55228475,8 8,8.44771525 8,9 L8,11 C8,11.5522847 7.55228475,12 7,12 L7,12 C6.44771525,12 6,11.5522847 6,11 L6,9 C6,8.44771525 6.44771525,8 7,8 Z\" fill=\"#000000\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\">Productos</span>" +
        "</a>" +
        "</li>";

    menuEstab2 = "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"javascript:;\" class=\"menu-link menu-toggle\">" +
        "<span class=\"svg-icon svg-icon-primary svg-icon-2x\">" +
        "<!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-25-063451/theme/html/demo5/dist/../src/media/svg/icons/General/User.svg-->" +
        "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">" +
        "<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">" +
        "<rect x=\"0\" y=\"0\" width=\"24\" height=\"24\" />" +
        "<path d=\"M6.5,16 L7.5,16 C8.32842712,16 9,16.6715729 9,17.5 L9,19.5 C9,20.3284271 8.32842712,21 7.5,21 L6.5,21 C5.67157288,21 5,20.3284271 5,19.5 L5,17.5 C5,16.6715729 5.67157288,16 6.5,16 Z M16.5,16 L17.5,16 C18.3284271,16 19,16.6715729 19,17.5 L19,19.5 C19,20.3284271 18.3284271,21 17.5,21 L16.5,21 C15.6715729,21 15,20.3284271 15,19.5 L15,17.5 C15,16.6715729 15.6715729,16 16.5,16 Z\" fill=\"#000000\" opacity=\"0.3\" />" +
        "<path d=\"M5,4 L19,4 C20.1045695,4 21,4.8954305 21,6 L21,17 C21,18.1045695 20.1045695,19 19,19 L5,19 C3.8954305,19 3,18.1045695 3,17 L3,6 C3,4.8954305 3.8954305,4 5,4 Z M15.5,15 C17.4329966,15 19,13.4329966 19,11.5 C19,9.56700338 17.4329966,8 15.5,8 C13.5670034,8 12,9.56700338 12,11.5 C12,13.4329966 13.5670034,15 15.5,15 Z M15.5,13 C16.3284271,13 17,12.3284271 17,11.5 C17,10.6715729 16.3284271,10 15.5,10 C14.6715729,10 14,10.6715729 14,11.5 C14,12.3284271 14.6715729,13 15.5,13 Z M7,8 L7,8 C7.55228475,8 8,8.44771525 8,9 L8,11 C8,11.5522847 7.55228475,12 7,12 L7,12 C6.44771525,12 6,11.5522847 6,11 L6,9 C6,8.44771525 6.44771525,8 7,8 Z\" fill=\"#000000\" />" +
        "</g>" +
        "</svg><!--end::Svg Icon-->" +
        "</span>" +
        "<span class=\"menu-text\">Pedidos</span>" +
        "<i class=\"menu-arrow\"></i>" +
        "</a>" +
        "<div class=\"menu-submenu\">" +
        "<ul class=\"menu-subnav\">" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/Pedido/PedidoList.aspx?IdEstado=1\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Pedidos Solicitados</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/Pedido/PedidoList.aspx?IdEstado=3\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Pedidos En Proceso</span>" +
        "</a>" +
        "</li>" +
        "<li class=\"menu-item menu-item-submenu\" aria-haspopup=\"true\" data-menu-toggle=\"hover\">" +
        "<a href=\"/Pedido/PedidoList.aspx?IdEstado=5\" class=\"menu-link menu-toggle\">" +
        "<i class=\"menu-bullet menu-bullet-dot\">" +
        "<span></span>" +
        "</i>" +
        "<span class=\"menu-text\">Pedidos En Finalizados</span>" +
        "</a>" +
        "</li>" +
        "</ul>" +
        "</div>" +
        "</li>";

    controles += menuInicio;
    switch (parseInt($("#lblIdRol").val())) {
        case 1:
            controles += menuAdmin;
            controles += menuAdmin1;
            controles += menuAdmin2;
            controles += menuAdmin3;
            controles += menuAdmin4;
            controles += menuAdmin5;
            controles += menuAdmin6;
            controles += menuAdmin7;
            break;
        case 2:
        case 3:
            controles += menuEstab;
            controles += menuEstab1;
            controles += menuEstab2;
            break;
    }

    controles += "</ul >";

    document.getElementById('kt_aside_menu').innerHTML = controles;
}
