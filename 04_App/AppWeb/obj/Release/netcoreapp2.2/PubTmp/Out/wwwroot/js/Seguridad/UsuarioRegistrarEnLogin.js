$(document).ready(function () {

    $(function () {
        $(".preloader").fadeOut();
    });
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

});

$(document).on('keypress', '#txtCorreoElectronico', function (e) {
    if (e.which === 13) {
        $('#btnRegistrar').trigger('click');
    }
});

$(document).on('keypress', '#txtContrasenia', function (e) {
    if (e.which === 13) {
        $('#btnRegistrar').trigger('click');
    }
});

$(document).on('keypress', '#txtNombre', function (e) {
    if (e.which === 13) {
        $('#btnRegistrar').trigger('click');
    }
});

$(document).on('keypress', '#txtApellido', function (e) {
    if (e.which === 13) {
        $('#btnRegistrar').trigger('click');
    }
});

$(document).on('click', '#btnRegistrar', function () {
    if (!$('#btnRegistrar').hasClass('disabled')) {
        if (Validar()) {
            Registrar();
        } else {
            MensajeError('Error', window._mensajeValidacion);
        }
    }
});

function Registrar() {

    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'CorreoElectronico': $("#txtCorreoElectronico").val(),
        'Contrasenia': $("#txtContrasenia").val(),
        'Nombre': $("#txtNombre").val(),
        'Apellido': $("#txtApellido").val()
    };

    $.ajax({
        'url': '../../Usuario/Registrar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        headers: {
            'Authorization': 'Valor del token debe ir aca'
        },
        beforeSend: function () {
        }
    }).done(function (result, textStatus, jqXhr) {

        $('body').LoadingOverlay('hide', true);
        if (!ResponseTieneErrores(result)) {
            if (result.ProcesadoOk != null) {
                switch (result.ProcesadoOk) {
                    case -1:
                        MensajeError('Error', 'Error al registrar!');
                        break;
                    case 0:
                        MensajeError('Error', 'Error al registrar!');
                        break;
                    case 1:
                        MensajeSuccessConEspera('Confirmación', 'El registro se efectuó satisfactoriamente!', '/Home/Login');
                        break;
                }
            }

        }
        
    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('body').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });

};

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


