window._mensajeValidacion = '';

$(document).ready(function () {

    $(function () {
        $(".preloader").fadeOut();
    });
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });
    // ============================================================== 
    // Login and Recover Password 
    // ============================================================== 
    $('#to-recover').on("click", function () {
        $("#loginform").slideUp();
        $("#recoverform").fadeIn();
    });

    $('#to-login').on("click", function () {
        $("#recoverform").fadeOut();
        $("#loginform").fadeIn();
    });


});

$(document).on('keypress', '#txtCorreoElectronico', function (e) {
    if (e.which === 13) {
        $('#btnIniciarSesion').trigger('click');
    }
});

$(document).on('keypress', '#txtContrasenia', function (e) {
    if (e.which === 13) {
        $('#btnIniciarSesion').trigger('click');
    }
});


$(document).on('click', '#btnIniciarSesion', function () {
    if (!$('#btnIniciarSesion').hasClass('disabled')) {
        if (Validar()) {
            IniciarSesion();
        } else {
            MensajeError('Error', window._mensajeValidacion);
        }
    }
});

function IniciarSesion() {

    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'CorreoElectronico': $("#txtCorreoElectronico").val(),
        'Contrasenia': $("#txtContrasenia").val()
    };

    $.ajax({
        'url': '../../Usuario/Login',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        beforeSend: function () {
        }
    }).done(function (result, textStatus, jqXhr) {

        if (result != null) {
            var resultOk = false;
            if (result.ListaError != null) {
                if (result.ListaError.length > 0) {
                    var mensajeError = '';
                    result.ListaError.forEach(function (item, indice, array) {
                        mensajeError = mensajeError + item.Mensaje + '<br/>'
                    });
                    if (mensajeError != '') {
                        MensajeError('Error', mensajeError);
                    }
                } else {
                    resultOk = true;
                }
            } else {
                resultOk = true;
            }

            if (resultOk) {
                //Llamar a los accesos
                $.when(ObtenerAccesos(result.IdUsuario))
                    .done(function (respuestaAccesosAjax) {
                        $('body').LoadingOverlay('hide', true);

                        if (respuestaAccesosAjax != null) {
                            if (respuestaAccesosAjax.Cuerpo != null) {
                                if (respuestaAccesosAjax.Cuerpo.ListaGrupo != null) {
                                    if (respuestaAccesosAjax.Cuerpo.ListaGrupo.length > 0) {
                                        SetItem('Nombre', result.Nombre);
                                        SetItem('Apellido', result.Apellido);
                                        SetItem('CorreoElectronico', result.CorreoElectronico);
                                        SetItem('IdUsuario', result.IdUsuario);
                                        SetItem('UrlImagen', result.UrlImagen);
                                        SetItem('Token', result.Token);
                                        SetItem('Menu', JSON.stringify(respuestaAccesosAjax.Cuerpo.ListaGrupo));

                                        resultOk = true;
                                        if (GetItem('Nombre') == '' && resultOk) {
                                            resultOk = false;
                                        }
                                        if (GetItem('Apellido') == '' && resultOk) {
                                            resultOk = false;
                                        }
                                        if (GetItem('CorreoElectronico') == '' && resultOk) {
                                            resultOk = false;
                                        }
                                        if (GetItem('IdUsuario') == '' && resultOk) {
                                            resultOk = false;
                                        }
                                        if (GetItem('UrlImagen') == '' && resultOk) {
                                            resultOk = false;
                                        }
                                        if (GetItem('Token') == '' && resultOk) {
                                            resultOk = false;
                                        }

                                        if (!resultOk) {
                                            MensajeError('Error', 'Error en el almacenamiento interno');
                                        } else {
                                            window.location.href = '/Home/Index';
                                        }
                                    }//if (respuestaAccesosAjax.Cuerpo.ListaGrupo.length > 0)
                                }//fin if (respuestaAccesosAjax.Cuerpo.ListaGrupo != null)
                            }//fin if (respuestaAccesosAjax.Cuerpo != null)
                        }//fin if (respuestaAccesosAjax != null)

                    })
                    .fail(function (jqXHR) {
                        console.log(jqXHR);
                        console.log('Error');
                        $('body').LoadingOverlay('hide', true);
                        MensajeError('Error', 'Error al descargar los accesos');
                    });
            } else {
                $('body').LoadingOverlay('hide', true);
            }

        } else {
            MensajeError('Error', 'No se pudo establecer conexión con el API');
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('body').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });

};


function ObtenerAccesos(id) {

    return $.ajax({
        url: '../../Acceso/ObtenerPorIdUsuario',
        type: 'GET',
        data: {
            'id': id
        },
        dataType: 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8'
    });
}


function Validar() {
    window._mensajeValidacion = '';
    var html = [];

    if ($("#txtCorreoElectronico").val() == '' || $("#txtCorreoElectronico").val() == null) {
        html.push(' * El campo [Correo Electrónico] es requerido <br/>');
    }

    if ($("#txtContrasenia").val() == '' || $("#txtContrasenia").val() == null) {
        html.push(' * El campo [Contraseña] es requerido ');
    }

    window._mensajeValidacion = html.join('');

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
    }
}

$(document).on('keypress', '#txtCorreoElectronicoRecuperar', function (e) {
    if (e.which === 13) {
        $('#btnRecuperarContraseña').trigger('click');
    }
});

$(document).on('click', '#btnRecuperarContraseña', function () {
    if (!$('#btnRecuperarContraseña').hasClass('disabled')) {
        if (ValidarRecuperacionContrasenia()) {
            PrecederRecuperacion();
        } else {
            MensajeError('Error', window._mensajeValidacion);
        }
    }
});

function ValidarRecuperacionContrasenia() {
    window._mensajeValidacion = '';
    var html = [];

    if ($("#txtCorreoElectronicoRecuperar").val() == '' || $("#txtCorreoElectronicoRecuperar").val() == null) {
        html.push(' * El campo [Correo Electrónico] es requerido <br/>');
    }

    window._mensajeValidacion = html.join('');

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
    }
}

function PrecederRecuperacion() {

    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'CorreoElectronico': $("#txtCorreoElectronicoRecuperar").val()
    };

    $.ajax({
        'url': '../../RecuperacionContrasenia/Registrar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        beforeSend: function () {
        }
    }).done(function (result, textStatus, jqXhr) {

        $('body').LoadingOverlay('hide', true);

        if (result != null) {
            var resultOk = false;
            if (result.ListaError != null) {
                if (result.ListaError.length > 0) {
                    var mensajeError = '';
                    result.ListaError.forEach(function (item, indice, array) {
                        mensajeError = mensajeError + item.Mensaje + '<br/>'
                    });
                    if (mensajeError != '') {
                        MensajeError('Error', mensajeError);
                    }
                } else {
                    resultOk = true;
                }
            } else {
                resultOk = true;
            }

            if (resultOk) {
                if (result.ProcesadoOk == 1) {
                    $("#txtCorreoElectronicoRecuperar").val('');
                    MensajeSuccess('Confirmación', 'Se ha registrado tu petición de recuperación de contraseña, revisa tu correo por favor!!');
                } else {
                    if (result.Cuerpo != null) {
                        if (result.Cuerpo.DescripcionRespuesta != '') {
                            MensajeInfo('Información', result.Cuerpo.DescripcionRespuesta);
                        }
                    }
                }
                //window.location.href = '/Home/Index';

            }

        } else {
            MensajeError('Error', 'No se pudo establecer conexión con el API');
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
            $('body').LoadingOverlay('hide', true);
            MensajeError('Error', 'Error de solicitud');
    });

};
