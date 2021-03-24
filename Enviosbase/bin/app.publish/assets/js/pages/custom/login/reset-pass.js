"use strict";

// Class Definition
var KTLogin = function () {
    var _login;

    var _showForm = function (form) {
        var cls = 'login-' + form + '-on';
        var form = 'kt_login_' + form + '_form';

        _login.removeClass('login-reset-on');

        _login.addClass(cls);

        KTUtil.animateClass(KTUtil.getById(form), 'animate__animated animate__backInUp');
    }

    var _handleResetForm = function (e) {
        var validation;
        var form = KTUtil.getById('kt_login_reset_form');
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            KTUtil.getById('kt_login_reset_form'),
            {
                fields: {
                    txtPassword1: {
                        validators: {
                            notEmpty: {
                                message: 'Se requiere Contrase&ntilde;a'
                            }
                        }
                    },
                    txtPassword2: {
                        validators: {
                            notEmpty: {
                                message: 'Se requiere la confirmaci&oacute;n'
                            },
                            identical: {
                                compare: function () {
                                    return form.querySelector('[name="txtPassword1"]').value;
                                },
                                message: 'La contrase&ntilde;a y su confirmaci&oacute;n no coinciden'
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
        $('#kt_login_reset_submit').on('click', function (e) {
            e.preventDefault();

            validation.validate().then(function (status) {
                if (status == 'Valid') {
                    var modelLogin = {
                        password: $('#txtPassword1').val(),
                        token: getUrlVars().token
                    }

                    var Data = JSON.stringify(modelLogin);
                    try {
                        $.ajax({
                            url: "ResetPassword.aspx/RecoveryPassword",
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
                                if (resultado.status == 1) {
                                    ajax_icon_handling(resultado.mensaje, true);
                                    setTimeout(function () {
                                        location.reload();
                                    }, 3000);
                                } else {
                                    ajax_icon_handling(resultado.mensaje, false);
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
        $('#kt_login_reset_cancel').on('click', function (e) {
            e.preventDefault();
            window.location.href = "Login.aspx";
        });
    }

    // Public Functions
    return {
        // public functions
        init: function () {
            _login = $('#kt_login');

            _handleResetForm();
        }
    };
}();

// Class Initialization
jQuery(document).ready(function () {
    KTLogin.init();
});
