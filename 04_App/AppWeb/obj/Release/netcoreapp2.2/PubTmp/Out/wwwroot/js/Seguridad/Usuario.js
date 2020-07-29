var tb1;

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    //$('.selectpicker').selectpicker();
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    ProcesarCargaDeUsuarios();
});

//#region Funciones Main


function ProcesarCargaDeUsuarios() {

    $.when(ObtenerTiposUsuario(), ObtenerEstados())
        .done(function (respuestaTiposUsuarioAjax, respuestaEstadosAjax) {

            var cboTipoUsuario = $('#cboTipoUsuario');
            cboTipoUsuario.append($('<option/>', { value: 0, text: 'Todos' }));
            cboTipoUsuario.select2({
                minimumResultsForSearch: Infinity
            });
            var cboEstado = $('#cboEstado');
            cboEstado.append($('<option/>', { value: 0, text: 'Todos' }));
            cboEstado.select2({
                minimumResultsForSearch: Infinity
            });

            if (respuestaTiposUsuarioAjax[0].Cuerpo != null) {
                if (respuestaTiposUsuarioAjax[0].Cuerpo.length > 0) {
                    respuestaTiposUsuarioAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboTipoUsuario.append($('<option/>', { value: item.IdTipoUsuario, text: item.Descripcion }));
                    });
                }
            }

            if (respuestaEstadosAjax[0].Cuerpo != null) {
                if (respuestaEstadosAjax[0].Cuerpo.length > 0) {
                    respuestaEstadosAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboEstado.append($('<option/>', { value: item.IdEstado, text: item.Descripcion }));
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

function ObtenerTiposUsuario() {
    //'primerItem': 'Todos'
    var select = $('#cboTipoUsuario');
    return $.ajax({
        url: '../../TipoUsuario/ObtenerCombo',
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

function ObtenerEstados() {
    //'primerItem': 'Todos'
    var select = $('#cboEstado');
    return $.ajax({
        url: '../../Estado/ObtenerCombo',
        type: 'GET',
        data: {
            'idTipoEstado': 2
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
            "url": "../../Usuario/ObtenerData",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.IdTipoUsuario = $("#cboTipoUsuario").val();
                d.Buscar = $('#txtBuscar').val();
                d.IdEstado = $("#cboEstado").val();
            },
            "beforeSend": function (request) {
                //console.log(request);
                HabilitarControlesMenu(false);
                request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
                //request.setRequestHeader("token", 'tokenPersonalizado');

            },
            "complete": function (json, type) {

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
        { "data": "IdUsuario", "name": "IdUsuario", "visible": false },
        { "data": "CorreoElectronico", "name": "CorreoElectronico" },
        { "data": "Nombre", "name": "Nombre" },
        { "data": "Apellido", "name": "Apellido" },
        { "data": "DescripcionEstado", "name": "DescripcionEstado" },
        { "data": "DescripcionTipoUsuario", "name": "DescripcionTipoUsuario" },
        { "data": "FechaRegistro", "name": "FechaRegistro" },
        { "data": "FechaActualizacion", "name": "FechaActualizacion" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumna() {
    //targets desde indice cero
    return [
        {
            "targets": 9,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                "<button class='btn btn-primary btn-sm m-r-5' id='btnVisualizar'><i class='fa fa-eye' aria-hidden='true'></i></button> " +
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
            text: "¿Está seguro de eliminar el registro " + fila.CorreoElectronico + "?",
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
                    EliminarRegistro(fila.IdUsuario);
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
        'url': '../../Usuario/Eliminar',
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
        window.location.href = '/Usuario/Edit/' + fila.IdUsuario;
    }
});

$(document).on('click', '#tb1 tbody #btnVisualizar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        //window.location.href = '/Usuario/Details/' + fila.IdUsuario;
        $.when(ObtenerPorId(fila.IdUsuario))
            .done(function (respuestaAjax) {

                if (respuestaAjax != null) {
                    if (respuestaAjax.ProcesadoOk == 1) {
                        var cuerpoModal = GenerarCuerpoModalDeDetalle(respuestaAjax.Cuerpo);
                        $('#sticky').empty();
                        $('#sticky').append(cuerpoModal);

                        $('#sticky').modal({
                            escapeClose: true,
                            clickClose: false,
                            showClose: false
                        });
                    }
                    else {

                    }
                }
            })
            .fail(function (jqXHR) {
                console.log(jqXHR);
                console.log('Error');
            });

    }
});

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Usuario/ObtenerPorId',
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

function GenerarCuerpoModalDeDetalle(objetoSeleccionado) {
    //Estamos en el cuerpo de la respuesta
    var html = [];

    var htmlImagenSlides = [];
    var htmlImagenSrc = [];

    //Imagenes del carrousel
    if (objetoSeleccionado.UrlImagen != null) {
        if (objetoSeleccionado.UrlImagen != '') {

            var imagenActiva = '';
            /*INICIO IMAGEN SLIDE CONTROL*/
            imagenActiva = ' class="active"';
            htmlImagenSlides.push('<li data-target="#carouselExampleIndicators" data-slide-to="' + 1 + '"' + imagenActiva + '></li>');
            /*FIN IMAGEN SLIDE*/

            /*INICIO IMAGEN SRC*/
            imagenActiva = ' active';
            htmlImagenSrc.push(
                '<div class="carousel-item' + imagenActiva + '">',
                '    <img class="d-block w-100 tamanioimagenproductopopup"',
                '            src="' + objetoSeleccionado.UrlImagen + '" alt="' + objetoSeleccionado.CorreoElectronico + '" style="margin-left: auto;margin-right: auto;">'
            );

            htmlImagenSrc.push(
                '</div>'
            );
            /*FIN IMAGEN SRC*/
        }
    }

    //Resultado
    html.push(
        '<div class="modal-content border-0">',
        '    <div class="card-header bg-white">',
        objetoSeleccionado.CorreoElectronico,
        '    </div>',
        '    <div class="card-body">',
        '        <div id="carouselExampleIndicators" class="carousel slide" style="background-color: #FFF;" data-ride="carousel">',
        '            <ol class="carousel-indicators">'
    );

    html = html.concat(htmlImagenSlides);

    html.push(
        '            </ol>',
        '            <div class="carousel-inner imagenproducto">'
    );

    html = html.concat(htmlImagenSrc);

    html.push(
        '            </div>',
        '            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">',
        '                <span class="carousel-control-prev-icon" aria-hidden="true"></span>',
        '                <span class="sr-only">Anterior</span>',
        '            </a>',
        '            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">',
        '                <span class="carousel-control-next-icon" aria-hidden="true"></span>',
        '                <span class="sr-only">Siguiente</span>',
        '            </a>',
        '        </div>',
        '    </div>',
        '    <div class="card-footer bg-white">',
        '        <a href="#" rel="modal:close" class="btn btn-danger float-right"><i class="fa fa-times" aria-hidden="true"></i> Cerrar</a>',
        '    </div>',
        '</div>'
    );

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}

function GenerarCuerpoModalDeDetalleTemp(objetoSeleccionado) {

    var html = [];

    var htmlImagenSlides = [];
    var htmlImagenSrc = [];

    //Imagenes del carrousel
    if (objetoSeleccionado.ListaImagen != null) {
        if (objetoSeleccionado.ListaImagen.length > 0) {
            objetoSeleccionado.ListaImagen.forEach(function (productoImagen, indice, array) {
                console.log(productoImagen);
                var imagenActiva = '';
                /*INICIO IMAGEN SLIDE CONTROL*/
                if (productoImagen.Predeterminado) {
                    imagenActiva = ' class="active"';
                } else {
                    imagenActiva = '';
                }

                htmlImagenSlides.push('<li data-target="#carouselExampleIndicators" data-slide-to="' + productoImagen.Indice + '"' + imagenActiva + '></li>');
                /*FIN IMAGEN SLIDE*/

                /*INICIO IMAGEN SRC*/

                if (productoImagen.Predeterminado) {
                    imagenActiva = ' active';
                } else {
                    imagenActiva = '';
                }

                htmlImagenSrc.push(
                    '<div class="carousel-item' + imagenActiva + '">',
                    '    <img class="d-block w-100 tamanioimagenproductopopup"',
                    '            src="' + productoImagen.UrlImagen + '" alt="' + objetoSeleccionado.Descripcion + '" style="margin-left: auto;margin-right: auto;">'
                );

                //if (objetoSeleccionado.Descripcion != '') {
                //    htmlImagenSrc.push(
                //        '    <div class="carousel-caption d-none d-md-block">',
                //        //'        <h5>My Caption Title (1st Image)</h5>',
                //        '        <h4><span class="badge badge-secondary">' + objetoSeleccionado.Descripcion + '</span></h4>',
                //        '    </div>'
                //    );
                //}

                htmlImagenSrc.push(
                    '</div>'
                );
                /*FIN IMAGEN SRC*/

            });
        }
    }

    //Resultado
    html.push(
        '<div class="modal-content border-0">',
        '    <div class="card-header bg-white">',
        objetoSeleccionado.Descripcion,
        '    </div>',
        '    <div class="card-body">',
        //'        <div id="carouselExampleIndicators" class="carousel slide" style="background-color: #606060;" data-ride="carousel">',
        '        <div id="carouselExampleIndicators" class="carousel slide" style="background-color: #FFF;" data-ride="carousel">',
        '            <ol class="carousel-indicators">'
    );

    html = html.concat(htmlImagenSlides);

    html.push(
        '            </ol>',
        '            <div class="carousel-inner imagenproducto">'
    );

    html = html.concat(htmlImagenSrc);

    html.push(
        '            </div>',
        '            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">',
        '                <span class="carousel-control-prev-icon" aria-hidden="true"></span>',
        '                <span class="sr-only">Anterior</span>',
        '            </a>',
        '            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">',
        '                <span class="carousel-control-next-icon" aria-hidden="true"></span>',
        '                <span class="sr-only">Siguiente</span>',
        '            </a>',
        '        </div>',
        '        <p class="card-text m-t-10">' + objetoSeleccionado.DescripcionExtendida + '</p>',
        '    </div>',
        '    <div class="card-footer bg-white">',
        '        <a href="#" rel="modal:close" class="btn btn-danger float-right"><i class="fa fa-times" aria-hidden="true"></i> Cerrar</a>',
        '    </div>',
        '</div>'
    );

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}

$(document).on('click', '#btnEliminarSeleccionados', function () {
    if (!$('#btnEliminarSeleccionados').hasClass('disabled')) {
        var dataTableRows = tb1.rows({ selected: true }).data().toArray();
        if (dataTableRows.length > 0) {

            var listaIdsSeleccionados = [];
            dataTableRows.forEach(function (entry) {
                var singleObj = {};
                singleObj['IdUsuario'] = entry.IdUsuario;
                listaIdsSeleccionados.push(singleObj);
            });

            EliminarRegistrosMultiples(JSON.stringify({ 'ListaIdUsuario': listaIdsSeleccionados }));

        } else {
            //mensaje: seleccione un registro
            MensajeError('Error', 'Seleccione un registro');
        }
    }
});

function EliminarRegistrosMultiples(listaId) {
    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'arrayObjeto': listaId
    };

    $.ajax({
        'url': '../../Usuario/EliminarSeleccionados',
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
                    MensajeError('Error', 'Algún registro no existe o ya ha sido eliminado');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo eliminar los registros');
                    break;
                case 1:
                    MensajeSuccess('Confirmación', 'Los registros fueron eliminados satisfactoriamente!');
                    RecargarData();
                    break;
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('body').LoadingOverlay('hide', true);
    });

};

//#endregion


//$(document).on('change', '#cboEstado', function (e) {
//    RecargarData();
//});

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnRecargar').removeClass('disabled');
        $('#btnNuevo').removeClass('disabled');
        $('#btnEliminarSeleccionados').removeClass('disabled');
    } else {
        $('#btnRecargar').addClass('disabled');
        $('#btnNuevo').addClass('disabled');
        $('#btnEliminarSeleccionados').addClass('disabled');
    }
};
