window._idUsuario = 0;
window._mensajeValidacion = '';
window._contraseniaActual = '';

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');

    $.when(ObtenerPorId(window._idUsuario))
        .done(function (respuestaPorId) {

            window._contraseniaActual = respuestaPorId.Cuerpo.Contrasenia;
            $('#txtContraseniaActual').val('');
            $('#txtContraseniaNueva').val('');
            $('#txtConfirmarNuevaContrasenia').val('');

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });

});

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Usuario/ObtenerContraseniaPorId',
        type: 'GET',
        data: {
            'id': id
        },
        dataType: 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        },
        complete: function (json) {
            EvaluarRespuesta_401_403(json);
        }
    });
};

$(document).on('click', '#btnGuardar', function () {
    if (!$('#btnGuardar').hasClass('disabled')) {
        if (Validar()) {
            Actualizar();
        } else {
            MensajeError('Error', window._mensajeValidacion);
        }
    }
});

function Actualizar() {

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'IdUsuario': window._idUsuario,
        'Contrasenia': $("#txtContraseniaNueva").val()
    };

    $.ajax({
        'url': '../../Usuario/ModificarContrasenia',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        }
    }).done(function (result, textStatus, jqXhr) {

        $('#frmWrapper').LoadingOverlay('hide', true);
        EvaluarRespuesta_401_403(result);
        if (!ResponseTieneErrores(result)) {
            if (result.ProcesadoOk != null) {
                switch (result.ProcesadoOk) {
                    case -1:
                        MensajeError('Error', 'El registro no existe');
                        break;
                    case 0:
                        MensajeError('Error', 'No se pudo modificar el registro');
                        break;
                    case 1:
                        window._contraseniaActual = $('#txtContraseniaNueva').val();
                        $('#txtContraseniaActual').val('');
                        $('#txtContraseniaNueva').val('');
                        $('#txtConfirmarNuevaContrasenia').val('');
                        MensajeSuccess('Confirmación', 'El registro fue modificado satisfactoriamente!');
                        break;
                }
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('#frmWrapper').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });

};

function Validar() {
    window._mensajeValidacion = '';

    if ($("#txtContraseniaActual").val() == '' || $("#txtContraseniaActual").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Contraseña Actual] es requerido <br/>';
    } else {
        if ($("#txtContraseniaActual").val() != window._contraseniaActual) {
            window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Contraseña Actual] no es válido <br/>';
        }
    }

    if ($("#txtContraseniaNueva").val() == '' || $("#txtContraseniaNueva").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Contraseña Nueva] es requerido <br/>';
    }

    if ($("#txtConfirmarNuevaContrasenia").val() == '' || $("#txtConfirmarNuevaContrasenia").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Confirmar Nueva Contraseña] es requerido <br/>';
    } else {
        if ($("#txtContraseniaNueva").val() != $("#txtConfirmarNuevaContrasenia").val()) {
            window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Confirmar Nueva Contraseña] no es válido <br/>';
        }
    }

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
    }
}

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnGuardar').removeClass('disabled');
        $('#btnInicio').removeClass('disabled');
    } else {
        $('#btnGuardar').addClass('disabled');
        $('#btnInicio').addClass('disabled');
    }
};
