window._idUsuario = 0;
window._idNegocio = 0;
window._mensajeValidacion = '';
var map;

$(document).ready(function () {
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');
    window._idNegocio = ObtenerParametroUrl();

    $.when(ObtenerEstado(), ObtenerTipoDocumentoIdentificacion(), ObtenerPorId(window._idNegocio))
        .done(function (respuestaEstadoAjax, respuestaTipoDocumentoIdentificacionAjax, respuestaPorId) {

            var cboEstado = $('#cboEstado');
            cboEstado.append($('<option/>', { value: 0, text: 'Seleccione' }));
            var cboTipoDocumentoIdentificacion = $('#cboTipoDocumentoIdentificacion');
            cboTipoDocumentoIdentificacion.append($('<option/>', { value: 0, text: 'Seleccione' }));

            if (respuestaEstadoAjax[0].Cuerpo != null) {
                if (respuestaEstadoAjax[0].Cuerpo.length > 0) {
                    respuestaEstadoAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboEstado.append($('<option/>', { value: item.IdEstado, text: item.Descripcion }));
                    });
                }
            }

            if (respuestaTipoDocumentoIdentificacionAjax[0].Cuerpo != null) {
                if (respuestaTipoDocumentoIdentificacionAjax[0].Cuerpo.length > 0) {
                    respuestaTipoDocumentoIdentificacionAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboTipoDocumentoIdentificacion.append($('<option/>', { value: item.IdTipoDocumentoIdentificacion, text: item.Descripcion }));
                    });
                }
            }

            cboEstado.val(respuestaPorId[0].Cuerpo.IdEstado).trigger('change');
            cboTipoDocumentoIdentificacion.val(respuestaPorId[0].Cuerpo.IdTipoDocumentoIdentificacion).trigger('change');
            $('#txtDocumentoIdentificacion').val(respuestaPorId[0].Cuerpo.DocumentoIdentificacion);
            $('#txtRazonSocial').val(respuestaPorId[0].Cuerpo.Nombre);
            $('#txtResenia').val(respuestaPorId[0].Cuerpo.Resenia);

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });
});

function ObtenerEstado() {
    //'primerItem': 'Todos'
    var select = $('#cboEstado');
    return $.ajax({
        url: '../../Estado/ObtenerCombo',
        type: 'GET',
        data: {
            'idTipoEstado': 1
        },
        dataType: 'json',
        headers: {
            'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
        }
    });
}

function ObtenerTipoDocumentoIdentificacion() {
    //'primerItem': 'Todos'
    var select = $('#cboTipoDocumentoIdentificacion');
    return $.ajax({
        url: '../../TipoDocumentoIdentificacion/ObtenerCombo',
        type: 'GET',
        data: {},
        dataType: 'json',
        headers: {
            'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
        }
    });
}

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Negocio/ObtenerPorId',
        type: 'GET',
        data: {
            'id': id
        },
        dataType: 'json',
        headers: {
            'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
        }
    });
};

function ObtenerParametroUrl() {
    var sPageURL = window.location.href;
    var indexOfLastSlash = sPageURL.lastIndexOf("/");

    if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash) {
        return sPageURL.substring(indexOfLastSlash + 1);
    }
    else {
        return 0;
    }
}

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
        'IdNegocio': window._idNegocio,
        'DocumentoIdentificacion': $("#txtDocumentoIdentificacion").val(),
        'Nombre': $("#txtRazonSocial").val(),
        'Resenia': $("#txtResenia").val(),
        'IdTipoDocumentoIdentificacion': $("#cboTipoDocumentoIdentificacion").val(),
        'IdEstado': $("#cboEstado").val()
    };

    $.ajax({
        'url': '../../Negocio/Modificar',
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
                    MensajeError('Error', 'El registro no existe');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo modificar el registro');
                    break;
                case 1:
                    MensajeInfo('Confirmación', 'El registro fue modificado satisfactoriamente!');
                    break;
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

};

function Validar() {
    window._mensajeValidacion = '';

    if ($("#txtDocumentoIdentificacion").val() == '' || $("#txtDocumentoIdentificacion").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [DocumentoIdentificacion] es requerido ';
    }

    if ($("#txtRazonSocial").val() == '' || $("#txtRazonSocial").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [RazonSocial] es requerido ';
    }

    if ($("#cboEstado").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Estado] es requerido ';
    }

    if ($("#cboTipoDocumentoIdentificacion").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [TipoDocumentoIdentificacion] es requerido ';
    }

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
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