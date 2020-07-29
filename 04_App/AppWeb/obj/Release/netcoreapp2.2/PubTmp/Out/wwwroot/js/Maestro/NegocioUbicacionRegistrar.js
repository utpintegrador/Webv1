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
    //window._idNegocioUbicacion = ObtenerParametroUrl();

    $.when(ObtenerNegocios())
        .done(function (respuestaNegociosAjax) {

            var cboNegocio = $('#cboNegocio');
            cboNegocio.append($('<option/>', { value: 0, text: 'Seleccione' }));

            if (respuestaNegociosAjax.Cuerpo != null) {
                if (respuestaNegociosAjax.Cuerpo.length > 0) {
                    respuestaNegociosAjax.Cuerpo.forEach(function (item, indice, array) {
                        cboNegocio.append($('<option/>', { value: item.IdNegocio, text: item.Nombre }));
                    });
                }
            }


            $('#txtTitulo').val('');
            $('#txtDescripcion').val('');
            $('#txtLatitud').val('');
            $('#txtLongitud').val('');
            $("#chkPredeterminado").prop('checked', false);
            EstablecerMapa();

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

function EstablecerMapa() {

    //https://www.youtube.com/watch?v=Zxf1mnP5zcw
    //https://developers.google.com/maps/documentation/javascript/examples/marker-remove#maps_marker_remove-javascript
    

    window._uluru = { lat: -12.064502, lng: -77.037380 };
    window._map = new google.maps.Map(document.getElementById("map"), {
        zoom: 13,
        center: window._uluru
    });

    //const input = document.getElementById("pac-input");
    //const searchBox = new google.maps.places.SearchBox(input);
    //window._map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
    //window._map.addListener("bounds_changed", () => {
    //    searchBox.setBounds(window._map.getBounds());
    //});
    //searchBox.addListener("places_changed", () => {
    //    const places = searchBox.getPlaces();

    //    if (places.length == 0) {
    //        return;
    //    }
    //    // Clear out the old markers.
    //    window._markers.forEach(marker => {
    //        marker.setMap(null);
    //    });
    //    window._markers = [];
    //    // For each place, get the icon, name and location.
    //    const bounds = new google.maps.LatLngBounds();
    //    places.forEach(place => {
    //        if (!place.geometry) {
    //            console.log("Returned place contains no geometry");
    //            return;
    //        }
    //        const icon = {
    //            url: place.icon,
    //            size: new google.maps.Size(71, 71),
    //            origin: new google.maps.Point(0, 0),
    //            anchor: new google.maps.Point(17, 34),
    //            scaledSize: new google.maps.Size(25, 25)
    //        };
    //        // Create a marker for each place.
    //        var mapTemp = window._map;
    //        window._markers.push(
    //            new google.maps.Marker({
    //                mapTemp,
    //                icon,
    //                title: place.name,
    //                position: place.geometry.location
    //            })
    //        );

    //        if (place.geometry.viewport) {
    //            // Only geocodes have viewport.
    //            bounds.union(place.geometry.viewport);
    //        } else {
    //            bounds.extend(place.geometry.location);
    //        }
    //    });
    //    window._map.fitBounds(bounds);
    //});

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
    // Adds a marker at the center of the map.
    /////////////////////////////////////////////////addMarker(window._uluru);

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
        'IdNegocio': $("#cboNegocio").val(),
        'Latitud': $("#txtLatitud").val(),
        'Longitud': $("#txtLongitud").val(),
        'Titulo': $("#txtTitulo").val(),
        'Descripcion': $("#txtDescripcion").val(),
        'Predeterminado': $("#chkPredeterminado").prop('checked')
    };

    $.ajax({
        'url': '../../NegocioUbicacion/Registrar',
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

    if ($("#cboNegocio").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Negocio] es requerido <br/>';
    }

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
