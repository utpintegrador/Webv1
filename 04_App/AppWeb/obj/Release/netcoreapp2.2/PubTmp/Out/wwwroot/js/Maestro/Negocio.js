window._idUsuario = 0;
window._idNegocioSeleccionado = 0;
var tb1;
var tb2;
var map;

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');
    ProcesarCargaDeNegocio();
});

function ProcesarCargaDeNegocio() {

    $.when(ObtenerEstado())
        .done(function (respuestaEstadoAjax) {

            var cboEstado = $('#cboEstado');
            cboEstado.append($('<option/>', { value: 0, text: 'Todos' }));
            cboEstado.select2({
                minimumResultsForSearch: Infinity
            });

            if (respuestaEstadoAjax.Cuerpo != null) {
                if (respuestaEstadoAjax.Cuerpo.length > 0) {
                    respuestaEstadoAjax.Cuerpo.forEach(function (item, indice, array) {
                        cboEstado.append($('<option/>', { value: item.IdEstado, text: item.Descripcion }));
                    });
                }
            }

            $('#frmWrapper').LoadingOverlay('hide', true);

            //Cargar la grilla
            CargarData();
            CargarDataDetalle();

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar los controles previos');
        });

}

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

function CargarData() {

    $.fn.dataTable.ext.errMode = 'console';
    tb1 = $('#tb1').DataTable({
        "responsive": true,
        "processing": true,
        "serverSide": true,
        "autoWidth": false,
        "filter": true,
        "orderMulti": false,
        "select": true,
        "pagingType": "full_numbers",
        "dom": ObtenerDomGrilla(),
        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
        "ajax": {
            "url": "../../Negocio/ObtenerData",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.Buscar = $('#txtBuscar').val();
                d.IdEstado = $("#cboEstado").val();
                d.IdUsuario = GetItem('IdUsuario');
            },
            "beforeSend": function (request) {
                //console.log(request);
                HabilitarControlesMenu(false);
                request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
                //request.setRequestHeader("token", 'tokenPersonalizado');
            },
            "complete": function (json, type) {

                EvaluarRespuesta_401_403(json);
                if (json.responseJSON != null) {
                    if (json.responseJSON.error != null) {
                        //console.log(json.responseJSON.error);
                        MensajeError('Error al cargar listado', json.responseJSON.error);
                    }
                }

                //MensajeErrorDataTable(json);
                HabilitarControlesMenu(true);

            },
            "error": function (xhr, error, thrown) {
                console.log(xhr);
                console.log(error);
                console.log(thrown);
                HabilitarControlesMenu(true);
            }
        },
        "columns": ObtenerConfiguracionColumnas(),
        "columnDefs": ObtenerDefinicionBotonColumna(),
        "order": [[2, "asc"]]//id es la columna 2 y esta oculto, por lo tanto, el indice empieza en cero
    });
    tb1.columns.adjust();

    $('div.dataTables_length select').addClass('selectDt');
    $(".selectDt").select2({
        minimumResultsForSearch: Infinity
    });
};

function ObtenerDomGrilla() {
    return "<'row' <'col-md-12'rt> >" +
        "<'clear'>" +

        "<'row' <'col-md-6'l> <'col-md-6'p> >" +
        "<'row' <'col-md-12'i>>" +
        "<'clear'>" +
        "<'clear'>";
};

function ObtenerConfiguracionColumnas() {
    //"columns" empieza desde el indice cero
    //Asocia el fieldname hacia una columna especifica 
    return [
        { "data": "Item", "name": "Item", "autoWidth": false, "width": "30px", "orderable": false },
        { "data": "IdNegocio", "name": "IdNegocio", "visible": false },
        { "data": "DescripcionTipoDocumentoIdentificacion", "name": "DescripcionTipoDocumentoIdentificacion" },
        { "data": "DocumentoIdentificacion", "name": "DocumentoIdentificacion" },
        { "data": "Nombre", "name": "Nombre" },
        { "data": "Telefono", "name": "Telefono" },
        { "data": "DescripcionEstado", "name": "DescripcionEstado" },
        {
            "data": "CantidadUbicaciones",
            "name": "CantidadUbicaciones",
            "orderable": false
        },
        { "data": "CorreoElectronico", "name": "CorreoElectronico" },
        { "data": "FechaRegistro", "name": "FechaRegistro" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumna() {
    //targets desde indice cero
    return [
        {
            "targets": 7,
            className: 'dt-center'
        },
        {
            "targets": 9,
            className: 'dt-center'
        },
        {
            "targets": 10,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                //"<button class='btn btn-primary btn-sm m-r-5' id='btnEditarUbicacion'><i class='fa fa-map-o' aria-hidden='true'></i></button> " +
                "<button class='btn btn-success btn-sm m-r-5' id='btnEditar'><i class='fa fa-pencil' aria-hidden='true'></i></button> " +
                "<button class='btn btn-danger btn-sm' id='btnEliminar'><i class='fa fa-trash-o' aria-hidden='true'></i></button>" +
                "</div>"
        }
    ];
};

function CargarDataDetalle() {

    $.fn.dataTable.ext.errMode = 'console';
    tb2 = $('#tb2').DataTable({
        "responsive": true,
        "processing": true,
        "serverSide": true,
        "autoWidth": false,
        "filter": true,
        "orderMulti": false,
        "select": true,
        "pagingType": "full_numbers",
        "dom": ObtenerDomGrillaDetalle(),
        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
        "ajax": {
            "url": "../../NegocioUbicacion/ObtenerPorIdNegocio",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.IdNegocio = window._idNegocioSeleccionado;
                d.Buscar = '';
            },
            "beforeSend": function (request) {
                //console.log(request);
                HabilitarControlesMenu(false);
                request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
                //request.setRequestHeader("token", 'tokenPersonalizado');
            },
            "error": function (xhr, error, thrown) {
                console.log(xhr);
                console.log(error);
                console.log(thrown);
                HabilitarControlesMenu(true);
            },
            "complete": function (json, type) {

                EvaluarRespuesta_401_403(json);
                if (json.responseJSON != null) {
                    if (json.responseJSON.error != null) {
                        //console.log(json.responseJSON.error);
                        MensajeError('Error al cargar listado', json.responseJSON.error);
                    }
                }

                //MensajeErrorDataTable(json);
                HabilitarControlesMenu(true);
            }
        },
        "columns": ObtenerConfiguracionColumnaDetalle(),
        "columnDefs": ObtenerDefinicionBotonColumnaDetalle(),
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            EstablecerFormatoCeldaSegunValor(nRow, aData, iDisplayIndex, iDisplayIndexFull);
        },
        "order": [[2, "asc"]]//id es la columna 2 y esta oculto, por lo tanto, el indice empieza en cero
    });
    tb2.columns.adjust();
    $('div.dataTables_length select').addClass('selectDt');
    $(".selectDt").select2({
        minimumResultsForSearch: Infinity
    });
};

function EstablecerFormatoCeldaSegunValor(nRow, aData) {
    //nRow: obtiene toda la etiqueta <TR>
    //aData: obtiene el datasource de cada fila
    //iDisplayIndex: obtiene el indice de cada fila empezando desde cero
    //iDisplayIndexFull: obtiene el indice de cada fila empezando desde cero

    //console.log(aData);
    //A partir del indice 0 y sin contar los ocultos
    if (aData.Predeterminado) {
        $('td:eq(3)', nRow).html('<i class="fa fa-check-square-o" aria-hidden="true"></i>');
    //    $(nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).removeClass('fondoFinalizado');
    //} else if (aData.IdEstado === 5) {
    //    $(nRow).addClass('fondoRechazado');
        //$('td:eq(2)', nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).removeClass('fondoFinalizado');
    }
    else {
        $('td:eq(3)', nRow).html('');
    };
};

function ObtenerDomGrillaDetalle() {
    return "<'row' <'col-md-12'rt> >" +
        "<'clear'>" +

        "<'row' <'col-md-6'l> <'col-md-6'p> >" +
        "<'row' <'col-md-12'i>>" +
        "<'clear'>" +
        "<'clear'>";
};

function ObtenerConfiguracionColumnaDetalle() {
    //"columns" empieza desde el indice cero
    //Asocia el fieldname hacia una columna especifica 
    return [
        { "data": "Item", "name": "Item", "autoWidth": false, "width": "30px", "orderable": false },
        { "data": "IdNegocioUbicacion", "name": "IdNegocioUbicacion", "visible": false },
        { "data": "Titulo", "name": "Titulo" },
        {
            "data": "Latitud",
            "name": "Latitud",
            render: $.fn.dataTable.render.number(',', '.', 8, ''),
            "visible": false
        },
        {
            "data": "Longitud",
            "name": "Longitud",
            render: $.fn.dataTable.render.number(',', '.', 8, ''),
            "visible": false
        },
        { "data": "Descripcion", "name": "Descripcion" },
        { "data": "Predeterminado", "name": "Predeterminado" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumnaDetalle() {
    //targets desde indice cero
    return [
        {
            "targets": 6,
            className: 'dt-center'
        },
        {
            "targets": 7,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                "<button class='btn btn-primary btn-sm m-r-5' id='btnVisualizarDetalle'><i class='fa fa-street-view' aria-hidden='true'></i></button> " +
                //"<button class='btn btn-success btn-sm m-r-5' id='btnEditarDetalle'><i class='fa fa-pencil' aria-hidden='true'></i></button> " +
                "<button class='btn btn-danger btn-sm' id='btnEliminarDetalle'><i class='fa fa-trash-o' aria-hidden='true'></i></button>" +
                "</div>"
        }
    ];
};

$(document).on('click', '#btnRecargar', function () {
    if (!$('#btnRecargar').hasClass('disabled')) {
        RecargarData();
    }
});

function RecargarData() {

    tb1.ajax.reload();
    $("#txtBuscar").focus();

};

$(document).on('keypress', '#txtBuscar', function (e) {
    if (e.which === 13) {

        //Disable textbox to prevent multiple submit
        $(this).attr("disabled", "disabled");

        if (!$('#btnRecargar').hasClass('disabled')) {
            RecargarData();
        }

        //Enable the textbox again if needed.
        $(this).removeAttr("disabled");
    }
});

$(document).on('click', '#tb1 tbody #btnEliminar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-lg btn-danger m-r-10',
                cancelButton: 'btn btn-secondary'
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: "Confirmación",
            text: "¿Está seguro de eliminar el registro " + fila.Nombre + "?",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: 'Si!',
            cancelButtonText: 'No!',
            //confirmButtonColor: '#d33',
            reverseButtons: false
        }).then(function (respuesta) {
            switch (respuesta.value) {
                case true:
                    //console.log('se eliminara');
                    EliminarRegistro(fila.IdNegocio);
                    break;
                default:
                    //console.log('no se eliminara');
                    break;
            }

        });

    }
});

function EliminarRegistro(id) {
    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'id': id
    };

    $.ajax({
        'url': '../../Negocio/Eliminar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        }
    }).done(function (result, textStatus, jqXhr) {
        $('body').LoadingOverlay('hide', true);
        EvaluarRespuesta_401_403(result);
        if (result.ProcesadoOk != null) {
            switch (result.ProcesadoOk) {
                case -1:
                    MensajeError('Error', 'El registro no existe o ya ha sido eliminado');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo eliminar el registro');
                    break;
                case 1:
                    MensajeSuccess('Confirmación', 'El registro fue eliminado satisfactoriamente!');
                    RecargarData();
                    break;
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('body').LoadingOverlay('hide', true);
    });

};

$(document).on('click', '#tb1 tbody #btnEditar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        window.location.href = '/Negocio/Edit/' + fila.IdNegocio;
    }
});

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Negocio/ObtenerPorId',
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

//$(document).on('change', '#cboNegocio', function (e) {
//    RecargarData();
//});

$(document).on('click', '#tb1 tbody #btnEditarUbicacion', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        //MensajeInfo('Información', 'Método de gestionar ubicaciones aun no se encuentra implementado');
        window.location.href = '/Negocio/' + fila.IdNegocio + '/Ubicaciones';
    }
});

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnRecargar').removeClass('disabled');
        $('#btnNuevo').removeClass('disabled');
        $('#btnMostrarUbicaciones').removeClass('disabled');
    } else {
        $('#btnRecargar').addClass('disabled');
        $('#btnNuevo').addClass('disabled');
        $('#btnMostrarUbicaciones').addClass('disabled');
    }
};

$(document).on('click', '#tb1 tbody tr td', function () {
    var fila = tb1.row($(this).parents('tr')).data();

    var filasSeleccionadas = tb1.rows({ selected: true }).data().toArray();
    if (filasSeleccionadas.length > 0) {
        if (fila.IdNegocio === null) {
            window._idNegocioSeleccionado = 0;
        }
        else {
            window._idNegocioSeleccionado = fila.IdNegocio;
        }
    } else {
        window._idNegocioSeleccionado = 0;
    }

    tb2.ajax.reload();
});

$(document).on('click', '#tb2 tbody #btnVisualizarDetalle', function () {
    var fila = tb2.row($(this).parents('tr')).data();
    if (fila !== null) {

        // The location of Uluru
        //var uluru = { lat: -11.986751, lng: -77.073557 };
        var uluru = { lat: fila.Latitud, lng: fila.Longitud };
        // The map, centered at Uluru
        map = new google.maps.Map(
            document.getElementById('map'), {
                zoom: 14,
                center: uluru
            });
        // The marker, positioned at Uluru
        var infowindow = new google.maps.InfoWindow();
        var marker = new google.maps.Marker({
            position: uluru,
            map: map,
            title: fila.Titulo
        });

        var i = 0;
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(ObtenerCuerpoDescripcionMaps(fila.Titulo, fila.Descripcion));
                infowindow.open(map, marker);
            }
        })(marker, i));

        $('#sticky').modal({
            escapeClose: true,
            //clickClose: false,
            showClose: true
        });
        //CargarMapa(fila);
    }
});

//$(document).on('click', '#tb1 tbody #btnVisualizar', function () {
//    var fila = tb1.row($(this).parents('tr')).data();
//    if (fila !== null) {

//        ObtenerUbicaciones(fila.IdNegocio);

//    }
//});

$(document).on('click', '#btnMostrarUbicaciones', function () {
    if (!$('#btnEliminarSeleccionados').hasClass('disabled')) {
        var dataTableRows = tb1.rows({ selected: true }).data().toArray();
        if (dataTableRows.length > 0) {

            if (dataTableRows.length == 1) {
                dataTableRows.forEach(function (entry) {
                    MostrarUbicacionesMultiples(entry.IdNegocio);
                });
            } else {
                MensajeError('Error', 'Seleccione solo un registro Negocio');
            }

        } else {
            //mensaje: seleccione un registro
            MensajeError('Error', 'Seleccione un registro');
        }
    }
});

function MostrarUbicacionesMultiples(id) {

    $('#tb1').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'IdNegocio': id,
        'Buscar': ''
    };

    $.ajax({
        'url': '../../NegocioUbicacion/ObtenerPorIdNegocio',
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

        $('#tb1').LoadingOverlay('hide', true);
        EvaluarRespuesta_401_403(result);
        if (result.data != null && result.recordsTotal != null) {
            if (result.recordsTotal > 0) {
                if (result.data.length > 0) {

                    //Cargar mapas
                    var urlPredeterminado = { lat: result.data[0].Latitud, lng: result.data[0].Longitud };
                    map = new google.maps.Map(
                        document.getElementById('map'), {
                            zoom: 14,
                            center: urlPredeterminado
                        });

                    var infowindow = new google.maps.InfoWindow();
                    var marker;
                    var i = 0;

                    result.data.forEach(function (item, indice, array) {

                        var urlItem = { lat: item.Latitud, lng: item.Longitud };
                        marker = new google.maps.Marker({
                            position: urlItem,
                            map: map,
                            title: item.Titulo
                        });

                        google.maps.event.addListener(marker, 'click', (function (marker, i) {
                            return function () {
                                infowindow.setContent(ObtenerCuerpoDescripcionMaps(item.Titulo, item.Descripcion));
                                infowindow.open(map, marker);
                            }
                        })(marker, i));

                        i = i + 1;

                    });

                    //https://stackoverflow.com/questions/3059044/google-maps-js-api-v3-simple-multiple-marker-example

                    $('#sticky').modal({
                        escapeClose: true,
                        showClose: true
                    });

                }
            } else {
                MensajeInfo('No encontrado', 'El negocio seleccionado no tiene ubicaciones registradas');
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

};

function ObtenerCuerpoDescripcionMaps(titulo, descripcion) {

    if (titulo == null) {
        titulo = '';
    }

    if (descripcion == null) {
        descripcion = '';
    }

    if (titulo == '' && descripcion == '') {
        return '';
    }

    var html = [];
    html.push('<div id="content">');
    html.push('   <div id="siteNotice">');
    html.push('   </div>');
    if (titulo != '') {
        html.push('   <h1 id="firstHeading" class="firstHeading">' + titulo + '</h1>');
    }

    if (descripcion != '') {
        html.push('   <div id="bodyContent">');
        html.push('       <p>' + descripcion + '</p>');
        html.push('   </div>');
    }

    html.push('</div>');
    
    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}


$(document).on('click', '#tb2 tbody #btnEliminarDetalle', function () {
    var fila = tb2.row($(this).parents('tr')).data();
    if (fila !== null) {

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-lg btn-danger m-r-10',
                cancelButton: 'btn btn-secondary'
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: "Confirmación",
            text: "¿Está seguro de eliminar el registro?",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: 'Si!',
            cancelButtonText: 'No!',
            //confirmButtonColor: '#d33',
            reverseButtons: false
        }).then(function (respuesta) {
            switch (respuesta.value) {
                case true:
                    //console.log('se eliminara');
                    EliminarRegistroDetalle(fila.IdNegocioUbicacion);
                    break;
                default:
                    //console.log('no se eliminara');
                    break;
            }

        });

    }
});

function EliminarRegistroDetalle(id) {
    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'id': id
    };

    $.ajax({
        'url': '../../NegocioUbicacion/Eliminar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        }
    }).done(function (result, textStatus, jqXhr) {
        $('body').LoadingOverlay('hide', true);
        EvaluarRespuesta_401_403(result);
        if (result.ProcesadoOk != null) {
            switch (result.ProcesadoOk) {
                case -1:
                    MensajeError('Error', 'El registro no existe o ya ha sido eliminado');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo eliminar el registro');
                    break;
                case 1:
                    MensajeSuccess('Confirmación', 'El registro fue eliminado satisfactoriamente!');
                    RecargarDataDetalle();
                    break;
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('body').LoadingOverlay('hide', true);
    });

};

function RecargarDataDetalle() {

    tb2.ajax.reload();
    $("#txtBuscar").focus();

};
