var tb1;

$(document).ready(function () {
    $(".select2").select2();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    ProcesarCargaDeMoneda();
});

function ProcesarCargaDeMoneda() {

    $('#frmWrapper').LoadingOverlay('hide', true);
    //Cargar la grilla
    CargarData();

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
            "url": "../../Moneda/ObtenerData",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.Buscar = $('#txtBuscar').val();
            },
            "beforeSend": function (request) {
                //console.log(request);
                HabilitarControlesMenu(false);
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
        { "data": "IdMoneda", "name": "IdMoneda", "visible": false },
        { "data": "Descripcion", "name": "Descripcion" },
        { "data": "Simbolo", "name": "Simbolo" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumna() {
    //targets desde indice cero
    return [
        {
            "targets": 4,
            "width": "125px",
            "data": null,
            "className": "text-center",
            "defaultContent": "<div class='btn-group' role='group' aria-label='Basic example'>" +
                //"<button class='btn btn-primary btn-sm' id='btnVisualizar'><i class='fa fa-eye' aria-hidden='true'></i></button> " +
                "<button class='btn btn-success btn-sm' id='btnEditar'><i class='fa fa-pencil' aria-hidden='true'></i></button> " +
                "<button class='btn btn-danger btn-sm' id='btnEliminar'><i class='fa fa-trash-o' aria-hidden='true'></i></button>" +
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
            text: "¿Está seguro de eliminar el registro " + fila.Descripcion + "?",
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
                    EliminarRegistro(fila.IdMoneda);
                    break;
                default:
                    //console.log('no se eliminara');
                    break;
            }

        });

    }
});

function EliminarRegistro(id) {

    var prm = {
        'id': id
    };

    $.ajax({
        'url': '../../Moneda/Eliminar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        beforeSend: function () {
        }
    }).done(function (result, textStatus, jqXhr) {

        if (result.ProcesadoOk != null) {
            switch (result.ProcesadoOk) {
                case -1:
                    MensajeError('Error', 'El registro no existe o ya ha sido eliminado');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo eliminar el registro');
                    break;
                case 1:
                    MensajeInfo('Confirmación', 'El registro fue eliminado satisfactoriamente!');
                    RecargarData();
                    break;
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

};

$(document).on('click', '#tb1 tbody #btnEditar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        window.location.href = '/Moneda/Edit/' + fila.IdMoneda;
    }
});


function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Moneda/ObtenerPorId',
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

//$(document).on('change', '#cboMoneda', function (e) {
//    RecargarData();
//});

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
        $('#btnRecargar').removeClass('disabled');
        $('#btnNuevo').removeClass('disabled');
    } else {
        $('#btnRecargar').addClass('disabled');
        $('#btnNuevo').addClass('disabled');
    }
};
