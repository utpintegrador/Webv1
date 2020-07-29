window._idNegocioUbicacionSeleccionado = 0;
window._idUsuario = 0;
var tb1;
var map;

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    $(".select2").select2();

    window._idUsuario = GetItem('IdUsuario');
    ProcesarCargaDeUbicaciones();
    
});

function ProcesarCargaDeUbicaciones() {

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

            $('#frmWrapper').LoadingOverlay('hide', true);

            //Cargar la grilla
            CargarData();

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar los resumenes actuales');
        });

}

function ObtenerNegocios() {
    //'primerItem': 'Todos'
    var select = $('#cboNegocio');
    return $.ajax({
        url: '../../Negocio/ObtenerCombo',
        type: 'GET',
        data: {
            'idUsuario': GetItem('IdUsuario')
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
        //"scrollX": true,
        //scrollCollapse: true,
        //"fixedColumns": {
        //    leftColumns:0,
        //    rightColumns: 1
        //},
        "ajax": {
            "url": "../../NegocioUbicacion/ObtenerPorIdUsuario",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.IdUsuario = window._idUsuario;
                d.IdNegocio = $("#cboNegocio").val();
                d.Buscar = $('#txtBuscar').val();
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
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            EstablecerFormatoCeldaSegunValor(nRow, aData, iDisplayIndex, iDisplayIndexFull);
        },
        "order": [[2, "asc"]]//id es la columna 2 y esta oculto, por lo tanto, el indice empieza en cero
    });
    tb1.columns.adjust();

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
        $('td:eq(5)', nRow).html('<i class="fa fa-check-square-o" aria-hidden="true"></i>');
        //    $(nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).removeClass('fondoFinalizado');
        //} else if (aData.IdEstado === 5) {
        //    $(nRow).addClass('fondoRechazado');
        //$('td:eq(2)', nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).removeClass('fondoFinalizado');
    }
    else {
        $('td:eq(5)', nRow).html('<i class="fa fa-square-o" aria-hidden="true"></i>');
    };
};

function ObtenerDomGrilla() {
    //return
    //"<'row' <'col-md-12'p>>" +

    //"<'clear'>" +
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
        { "data": "IdNegocioUbicacion", "name": "IdNegocioUbicacion", "visible": false },
        {
            "data": "Latitud",
            "name": "Latitud",
            render: $.fn.dataTable.render.number(',', '.', 8, '')
        },
        {
            "data": "Longitud",
            "name": "Longitud",
            render: $.fn.dataTable.render.number(',', '.', 8, '')
        },
        { "data": "Titulo", "name": "Titulo" },
        { "data": "Descripcion", "name": "Descripcion" },
        { "data": "Predeterminado", "name": "Predeterminado", "orderable": false },
        { "data": "NombreNegocio", "name": "NombreNegocio" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumna() {
    //targets desde indice cero
    return [
        {
            "targets": [2,3],
            className: 'dt-body-right'
        },
        {
            "targets": 6,
            className: 'dt-center'
        },
        {
            "targets": 8,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                //"<button class='btn btn-dark btn-sm m-r-5' id='btnGestionarImagenes'><i class='fa fa-picture-o' aria-hidden='true'></i></button> " +
                //"<button class='btn btn-primary btn-sm m-r-5' id='btnVisualizar'><i class='fa fa-eye' aria-hidden='true'></i></button> " +
                "<button class='btn btn-success btn-sm m-r-5' id='btnEditar'><i class='fa fa-pencil' aria-hidden='true'></i></button> " +
                "<button class='btn btn-danger btn-sm' id='btnEliminar'><i class='fa fa-trash-o' aria-hidden='true'></i></button>" +
                "</div>"
        }
    ];
};

$(document).on('click', '#btnRecargar', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnRecargar').hasClass('disabled')) {
        RecargarData();
    }
});

function RecargarData() {

    window._idUsuario = GetItem('IdUsuario');
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

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnRecargar').removeClass('disabled');
        $('#btnNuevo').removeClass('disabled');
    } else {
        $('#btnRecargar').addClass('disabled');
        $('#btnNuevo').addClass('disabled');
    }
};

$(document).on('change', '#cboNegocio', function (e) {
    RecargarData();

    var uluru = { lat: -12.064502, lng: -77.037380 };
    // The map, centered at Uluru
    map = new google.maps.Map(
        document.getElementById('map'), {
            zoom: 11,
            center: uluru
        });
});

$(document).on('click', '#tb1 tbody tr td', function () {

    var dataTableRows = tb1.rows({ selected: true }).data().toArray();
    if (dataTableRows.length > 0) {
        var fila = tb1.row($(this).parents('tr')).data();
        if (fila !== null && fila != undefined) {

            var filasSeleccionadas = tb1.rows({ selected: true }).data().toArray();
            if (filasSeleccionadas.length > 0) {
                if (fila.IdNegocioUbicacion === null) {
                    window._idNegocioUbicacionSeleccionado = 0;
                }
                else {
                    window._idNegocioUbicacionSeleccionado = fila.IdNegocioUbicacion;
                }
            } else {
                window._idNegocioUbicacionSeleccionado = 0;
            }

            // The location of Uluru
            var uluru = { lat: fila.Latitud, lng: fila.Longitud };
            // The map, centered at Uluru
            map = new google.maps.Map(
                document.getElementById('map'), {
                    zoom: 15,
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

        }
    } else {
        // The location of Uluru
        var uluru = { lat: -12.064502, lng: -77.037380 };
        // The map, centered at Uluru
        map = new google.maps.Map(
            document.getElementById('map'), {
                zoom: 11,
                center: uluru
            });
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
                    EliminarRegistro(fila.IdNegocioUbicacion);
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
        window.location.href = '/NegocioUbicacion/Edit/' + fila.IdNegocioUbicacion;
    }
});
