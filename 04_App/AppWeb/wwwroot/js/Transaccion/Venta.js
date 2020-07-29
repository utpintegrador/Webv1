var tb1;
var tb2;
window._idPedidoSeleccionado;
var ventanaModal;
window._idNegocioVendedorModal;
window._idPedidoModal;
window._idEstadoModal;

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();
    EstablecerDatePickers();    

    $(".select2").select2();
    ventanaModal = $('#sticky');
    $("#divTrazabilidad").hide();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    ProcesarCargaDeObjetos();
 
});

function EstablecerDatePickers() {
    var fechaInicio = moment().startOf('month').format('YYYY/MM/DD');
    var fechaFin = moment().endOf('month').format('YYYY/MM/DD');

    flatpickr('#dtFechaDesde', {
        dateFormat: 'Y/m/d',
        allowInput: false,
        clickOpens: true,
        enableTime: false,
        inline: false,
        weekNumbers: true,
        prevArrow: '&lt;',
        nextArrow: '&gt;',
        defaultDate: fechaInicio,
        locale: {
            firstDayOfWeek: 0,
            weekdays: {
                shorthand: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                longhand: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            },
            months: {
                shorthand: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Оct', 'Nov', 'Dic'],
                longhand: ['Enero', 'Febreo', 'Мarzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            },
        }
    });
    flatpickr('#dtFechaHasta', {
        dateFormat: 'Y/m/d',
        allowInput: false,
        clickOpens: true,
        enableTime: false,
        inline: false,
        weekNumbers: true,
        prevArrow: '&lt;',
        nextArrow: '&gt;',
        defaultDate: fechaFin,
        locale: {
            firstDayOfWeek: 0,
            weekdays: {
                shorthand: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                longhand: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            },
            months: {
                shorthand: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Оct', 'Nov', 'Dic'],
                longhand: ['Enero', 'Febreo', 'Мarzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            },
        }
    });
}

function ProcesarCargaDeObjetos() {

    $.when(ObtenerNegocios(), ObtenerEstados(), ObtenerMonedas())
        .done(function (respuestaNegociosAjax, respuestaEstadosAjax, respuestaMonedasAjax) {

            var cboNegocio = $('#cboNegocio');
            cboNegocio.append($('<option/>', { value: 0, text: 'Todos' }));
            var cboEstado = $('#cboEstado');
            cboEstado.append($('<option/>', { value: 0, text: 'Todos' }));
            cboEstado.select2({
                minimumResultsForSearch: Infinity
            });
            var cboMoneda = $('#cboMoneda');
            cboMoneda.append($('<option/>', { value: 0, text: 'Todos' }));
            cboMoneda.select2({
                minimumResultsForSearch: Infinity
            });

            if (respuestaNegociosAjax[0].Cuerpo != null) {
                if (respuestaNegociosAjax[0].Cuerpo.length > 0) {
                    respuestaNegociosAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboNegocio.append($('<option/>', { value: item.IdNegocio, text: item.Nombre }));
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

            if (respuestaMonedasAjax[0].Cuerpo != null) {
                if (respuestaMonedasAjax[0].Cuerpo.length > 0) {
                    respuestaMonedasAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboMoneda.append($('<option/>', { value: item.IdMoneda, text: item.Descripcion }));
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

function ObtenerEstados() {
    //'primerItem': 'Todos'
    var select = $('#cboEstado');
    return $.ajax({
        url: '../../Estado/ObtenerCombo',
        type: 'GET',
        data: {
            'idTipoEstado': 3
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

function ObtenerMonedas() {
    //'primerItem': 'Todos'
    var select = $('#cboMoneda');
    return $.ajax({
        url: '../../Moneda/ObtenerCombo',
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
            "url": "../../Venta/ObtenerPorIdUsuario",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.IdUsuario = GetItem('IdUsuario');
                d.IdNegocioVendedor = $("#cboNegocio").val();
                d.Buscar = '';
                d.IdEstado = $('#cboEstado').val();
                d.IdMoneda = $('#cboMoneda').val();
                d.FechaDesde = $('#dtFechaDesde').val();
                d.FechaHasta = $('#dtFechaHasta').val();
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
            EstablecerFormatoCabeceraCeldaSegunValor(nRow, aData, iDisplayIndex, iDisplayIndexFull);
        },
        "order": [[2, "asc"]]//id es la columna 2 y esta oculto, por lo tanto, el indice empieza en cero
    });
    tb1.columns.adjust();

    $('div.dataTables_length select').addClass('selectDt');
    $(".selectDt").select2({
        minimumResultsForSearch: Infinity
    });
};

function EstablecerFormatoCabeceraCeldaSegunValor(nRow, aData) {
    //nRow: obtiene toda la etiqueta <TR>
    //aData: obtiene el datasource de cada fila
    //iDisplayIndex: obtiene el indice de cada fila empezando desde cero
    //iDisplayIndexFull: obtiene el indice de cada fila empezando desde cero

    //console.log(aData);
    //A partir del indice 0 y sin contar los ocultos
    if ($(nRow) != null) {
        //$(nRow).removeClass('fondoEntregado');
        $(nRow).removeClass('fondoCancelado');
    }

    //if (aData.DescripcionEstado == 'Entregado') {
        //$('td:eq(3)', nRow).html('<i class="fa fa-check-square-o" aria-hidden="true"></i>');
        //$(nRow).addClass('fondoEntregado');
        //$('td:eq(2)', nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).removeClass('fondoFinalizado');
        //} else if (aData.IdEstado === 5) {
        //    $(nRow).addClass('fondoRechazado');
        //$('td:eq(2)', nRow).addClass('fondoFinalizado');
        //$('td:eq(2)', nRow).removeClass('fondoFinalizado');
    //} else
    if (aData.DescripcionEstado == 'Rechazado' || aData.DescripcionEstado == 'Cancelado') {
        $(nRow).addClass('fondoCancelado');
    };
    //else {
    //    $(nRow).removeClass('fondoEntregado');
    //};
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
        { "data": "IdPedido", "name": "IdPedido", "visible": false },
        { "data": "DocumentoIdentificacionVendedor", "name": "DocumentoIdentificacionVendedor" },
        { "data": "NombreNegocioVendedor", "name": "NombreNegocioVendedor" },
        { "data": "DocumentoIdentificacionComprador", "name": "DocumentoIdentificacionComprador" },
        { "data": "NombreNegocioComprador", "name": "NombreNegocioComprador" },
        { "data": "DescripcionMoneda", "name": "DescripcionMoneda" },
        {
            "data": "Total",
            "name": "Total",
            render: $.fn.dataTable.render.number(',', '.', 2, '')
        },
        { "data": "DescripcionEstado", "name": "DescripcionEstado" },
        { "data": "FechaRegistro", "name": "FechaRegistro" },
        { "data": "FechaActualizacion", "name": "FechaActualizacion" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumna() {
    //targets desde indice cero
    return [
        //{
        //    "targets": 3,
        //    className: 'dt-body-right'
        //},
        {
            "targets": 11,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                //"<button class='btn btn-dark btn-sm m-r-5' id='btnGestionarImagenes'><i class='fa fa-picture-o' aria-hidden='true'></i></button> " +
                "<button class='btn btn-primary btn-sm m-r-5' id='btnVisualizar'><i class='fa fa-eye' aria-hidden='true'></i></button> " +
                "<button class='btn btn-success btn-sm m-r-5' id='btnCambiarEstado'><i class='fa fa-calendar-check-o' aria-hidden='true'></i></button> " +
                //"<button class='btn btn-success btn-sm m-r-5' id='btnEditar'><i class='fa fa-pencil' aria-hidden='true'></i></button> " +
                //"<button class='btn btn-danger btn-sm' id='btnEliminar'><i class='fa fa-trash-o' aria-hidden='true'></i></button>" +
                "</div>"
        }
    ];
};

$(document).on('click', '#btnRecargar', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnRecargar').hasClass('disabled')) {

        //sessionStorage.setItem('IdNegocio', $('#cboNegocio').val());

        RecargarData();
    }
});

function RecargarData() {

    tb1.ajax.reload();
    //$("#txtBuscar").focus();

};

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnRecargar').removeClass('disabled');
    } else {
        $('#btnRecargar').addClass('disabled');
    }
};

//Detalle
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
            "url": "../../PedidoDetalle/ObtenerData",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.IdPedido = window._idPedidoSeleccionado;
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
        //"columnDefs": ObtenerDefinicionBotonColumnaDetalle(),
        //"fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        //    EstablecerFormatoCeldaSegunValor(nRow, aData, iDisplayIndex, iDisplayIndexFull);
        //},
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

        //"<'row' <'col-md-6'l> <'col-md-6'p> >" +
        "<'row' <'col-md-12'i>>" +
        "<'clear'>" +
        "<'clear'>";
};

function ObtenerConfiguracionColumnaDetalle() {
    //"columns" empieza desde el indice cero
    //Asocia el fieldname hacia una columna especifica 
    return [
        { "data": "Item", "name": "Item", "autoWidth": false, "width": "30px", "orderable": false },
        { "data": "IdPedidoDetalle", "name": "IdPedidoDetalle", "visible": false },
        { "data": "DescripcionProducto", "name": "DescripcionProducto" },
        {
            "data": "Cantidad",
            "name": "Cantidad",
            render: $.fn.dataTable.render.number(',', '.', 2, '')
        },
        {
            "data": "PrecioUnitario",
            "name": "PrecioUnitario",
            render: $.fn.dataTable.render.number(',', '.', 2, '')
        }
        //,
        //{ "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumnaDetalle() {
    //targets desde indice cero
    return [
        {
            "targets": [3, 4],
            className: 'dt-body-right'
        },
        {
            "targets": 5,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                "<button class='btn btn-danger btn-sm' id='btnEliminarDetalle'><i class='fa fa-trash-o' aria-hidden='true'></i></button>" +
                "</div>"
        }
    ];
};

$(document).on('click', '#tb1 tbody tr td', function () {
    var fila = tb1.row($(this).parents('tr')).data();

    var filasSeleccionadas = tb1.rows({ selected: true }).data().toArray();
    if (filasSeleccionadas.length > 0) {
        if (fila.IdPedido === null) {
            window._idPedidoSeleccionado = 0;
            $("#divTrazabilidad").hide();
        }
        else {
            window._idPedidoSeleccionado = fila.IdPedido;
            ProcesarTrazabilidad(window._idPedidoSeleccionado);
        }
    } else {
        window._idPedidoSeleccionado = 0;
        $("#divTrazabilidad").hide();
    }

    tb2.ajax.reload();
});

$(document).on('click', '#tb1 tbody #btnVisualizar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {

        window.location.href = '/Venta/Details/' + fila.IdPedido;

    }
});

$(document).on('click', '#tb1 tbody #btnCambiarEstado', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {

        $('body').LoadingOverlay('show', {
            background: 'rgba(25, 118, 210, 0.1)'
        });

        $.when(ObtenerPorId(fila.IdPedido))
            .done(function (respuestaAjaxPorId) {

                if (respuestaAjaxPorId != null) {
                    if (respuestaAjaxPorId.Cuerpo != null) {

                        if (respuestaAjaxPorId.Cuerpo.IdEstado >= 11) {
                            $('body').LoadingOverlay('hide', true);
                            MensajeInfo('Información', 'El pedido ya se ha completado');
                        }
                        else {
                            $.when(ObtenerComboVendedor(respuestaAjaxPorId.Cuerpo.IdEstado))
                                .done(function (respuestaComboAjaxPorId) {
                                    if (respuestaComboAjaxPorId != null) {
                                        if (respuestaComboAjaxPorId.Cuerpo != null) {

                                            $('body').LoadingOverlay('hide', true);

                                            var cboEstadoNuevo = $('#cboEstadoNuevo');
                                            cboEstadoNuevo.empty();
                                            //cboEstadoNuevo.append($('<option/>', { value: 0, text: 'Seleccione' }));
                                            cboEstadoNuevo.select2({
                                                minimumResultsForSearch: Infinity
                                            });
                                            respuestaComboAjaxPorId.Cuerpo.forEach(function (item, indice, array) {
                                                cboEstadoNuevo.append($('<option/>', { value: item.IdEstado, text: item.Descripcion }));
                                            });

                                            window._idNegocioVendedorModal = respuestaAjaxPorId.Cuerpo.IdNegocioVendedor;
                                            window._idPedidoModal = respuestaAjaxPorId.Cuerpo.IdPedido;

                                            ventanaModal.modal({
                                                escapeClose: true,
                                                clickClose: true,
                                                showClose: true,
                                                fadeDuration: 100,
                                                fadeDelay: 0.40
                                            });
                                        } else {
                                            $('body').LoadingOverlay('hide', true);
                                        }
                                    } else {
                                        $('body').LoadingOverlay('hide', true);
                                    }
                                })
                                .fail(function (jqXHR) {
                                    console.log(jqXHR);
                                    console.log('Error');
                                    $('body').LoadingOverlay('hide', true);
                                });
                        }

                    } else {
                        $('body').LoadingOverlay('hide', true);
                    }
                } else {
                    $('body').LoadingOverlay('hide', true);
                }

            })
            .fail(function (jqXHR) {
                console.log(jqXHR);
                console.log('Error');
                $('body').LoadingOverlay('hide', true);
            });

    }
});

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Pedido/ObtenerPorId',
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

function ObtenerComboVendedor(id) {
    return $.ajax({
        url: '../../Estado/ObtenerComboVendedor',
        type: 'GET',
        data: {
            'idEstadoActual': id
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

$(document).on('click', '#btnGuardarCambioEstado', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnGuardarCambioEstado').hasClass('disabled')) {
        ActualizarEstado();
    }
});

function ActualizarEstado() {

    $('body').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'IdPedido': window._idPedidoModal,
        'IdNegocioVendedor': window._idNegocioVendedorModal,
        'IdEstado': $("#cboEstadoNuevo").val()
    };

    $.ajax({
        'url': '../../Pedido/ModificarEstadoPorParteDeVendedor',
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

        $('body').LoadingOverlay('hide', true);
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
                        RecargarData();
                        break;
                }
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('body').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });

};

function ProcesarTrazabilidad(idPedido) {
    if (idPedido == 0) {
        $("#divTrazabilidad").hide();
    } else {
        $("#divTrazabilidad").show();
        $('#divRechazado').hide();
        $('#divCancelado').hide();
        $('#divEntregado').hide();
        $('#divEntregando').hide();
        $('#divPreparando').hide();
        $('#divAceptado').hide();
        $('#divGenerado').hide();

        $('#divTrazabilidad').LoadingOverlay('show', {
            background: 'rgba(25, 118, 210, 0.1)'
        });
        $.when(ObtenerTrazabilidadPorIdPedido(idPedido))
            .done(function (respuestaAjax) {

                $('#divTrazabilidad').LoadingOverlay('hide', true);
                if (respuestaAjax != null) {
                    if (respuestaAjax.Cuerpo != null) {
                        if (respuestaAjax.Cuerpo.length > 0) {
                            respuestaAjax.Cuerpo.forEach(function (item, indice, array) {

                                switch (item.DescripcionEstado) {
                                    case 'Generado':
                                        $('#divGenerado').show();
                                        $('#txtFechaGenerado').html(item.FechaRegistro);
                                        $('#txtUsuarioGenerado').html(item.CorreoElectronico);
                                        break;
                                    case 'Aceptado':
                                        $('#divAceptado').show();
                                        $('#txtFechaAceptado').html(item.FechaRegistro);
                                        $('#txtUsuarioAceptado').html(item.CorreoElectronico);
                                        break;
                                    case 'Preparando':
                                        $('#divPreparando').show();
                                        $('#txtFechaPreparando').html(item.FechaRegistro);
                                        $('#txtUsuarioPreparando').html(item.CorreoElectronico);
                                        break;
                                    case 'Entregando':
                                        $('#divEntregando').show();
                                        $('#txtFechaEntregando').html(item.FechaRegistro);
                                        $('#txtUsuarioEntregando').html(item.CorreoElectronico);
                                        break;
                                    case 'Entregado':
                                        $('#divEntregado').show();
                                        $('#txtFechaEntregado').html(item.FechaRegistro);
                                        $('#txtUsuarioEntregado').html(item.CorreoElectronico);
                                        break;
                                    case 'Cancelado':
                                        $('#divCancelado').show();
                                        $('#txtFechaCancelado').html(item.FechaRegistro);
                                        $('#txtUsuarioCancelado').html(item.CorreoElectronico);
                                        break;
                                    case 'Rechazado':
                                        $('#divRechazado').show();
                                        $('#txtFechaRechazado').html(item.FechaRegistro);
                                        $('#txtUsuarioRechazado').html(item.CorreoElectronico);
                                        break;
                                    default:
                                        break;
                                }
                            });
                        } else {
                            $("#divTrazabilidad").hide();
                        }
                    }
                }

            })
            .fail(function (jqXHR) {
                $('#divTrazabilidad').LoadingOverlay('hide', true);
                console.log(jqXHR);
                console.log('Error al cargar los resumenes actuales');
            });

    }
}

function ObtenerTrazabilidadPorIdPedido(id) {
    return $.ajax({
        url: '../../PedidoControlEstado/ObtenerPorIdPedido',
        type: 'GET',
        data: {
            'idPedido': id
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