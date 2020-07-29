window._idUsuario = 0;
window._mensajeValidacion = '';

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');

    $.when(ObtenerTiposEstado())
        .done(function (respuestaTiposEstadoAjax) {

            var cboTipoEstado = $('#cboTipoEstado');
            cboTipoEstado.append($('<option/>', { value: 0, text: 'Seleccione' }));
            cboTipoEstado.select2({
                minimumResultsForSearch: Infinity
            });

            if (respuestaTiposEstadoAjax.Cuerpo != null) {
                if (respuestaTiposEstadoAjax.Cuerpo.length > 0) {
                    respuestaTiposEstadoAjax.Cuerpo.forEach(function (item, indice, array) {
                        cboTipoEstado.append($('<option/>', { value: item.IdTipoEstado, text: item.Descripcion }));
                    });
                }
            }

            $('#txtDescripcion').val('');
            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });

});

function ObtenerTiposEstado() {
    //'primerItem': 'Todos'
    var select = $('#cboTipoEstado');
    return $.ajax({
        url: '../../TipoEstado/ObtenerCombo',
        type: 'GET',
        data: {},
        dataType: 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
            select.empty();
        },
        complete: function (json) {
            EvaluarRespuesta_401_403(json);
        }
    });
}

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
        'Descripcion': $("#txtDescripcion").val(),
        'IdTipoEstado': $("#cboTipoEstado").val()
    };

    $.ajax({
        'url': '../../Estado/Registrar',
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
                        MensajeError('Error', 'Error al registrar!');
                        break;
                    case 0:
                        MensajeError('Error', 'Error al registrar!');
                        break;
                    case 1:
                        MensajeSuccessConEspera('Confirmación', 'El registro se efectuó satisfactoriamente!', '/Estado/Index');
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

    if ($("#txtDescripcion").val() == '' || $("#txtDescripcion").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Descripcion] es requerido <br/>';
    }

    if ($("#cboTipoEstado").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [TipoEstado] es requerido <br/>';
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

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnGuardar').removeClass('disabled');
        $('#btnRetornar').removeClass('disabled');
    } else {
        $('#btnGuardar').addClass('disabled');
        $('#btnRetornar').addClass('disabled');
    }
};



