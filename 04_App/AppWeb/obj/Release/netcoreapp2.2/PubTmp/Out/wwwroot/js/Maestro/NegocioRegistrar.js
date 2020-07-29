window._idUsuario = 0;
window._mensajeValidacion = '';
var map;

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');

    $.when(ObtenerTipoDocumentoIdentificacion())
        .done(function (respuestaTipoDocumentoIdentificacionAjax) {

            var cboTipoDocumentoIdentificacion = $('#cboTipoDocumentoIdentificacion');
            cboTipoDocumentoIdentificacion.append($('<option/>', { value: 0, text: 'Seleccione' }));
            cboTipoDocumentoIdentificacion.select2({
                minimumResultsForSearch: Infinity
            });

            if (respuestaTipoDocumentoIdentificacionAjax.Cuerpo != null) {
                if (respuestaTipoDocumentoIdentificacionAjax.Cuerpo.length > 0) {
                    respuestaTipoDocumentoIdentificacionAjax.Cuerpo.forEach(function (item, indice, array) {
                        cboTipoDocumentoIdentificacion.append($('<option/>', { value: item.IdTipoDocumentoIdentificacion, text: item.Descripcion }));
                    });
                }
            }

            $('#txtTelefono').val('');
            $('#txtDocumentoIdentificacion').val('');
            $('#txtRazonSocial').val('');
            $('#txtResenia').val('');

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });

});

function ObtenerTipoDocumentoIdentificacion() {
    //'primerItem': 'Todos'
    var select = $('#cboTipoDocumentoIdentificacion');
    return $.ajax({
        url: '../../TipoDocumentoIdentificacion/ObtenerCombo',
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
        'DocumentoIdentificacion': $("#txtDocumentoIdentificacion").val(),
        'Nombre': $("#txtRazonSocial").val(),
        'Resenia': $("#txtResenia").val(),
        'Telefono': $("#txtTelefono").val(),
        'IdTipoDocumentoIdentificacion': $("#cboTipoDocumentoIdentificacion").val(),
        'IdUsuario': window._idUsuario
    };

    $.ajax({
        'url': '../../Negocio/Registrar',
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
                        MensajeSuccessConEspera('Confirmación', 'El registro se efectuó satisfactoriamente!', '/Negocio/Index');
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

    if ($("#txtDocumentoIdentificacion").val() == '' || $("#txtDocumentoIdentificacion").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [DocumentoIdentificacion] es requerido <br/>';
    }

    if ($("#txtRazonSocial").val() == '' || $("#txtRazonSocial").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [RazonSocial] es requerido <br/>';
    }

    if ($("#txtTelefono").val() == '' || $("#txtTelefono").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Telefono] es requerido <br/>';
    }

    if ($("#cboTipoDocumentoIdentificacion").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [TipoDocumentoIdentificacion] es requerido <br/>';
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


//function initMap() {
//    // The location of Uluru
//    var uluru = { lat: -11.986751, lng: -77.073557 };
//    // The map, centered at Uluru
//    map = new google.maps.Map(
//        document.getElementById('map'), {
//            zoom: 16,
//            center: uluru
//        });
//    // The marker, positioned at Uluru
//    var marker = new google.maps.Marker({
//        position: uluru,
//        map: map
//    });
//}