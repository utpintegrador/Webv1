var tb1;

$(document).ready(function () {

    //if (ValidarLogin()) {
    //    ConfigurarCombos();
        $.when(CargarEstado())
            .done(function (resultEstado) {

                var select = $('#cboEstado');
                $.each(resultEstado, function () {
                    select.append($("<option />").val(this.IdEstado).text(this.Descripcion));
                });
    //            $.each(resultEstado, function (i, item) {
    //                select.append('<option value="' + item.IdEstado + '">' + item.Nombre + '</option>');
    //            });
    //            select.trigger('chosen:updated');

                CargarData();
                $("#txtBuscar").focus();

            })
            .fail(function (jqXHR) {
                console.log(jqXHR);
            });
    //}

});

function CargarEstado() {

    var select = $('#cboEstado');
    var prm = {
        'idTipoEstado': 1
    };

    return $.ajax({
        'url': '/Estado/ObtenerPorIdTipoEstado',
        'type': 'GET',
        'data': prm,
        'dataType': 'json',
        beforeSend: function () {
            select.empty();
        }
    });

};


function CargarData() {
    
    $.fn.dataTable.ext.errMode = 'console';
    tb1 = $('#tb1').DataTable({
        "responsive": true,
        "processing": true,
        "language": {
            "processing": "<img src='../img/loading-2.gif' width='100' />"
        },
        "serverSide": true,
        "autoWidth": false,
        "filter": true,
        "orderMulti": false,
        "select": true,
        //"scrollX": true,
        "pagingType": "full_numbers",
        "dom": ObtenerDomGrilla(),
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todo"]],
        "ajax": {
            "url": "/Cliente/ObtenerData",
            "type": "POST",
            "datatype": "json",
            "data": function (d) {
                d.Buscar = $('#txtBuscar').val();
                d.IdEstado = $("#cboEstado").val();
                d.IdUsuario = 1;
            },
            "beforeSend": function (request) {
                //console.log(request);
                //HabilitarControlesMenu(false);
                //request.setRequestHeader("token", 'tokenPersonalizado');

            },
            "complete": function (json, type) {

                //console.log(json);
                //MensajeErrorDataTable(json);
                //HabilitarControlesMenu(true);

            },
            "error": function (xhr, error, thrown) {
                console.log(xhr);
                console.log(error);
                console.log(thrown);
            }
        },
        "columns": ObtenerConfiguracionColumnas(),
        "columnDefs": ObtenerDefinicionBotonColumna(),
        "order": [[1, "desc"]]//id es la columna 2 y esta oculto, por lo tanto, el indice empieza en cero
    });
    tb1.columns.adjust();
};

function ObtenerDomGrilla() {
    return "<'row' <'col-md-12'p>>" +

        "<'clear'>" +
        "<'row' <'col-md-12'rt> >" +
        "<'clear'>" +

        "<'row' <'col-md-6'l> <'col-md-6'> >" +
        "<'row' <'col-md-12'i>>" +
        "<'clear'>";
};

function ObtenerConfiguracionColumnas() {
    //"columns" empieza desde el indice cero
    //Asocia el fieldname hacia una columna especifica 
    return [
        { "data": "Item", "name": "Item", "autoWidth": false, "width": "30px", "orderable": false },
        { "data": "IdCliente", "name": "IdCliente", "visible": false },
        { "data": "NumeroDocumento", "name": "NumeroDocumento", "autoWidth": false, "width": "120px" },
        { "data": "RazonSocial", "name": "RazonSocial" },
        { "data": "DescripcionEstado", "name": "DescripcionEstado", "autoWidth": false, "orderable": true, "width": "60px" },
        { "data": null, "autoWidth": false, "orderable": false, "width": "125px" }
    ];
};

function ObtenerDefinicionBotonColumna() {
    //targets desde indice cero
    return [
        {
            "targets": 5,
            "data": null,
            "className": "text-center",
            "defaultContent": "<button class='btn btn-default btn-sm text-info' id='btnVisualizar'><i class='fa fa-eye' aria-hidden='true'></i></button> " +
                "<button class='btn btn-default btn-sm text-warning' id='btnEditar'><i class='fa fa-pencil' aria-hidden='true'></i></button> " +
                "<button class='btn btn-default btn-sm text-danger' id='btnEliminar'><i class='fa fa-trash-o' aria-hidden='true'></i></button>"
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

$(document).on('click', '#tb1 tbody #btnVisualizar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        window.location.href = '/Cliente/Details/' + fila.IdCliente;
    }
});

$(document).on('click', '#tb1 tbody #btnEditar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        window.location.href = '/Cliente/Edit/' + fila.IdCliente;
    }
});

$(document).on('click', '#tb1 tbody #btnEliminar', function () {
    var fila = tb1.row($(this).parents('tr')).data();
    if (fila !== null) {
        window.location.href = '/Cliente/Delete/' + fila.IdCliente;
    }
});

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

$(document).on('change', '#cboEstado', function (e) {

    RecargarData();

});


//function ProcesarEliminacionRegistro(entidad) {

//    const swalWithBootstrapButtons = Swal.mixin({
//        customClass: {
//            confirmButton: 'btn btn-danger'//,
//            //cancelButton: 'btn btn-transparent'
//        },
//        buttonsStyling: true
//    });

//    swalWithBootstrapButtons.fire({
//        title: "Confirmación",
//        text: "¿ Está seguro de eliminar el registro '" + entidad.RazonSocial + "' ?",
//        type: "question",
//        showCancelButton: true,
//        confirmButtonText: 'Ok!',
//        cancelButtonText: 'No!',
//        confirmButtonColor: '#d33',
//        reverseButtons: true
//    })
//        .then(function (respuesta) {
//            switch (respuesta.value) {
//                case true:
//                    //console.log('se eliminara');        
//                    EliminarRegistro(entidad.IdCliente);
//                    break;
//            }

//        });

//};

//function EliminarRegistro(id) {

//    //primero debe consultarse si existe
//    $.when(ObtenerRegistro(id))
//        .done(function (resultCliente) {

//            if (resultCliente !== null) {

//                //ahora se elimina
//                var prm = {
//                    'Accion': 'Eliminar',
//                    'IdCliente': resultCliente.IdCliente
//                };

//                $.ajax({
//                    'url': '../../ClienteServlet',
//                    'type': 'POST',
//                    'data': prm,
//                    'dataType': 'json',
//                    beforeSend: function () {
//                    }
//                }).done(function (result, textStatus, jqXhr) {

//                    var className = 'btn-success';
//                    var icon = 'success';
//                    var mensaje = 'El registro fue eliminado satisfactoriamente!';
//                    if (result.data <= 0) {
//                        className = 'btn-danger';
//                        icon = 'warning';
//                        mensaje = 'No se pudo eliminar el registro';
//                    } else {
//                        RecargarData();
//                    }
//                    window.swal(mensaje, {
//                        icon: icon,
//                        buttons: {
//                            confirm: {
//                                text: "Ok",
//                                value: true,
//                                visible: true,
//                                className: className,
//                                closeModal: true
//                            }
//                        }
//                    });

//                }).fail(function (jqXHR, textStatus, errorThrown) {

//                });
//            } else {
//                window.swal('El registro no existe o ya ha sido eliminado', {
//                    icon: 'error',
//                    buttons: {
//                        confirm: {
//                            text: "Ok",
//                            value: true,
//                            visible: true,
//                            className: 'btn-danger',
//                            closeModal: true
//                        }
//                    }
//                });
//            };

//        })
//        .fail(function (jqXHR) {

//        });

//};

