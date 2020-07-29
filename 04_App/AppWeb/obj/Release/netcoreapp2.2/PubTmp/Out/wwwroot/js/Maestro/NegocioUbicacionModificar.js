window._idUsuario = 0;
window._idNegocioUbicacion = 0;
window._map;
window._uluru;
window._markers = [];

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    //$('.selectpicker').selectpicker();
    $(".select2").select2();
    //DropZone();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');
    window._idNegocioUbicacion = ObtenerParametroUrl();

    $.when(ObtenerNegocios(), ObtenerPorId(window._idNegocioUbicacion))
        .done(function (respuestaNegociosAjax, respuestaPorId) {

            var cboNegocio = $('#cboNegocio');
            cboNegocio.append($('<option/>', { value: 0, text: 'Seleccione' }));
            
            if (respuestaNegociosAjax[0].Cuerpo != null) {
                if (respuestaNegociosAjax[0].Cuerpo.length > 0) {
                    respuestaNegociosAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboNegocio.append($('<option/>', { value: item.IdNegocio, text: item.Nombre }));
                    });
                }
            }           
            
            cboNegocio.val(respuestaPorId[0].Cuerpo.IdNegocio).trigger('change');
            $('#txtTitulo').val(respuestaPorId[0].Cuerpo.Titulo);
            $('#txtDescripcion').val(respuestaPorId[0].Cuerpo.Descripcion);

            var latitud = respuestaPorId[0].Cuerpo.Latitud.toFixed(12);
            var longitud = respuestaPorId[0].Cuerpo.Longitud.toFixed(12);
            $('#txtLatitud').val(latitud);
            $('#txtLongitud').val(longitud);

            $("#chkPredeterminado").prop('checked', respuestaPorId[0].Cuerpo.Predeterminado);
            EstablecerMapa(respuestaPorId[0].Cuerpo);

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            $('#frmWrapper').LoadingOverlay('hide', true);
            console.log(jqXHR);
            console.log('Error');
        });

});

function ObtenerNegocios() {
    //'primerItem': 'Todos'
    var select = $('#cboNegocio');
    return $.ajax({
        url: '../../Negocio/ObtenerCombo',
        type: 'GET',
        data: {
            'idUsuario': window._idUsuario
        },
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

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../NegocioUbicacion/ObtenerPorId',
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

function EstablecerMapa(modelo){
    // The location of Uluru
    window._uluru = { lat: parseFloat(modelo.Latitud), lng: parseFloat(modelo.Longitud) };
    window._map = new google.maps.Map(
        document.getElementById('map'), {
            zoom: 15,
            center: window._uluru
        });

    window._map.addListener("click", event => {
        deleteMarkers();

        if (event != null) {
            if (event.latLng != null) {
                if (event.latLng.lat() != null && event.latLng.lng()) {
                    var latitud = event.latLng.lat();
                    var longitud = event.latLng.lng();
                    var sonNumeros = true;
                    if (isNaN(latitud)) {
                        sonNumeros = false;
                    }
                    if (isNaN(longitud)) {
                        sonNumeros = false;
                    }

                    if (sonNumeros) {
                        latitud = latitud.toFixed(12);
                        longitud = longitud.toFixed(12);

                        $('#txtLatitud').val(latitud);
                        $('#txtLongitud').val(longitud);

                        addMarker(event.latLng);
                    }
                }
            }
        }


    });

    addMarker(window._uluru);

    //// The marker, positioned at Uluru
    //var infowindow = new google.maps.InfoWindow();
    //var marker = new google.maps.Marker({
    //    position: uluru,
    //    map: map,
    //    title: modelo.Titulo
    //});

    //var i = 0;
    //google.maps.event.addListener(marker, 'click', (function (marker, i) {
    //    return function () {
    //        infowindow.setContent(ObtenerCuerpoDescripcionMaps(modelo.Titulo, modelo.Descripcion));
    //        infowindow.open(map, marker);
    //    }
    //})(marker, i));
}

function addMarker(location) {
    const marker = new google.maps.Marker({
        position: location,
        map: window._map
    });
    window._markers.push(marker);
}

function setMapOnAll(map) {
    for (let i = 0; i < window._markers.length; i++) {
        window._markers[i].setMap(map);
    }
}

function clearMarkers() {
    setMapOnAll(null);
}

function showMarkers() {
    setMapOnAll(window._map);
}

function deleteMarkers() {
    clearMarkers();
    markers = [];
}

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
        'IdNegocioUbicacion': window._idNegocioUbicacion,
        'Latitud': $("#txtLatitud").val(),
        'Longitud': $("#txtLongitud").val(),
        'Titulo': $("#txtTitulo").val(),
        'Descripcion': $("#txtDescripcion").val(),
        'Predeterminado': $("#chkPredeterminado").prop('checked')
    };

    $.ajax({
        'url': '../../NegocioUbicacion/Modificar',
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

    if ($("#txtTitulo").val() == '' || $("#txtTitulo").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Titulo] es requerido <br/>';
    }

    if ($("#txtLatitud").val() == '' || $("#txtLatitud").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Latitud] es requerido <br/>';
    }

    if ($("#txtLongitud").val() == '' || $("#txtLongitud").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Longitud] es requerido <br/>';
    }

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
    }
}
