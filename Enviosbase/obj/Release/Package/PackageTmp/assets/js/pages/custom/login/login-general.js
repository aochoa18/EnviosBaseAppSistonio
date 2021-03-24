"use strict";

// Class Definition
var KTLogin = function () {
    var _login;

    var _showForm = function (form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_login_' + form + '_form';

        _login.removeClass('login-forgot-on');
        _login.removeClass('login-signin-on');
        _login.removeClass('login-signup-on');

        _login.addClass(cls);

        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }

    var _handleSignInForm = function () {
        var validation;

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_signin_form'),
            {
                fields: {
                    txtUserName: {
                        validators: {
                            notEmpty: {
                                message: 'Username es requerido'
                            }
                        }
                    },
                    txtPassword: {
                        validators: {
                            notEmpty: {
                                message: 'Password es requerido'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    submitButton: new FormValidation.plugins.SubmitButton(),
                    //defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#kt_login_signin_submit').on('click', function (e) {
            e.preventDefault();
            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    var modelLogin = {
                        Login: $('#txtUserName').val(),
                        Password: $('#txtPassword').val()
                    }

                    var Data = JSON.stringify(modelLogin);
                    try {
                        $.ajax({
                            url: "Login.aspx/LoginUser",
                            type: "POST",
                            data: Data,
                            Async: true,
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            xhr: function () {
                                var xhr = $.ajaxSettings.xhr();
                                xhr.upload.onprogress = function (e) {
                                    ajax_icon_handling('Ingresando', 'load');
                                };
                                return xhr;
                            },
                            success: function (result) {
                                var usuario = JSON.parse(result.d);
                                if (usuario.idUsuario > 0) {
                                    ajax_icon_handling('Login correcto ', true);
                                    $('#lblIdRol').val(usuario.idRol);
                                    if (parseInt(usuario.idRol) == 1) {
                                        window.location.href = 'Default.aspx';
                                    }
                                    if (parseInt(usuario.idRol) == 2) {
                                        window.location.href = 'Default.aspx';
                                    }
                                } else {
                                    ajax_icon_handling('Usuario o contrase&ntilde;a invalida ', false);
                                }
                            },
                            error: function () {
                                ajax_icon_handling('A ocurrido un error.', false);
                                return false;
                            }
                        });
                    } catch (e) {
                        throw e;
                    }
                } else {
                    swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle forgot button
        $('#kt_login_forgot').on('click', function (e) {
            e.preventDefault();
            _showForm('forgot');
        });

        // Handle signup
        $('#kt_login_signup').on('click', function (e) {
            e.preventDefault();
            _showForm('signup');
        });
    }

    var _handleSignUpForm = function (e) {
        var validation;
        var form = KTUtil.getById('kt_login_signup_form');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            form,
            {
                fields: {
                    txtNombres: {
                        validators: {
                            notEmpty: {
                                message: 'Campo Nombres es requerido'
                            }
                        }
                    },
                    txtApellidos: {
                        validators: {
                            notEmpty: {
                                message: 'Campo Apellidos es requerido'
                            }
                        }
                    },
                    txtEmail: {
                        validators: {
                            notEmpty: {
                                message: 'Campo Email es requerido'
                            },
                            emailAddress: {
                                message: 'El valor no es una direcci&oacute;n de correo electr&oacute;nico v&aacute;lida'
                            }
                        }
                    },
                    txtTelefono: {
                        validators: {
                            notEmpty: {
                                message: 'Campo Telefono es requerido'
                            },
                            phone: {
                                country: 'US',
                                message: 'El valor no es un n&uacute;mero de tel&eacute;fono v&aacute;lido'
                            }
                        }
                    },
                    txtPassword1: {
                        validators: {
                            notEmpty: {
                                message: 'Campo password es requerido'
                            }
                        }
                    },
                    txtPassword2: {
                        validators: {
                            notEmpty: {
                                message: 'Campo password confirmation es requerido'
                            },
                            identical: {
                                compare: function () {
                                    return form.querySelector('[name="txtPassword1"]').value;
                                },
                                message: 'La contrase&ntilde;a y su confirmaci&oacute;n no coinciden'
                            }
                        }
                    },
                    agree: {
                        validators: {
                            notEmpty: {
                                message: 'Debe aceptar nuestros terminos y condiciones'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        $('#kt_login_signup_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    swal.fire({
                        text: "All is cool! Now you submit this form",
                        icon: "success",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                } else {
                    swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle cancel button
        $('#kt_login_signup_cancel').on('click', function (e) {
            e.preventDefault();
            _showForm('signin');
        });
    }

    var _handleForgotForm = function (e) {
        var validation;

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_forgot_form'),
            {
                fields: {
                    txtEmailRec: {
                        validators: {
                            notEmpty: {
                                message: 'Se requiere Direcci&oacute;n de correo electr&oacute;nico'
                            },
                            emailAddress: {
                                message: 'El valor no es una direcci&oacute;n de correo electr&oacute;nico v&aacute;lida'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap()
                }
            }
        );

        // Handle submit button
        $('#kt_login_forgot_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    var modelLogin = {
                        correo: $('#txtEmailRec').val()
                    }

                    var Data = JSON.stringify(modelLogin);
                    try {
                        $.ajax({
                            url: "Login.aspx/RecoveryPassword",
                            type: "POST",
                            data: Data,
                            Async: true,
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            xhr: function () {
                                var xhr = $.ajaxSettings.xhr();
                                xhr.upload.onprogress = function (e) {
                                    ajax_icon_handling('Enviando', 'load');
                                };
                                return xhr;
                            },
                            success: function (result) {
                                var resultado = JSON.parse(result.d);
                                if (resultado.result == 1) {
                                    ajax_icon_handling('Se ha enviado un correo electr&oacute;nico con instruciones para reestablecer su contrase&ntilde;a ', true);
                                    setTimeout(function () {
                                        location.reload();
                                    }, 3000);
                                } else {
                                    ajax_icon_handling('No se ha encontrado la direcci&oacute;n de correo electr&oacute;nico ', false);
                                    setTimeout(function () {
                                        location.reload();
                                    }, 3000);
                                }
                            },
                            error: function () {
                                ajax_icon_handling('A ocurrido un error.', false);
                                return false;
                            }
                        });
                    } catch (e) {
                        throw e;
                    }
                } else {
                    swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                    }).then(function () {
                        KTUtil.scrollTop();
                    });
                }
            });
        });

        // Handle cancel button
        $('#kt_login_forgot_cancel').on('click', function (e) {
            e.preventDefault();

            _showForm('signin');
        });
    }

    // Public Functions
    return {
        // public functions
        init: function () {
            _login = $('#kt_login');

            _handleSignInForm();
            _handleSignUpForm();
            _handleForgotForm();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
});
