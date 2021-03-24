<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Enviosbase.Login" %>

<!DOCTYPE html>

<html lang="en">
<!--begin::Head-->
<head>
    <!-- Google Tag Manager -->
    <script async="" src="https://www.googletagmanager.com/gtm.js?id=GTM-5FS8GGP"></script>
    <script>(function (w, d, s, l, i) { w[l] = w[l] || []; w[l].push({ 'gtm.start': new Date().getTime(), event: 'gtm.js' }); var f = d.getElementsByTagName(s)[0], j = d.createElement(s), dl = l != 'dataLayer' ? '&amp;l=' + l : ''; j.async = true; j.src = 'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f); })(window, document, 'script', 'dataLayer', 'GTM-5FS8GGP');</script>
    <!-- End Google Tag Manager -->
    <meta charset="utf-8">
    <title>Login | Frubit</title>
    <meta name="description" content="Login page example">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="canonical" href="https://keenthemes.com/metronic">
    <!--begin::Fonts-->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700">
    <!--end::Fonts-->
    <!--begin::Page Custom Styles(used by this page)-->
    <link href="assets/css/pages/login/classic/login-5.css?v=7.1.0" rel="stylesheet" type="text/css">
    <!--end::Page Custom Styles-->
    <!--begin::Global Theme Styles(used by all pages)-->
    <link href="assets/plugins/global/plugins.bundle.css?v=7.1.0" rel="stylesheet" type="text/css">
    <link href="assets/plugins/custom/prismjs/prismjs.bundle.css?v=7.1.0" rel="stylesheet" type="text/css">
    <link href="assets/css/style.bundle.css?v=7.1.0" rel="stylesheet" type="text/css">
    <link href="Content/Swal2Custom.css" rel="stylesheet" type="text/css"/>
    <!--end::Glo	bal Theme Styles-->
    <!--begin::Layout Themes(used by all pages)-->
    <!--end::Layout Themes-->
    <link rel="shortcut icon" href="../assets/media/logos/favicon.ico">
    <!-- Hotjar Tracking Code for keenthemes.com -->
    <script>(function (h, o, t, j, a, r) { h.hj = h.hj || function () { (h.hj.q = h.hj.q || []).push(arguments) }; h._hjSettings = { hjid: 1070954, hjsv: 6 }; a = o.getElementsByTagName('head')[0]; r = o.createElement('script'); r.async = 1; r.src = t + h._hjSettings.hjid + j + h._hjSettings.hjsv; a.appendChild(r); })(window, document, 'https://static.hotjar.com/c/hotjar-', '.js?sv=');</script>
    <script async="" src="https://static.hotjar.com/c/hotjar-1070954.js?sv=6"></script>
    <script async="" src="https://script.hotjar.com/modules.0bbdc1f554b52cb852ad.js" charset="utf-8"></script>
    <link href="Content/Login.css" rel="stylesheet" />
</head>
<!--end::Head-->
<!--begin::Body-->
<body id="kt_body" class="quick-panel-right demo-panel-right offcanvas-right header-fixed header-mobile-fixed subheader-enabled aside-enabled aside-static" data-offcanvas-aside="on">
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-5FS8GGP" height="0" width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->
    <!--begin::Main-->
    <div class="d-flex flex-column flex-root">
        <!--begin::Login-->
        <div class="login login-5 login-signin-on d-flex flex-row-fluid" id="kt_login">
            <div class="d-flex flex-center bgi-size-cover bgi-no-repeat flex-row-fluid" style="background-image: url(assets/media/bg/bg-11.jpg);">
                <div class="login-form text-center text-white p-7 position-relative overflow-hidden">
                    <!--begin::Login Header-->
                    <div class="d-flex flex-center mb-15">
                        <a href="#">
                            <img src="assets/media/logos/logoLogin.png" width="80%" />
                            <%--<img src="assets/media/logos/Logo_SusEnvios.png" class="max-h-125px" alt="">--%>
                        </a>
                    </div>
                    <!--end::Login Header-->
                    <!--begin::Login Sign in form-->
                    <div class="login-signin">
                        <div class="mb-20">
                            <h3 class="opacity-40 font-weight-normal">Iniciar sesión como administrador</h3>
                            <p class="opacity-40">Introduzca sus datos para acceder a su cuenta:</p>
                        </div>
                        <form class="form fv-plugins-bootstrap fv-plugins-framework" id="kt_login_signin_form" novalidate="novalidate">
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="text" placeholder="Email" id="txtUserName" name="txtUserName" autocomplete="off">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="password" placeholder="Password" id="txtPassword" name="txtPassword">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group d-flex flex-wrap justify-content-between align-items-center px-8 opacity-60">
                                <div class="checkbox-inline">
                                    <label class="checkbox checkbox-outline checkbox-white text-white m-0">
                                        <input type="checkbox" name="remember">
                                        <span></span>Recuerdame</label>
                                </div>
                                <a href="javascript:;" id="kt_login_forgot" class="text-white font-weight-bold">¿Contraseña olvidada?</a>
                            </div>
                            <div class="form-group text-center mt-10">
                                <button id="kt_login_signin_submit" class="btn btn-pill btn-primary opacity-90 px-15 py-3">Ingresar</button>
                            </div>
                            <input type="hidden"><div></div>
                        </form>
                        <div class="mt-10">
                            <span class="opacity-40 mr-4">¿Aún no tienes una cuenta?</span>
                            <a href="javascript:;" id="kt_login_signup" class="text-white opacity-30 font-weight-normal">Regístrate</a>
                        </div>
                    </div>
                    <!--end::Login Sign in form-->
                    <!--begin::Login Sign up form-->
                    <div class="login-signup">
                        <div class="mb-20">
                            <h3 class="opacity-40 font-weight-normal">Sign Up</h3>
                            <p class="opacity-40">Introduzca sus datos para crear su cuenta</p>
                        </div>
                        <form class="form text-center fv-plugins-bootstrap fv-plugins-framework" id="kt_login_signup_form">
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="text" placeholder="Nombres" id="txtNombres" runat="server">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="text" placeholder="Apellidos" id="txtApellidos" runat="server">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="text" placeholder="Email" id="txtEmail" name="txtEmail" autocomplete="off">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="text" placeholder="Telefono" id="txtTelefono" name="txtTelefono" autocomplete="off">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="password" placeholder="Password" name="txtPassword1" id="txtPassword1">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="password" placeholder="Confirm Password" name="txtPassword2" id="txtPassword2">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group text-left px-8 fv-plugins-icon-container">
                                <div class="checkbox-inline">
                                    <label class="checkbox checkbox-outline checkbox-white opacity-60 text-white m-0">
                                        <input type="checkbox" name="agree">
                                        <span></span>Acepta nuestros 
										<a href="#" class="text-white font-weight-bold ml-1">terminos y condiciones</a>.
                                    </label>
                                </div>
                                <div class="form-text text-muted text-center"></div>
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group">
                                <button id="kt_login_signup_submit" class="btn btn-pill btn-primary opacity-90 px-15 py-3 m-2">Registrarse</button>
                                <button id="kt_login_signup_cancel" class="btn btn-pill btn-outline-white opacity-70 px-15 py-3 m-2">Cancelar</button>
                            </div>
                            <div></div>
                        </form>
                    </div>
                    <!--end::Login Sign up form-->
                    <!--begin::Login forgot password form-->
                    <div class="login-forgot">
                        <div class="mb-20">
                            <h3 class="opacity-40 font-weight-normal">Olvido su contraseña?</h3>
                            <p class="opacity-40">Ingrese su correo electrónico para restablecer su contraseña</p>
                        </div>
                        <form class="form fv-plugins-bootstrap fv-plugins-framework" id="kt_login_forgot_form">
                            <div class="form-group mb-10 fv-plugins-icon-container">
                                <input class="form-control h-auto text-white bg-white-o-5 rounded-pill border-0 py-4 px-8" type="text" placeholder="Email" name="txtEmailRec" id="txtEmailRec" autocomplete="off">
                                <div class="fv-plugins-message-container"></div>
                            </div>
                            <div class="form-group">
                                <button id="kt_login_forgot_submit" class="btn btn-pill btn-primary opacity-90 px-15 py-3 m-2">Enviar</button>
                                <button id="kt_login_forgot_cancel" class="btn btn-pill btn-outline-white opacity-70 px-15 py-3 m-2">Cancelar</button>
                            </div>
                            <div></div>
                        </form>
                    </div>
                    <!--end::Login forgot password form-->
                </div>
            </div>
        </div>
        <!--end::Login-->
    </div>
    <!--end::Main-->
    <script>var HOST_URL = "/metronic/theme/html/tools/preview";</script>
    <!--begin::Global Config(global config for global JS scripts)-->
    <script>var KTAppSettings = { "breakpoints": { "sm": 576, "md": 768, "lg": 992, "xl": 1200, "xxl": 1200 }, "colors": { "theme": { "base": { "white": "#ffffff", "primary": "#6993FF", "secondary": "#E5EAEE", "success": "#1BC5BD", "info": "#8950FC", "warning": "#FFA800", "danger": "#F64E60", "light": "#F3F6F9", "dark": "#212121" }, "light": { "white": "#ffffff", "primary": "#E1E9FF", "secondary": "#ECF0F3", "success": "#C9F7F5", "info": "#EEE5FF", "warning": "#FFF4DE", "danger": "#FFE2E5", "light": "#F3F6F9", "dark": "#D6D6E0" }, "inverse": { "white": "#ffffff", "primary": "#ffffff", "secondary": "#212121", "success": "#ffffff", "info": "#ffffff", "warning": "#ffffff", "danger": "#ffffff", "light": "#464E5F", "dark": "#ffffff" } }, "gray": { "gray-100": "#F3F6F9", "gray-200": "#ECF0F3", "gray-300": "#E5EAEE", "gray-400": "#D6D6E0", "gray-500": "#B5B5C3", "gray-600": "#80808F", "gray-700": "#464E5F", "gray-800": "#1B283F", "gray-900": "#212121" } }, "font-family": "Poppins" };</script>
    <!--end::Global Config-->
    <!--begin::Global Theme Bundle(used by all pages)-->
    <script src="assets/plugins/global/plugins.bundle.js?v=7.1.0"></script>
    <script src="assets/plugins/custom/prismjs/prismjs.bundle.js?v=7.1.0"></script>
    <script src="assets/js/scripts.bundle.js?v=7.1.0"></script>

    <!--end::Global Theme Bundle-->
    <!--begin::Page Scripts(used by this page)-->
    <script src="assets/js/pages/custom/login/login-general.js?v=7.1.0"></script>
    <script src="Scripts/Custom/General.js"></script>
    <!--end::Page Scripts-->

    <!--end::Body-->
    <svg id="SvgjsSvg1001" width="2" height="0" xmlns="http://www.w3.org/2000/svg" version="1.1" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:svgjs="http://svgjs.com/svgjs" style="overflow: hidden; top: -100%; left: -100%; position: absolute; opacity: 0;">
        <defs id="SvgjsDefs1002"></defs><polyline id="SvgjsPolyline1003" points="0,0"></polyline><path id="SvgjsPath1004" d="M0 0 "></path>
    </svg>
    <iframe name="_hjRemoteVarsFrame" title="_hjRemoteVarsFrame" id="_hjRemoteVarsFrame" src="https://vars.hotjar.com/box-469cf41adb11dc78be68c1ae7f9457a4.html" style="display: none !important; width: 1px !important; height: 1px !important; opacity: 0 !important; pointer-events: none !important;"></iframe>
</body>
</html>
