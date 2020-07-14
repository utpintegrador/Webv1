window._idUsuario = 0;
window._mensajeValidacion = '';

$(document).ready(function () {
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');

    $('#txtDescripcion').val('');
    $('#frmWrapper').LoadingOverlay('hide', true);

});


$(document).on('click', '#btnGuardar', function () {
    if (!$('#btnGuardar').hasClass('disabled')) {
        if (Validar()) {
            Registrar();
        } else {
            MensajeError('Error', window._mensajeValidacion);
        }
    }
});

function Registrar() {

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'Descripcion': $("#txtDescripcion").val()
    };

    $.ajax({
        'url': '../../TipoDocumentoIdentificacion/Registrar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        headers: {
            'Authorization': 'Valor del token debe ir aca'
        },
        beforeSend: function () {
        }
    }).done(function (result, textStatus, jqXhr) {

        $('#frmWrapper').LoadingOverlay('hide', true);

        if (result.ProcesadoOk != null) {
            switch (result.ProcesadoOk) {
                case -1:
                    MensajeError('Error', 'Error al registrar!');
                    break;
                case 0:
                    MensajeError('Error', 'Error al registrar!');
                    break;
                case 1:
                    MensajeInfo('Confirmación', 'El registro se efectuó satisfactoriamente!');
                    break;
            }
        }

        if (result.ProcesadoOk == 1) {
            sleep(3000);
            window.location.href = '/TipoDocumentoIdentificacion/Index';
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

};

function Validar() {
    window._mensajeValidacion = '';

    if ($("#txtDescripcion").val() == '' || $("#txtDescripcion").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Descripcion] es requerido ';
    }

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
    }
}

function sleep(miliseconds) {
    var currentTime = new Date().getTime();
    while (currentTime + miliseconds >= new Date().getTime()) {
    }
}

function MensajeError(titulo, mensaje) {

    if (titulo == null) {
        titulo = 'Error';
    }

    if (titulo == '') {
        titulo = 'Error';
    }

    if (mensaje == null) {
        mensaje = 'Error al procesar';
    }

    if (mensaje == '') {
        mensaje = 'Error al procesar';
    }

    var icon = 'error';
    var className = 'btn btn-danger';

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: className
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        title: titulo,
        text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    });
}

function MensajeInfo(titulo, mensaje) {

    if (titulo == null) {
        titulo = 'Confirmación';
    }

    if (titulo == '') {
        titulo = 'Confirmación';
    }

    if (mensaje == null) {
        mensaje = 'Proceso satisfactorio';
    }

    if (mensaje == '') {
        mensaje = 'Proceso satisfactorio';
    }

    var icon = 'success';
    var className = 'btn btn-success';

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: className
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        title: titulo,
        text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    });
}

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnGuardar').removeClass('disabled');
        $('#btnRetornar').removeClass('disabled');
    } else {
        $('#btnGuardar').addClass('disabled');
        $('#btnRetornar').addClass('disabled');
    }
};
