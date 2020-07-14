window._idUsuario = 0;
window._idProducto = 0;
window._mensajeValidacion = '';

$(document).ready(function () {
    //$('.selectpicker').selectpicker();
    $(".select2").select2();
    //DropZone();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');
    window._idProducto = ObtenerParametroUrl();

    $.when(ObtenerNegocios(), ObtenerEstados(), ObtenerMonedas(), ObtenerCategorias(), ObtenerPorId(window._idProducto))
        .done(function (respuestaNegociosAjax, respuestaEstadosAjax, respuestaMonedasAjax, respuestaCategoriasAjax, respuestaProductoPorId) {

            var cboNegocio = $('#cboNegocio');
            cboNegocio.append($('<option/>', { value: 0, text: 'Seleccione' }));
            var cboEstado = $('#cboEstado');
            cboEstado.append($('<option/>', { value: 0, text: 'Seleccione' }));
            var cboMoneda = $('#cboMoneda');
            cboMoneda.append($('<option/>', { value: 0, text: 'Seleccione' }));
            var cboCategoria = $('#cboCategoria');
            cboCategoria.append($('<option/>', { value: 0, text: 'Seleccione' }));

            if (respuestaNegociosAjax[0].Cuerpo != null) {
                if (respuestaNegociosAjax[0].Cuerpo.length > 0) {
                    respuestaNegociosAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboNegocio.append($('<option/>', { value: item.IdNegocio, text: item.DocumentoIdentificacion + '-' + item.Nombre }));
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

            if (respuestaCategoriasAjax[0].Cuerpo != null) {
                if (respuestaCategoriasAjax[0].Cuerpo.length > 0) {
                    respuestaCategoriasAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboCategoria.append($('<option/>', { value: item.IdCategoria, text: item.Descripcion }));
                    });
                }
            }

            cboNegocio.val(respuestaProductoPorId[0].Cuerpo.IdNegocio).trigger('change');
            cboEstado.val(respuestaProductoPorId[0].Cuerpo.IdEstado).trigger('change');
            cboMoneda.val(respuestaProductoPorId[0].Cuerpo.IdMoneda).trigger('change');
            cboCategoria.val(respuestaProductoPorId[0].Cuerpo.IdCategoria).trigger('change');

            $('#txtDescripcion').val(respuestaProductoPorId[0].Cuerpo.Descripcion);
            $('#txtPrecio').val(respuestaProductoPorId[0].Cuerpo.Precio);
            $('#txtDescripcionExtendida').val(respuestaProductoPorId[0].Cuerpo.DescripcionExtendida);

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });

});

//#region Funciones Main
function DropZone() {
    // Get the template HTML and remove it from the doumenthe template HTML and remove it from the doument
    var previewNode = document.querySelector("#template");
    previewNode.id = "";
    var previewTemplate = previewNode.parentNode.innerHTML;
    previewNode.parentNode.removeChild(previewNode);

    var myDropzone = new Dropzone(document.body, { // Make the whole body a dropzone
        url: "/target-url", // Set the url
        thumbnailWidth: 80,
        thumbnailHeight: 80,
        parallelUploads: 20,
        previewTemplate: previewTemplate,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#previews", // Define the container to display the previews
        clickable: ".fileinput-button" // Define the element that should be used as click trigger to select files.
    });

    myDropzone.on("addedfile", function (file) {
        // Hookup the start button
        file.previewElement.querySelector(".start").onclick = function () { myDropzone.enqueueFile(file); };
    });

    // Update the total progress bar
    myDropzone.on("totaluploadprogress", function (progress) {
        document.querySelector("#total-progress .progress-bar").style.width = progress + "%";
    });

    myDropzone.on("sending", function (file) {
        // Show the total progress bar when upload starts
        document.querySelector("#total-progress").style.opacity = "1";
        // And disable the start button
        file.previewElement.querySelector(".start").setAttribute("disabled", "disabled");
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzone.on("queuecomplete", function (progress) {
        document.querySelector("#total-progress").style.opacity = "0";
    });

    // Setup the buttons for all transfers
    // The "add files" button doesn't need to be setup because the config
    // `clickable` has already been specified.
    document.querySelector("#actions .start").onclick = function () {
        myDropzone.enqueueFiles(myDropzone.getFilesWithStatus(Dropzone.ADDED));
    };
    document.querySelector("#actions .cancel").onclick = function () {
        myDropzone.removeAllFiles(true);
    };
}
//#endregion

//#region Funciones Ajax
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
            'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
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

function ObtenerMonedas() {
    //'primerItem': 'Todos'
    var select = $('#cboMoneda');
    return $.ajax({
        url: '../../Moneda/ObtenerCombo',
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

function ObtenerCategorias() {
    //'primerItem': 'Todos'
    var select = $('#cboCategoria');
    return $.ajax({
        url: '../../Categoria/ObtenerCombo',
        type: 'GET',
        data: {
            'idEstado': 1
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

function ObtenerPorId(id) {
    return $.ajax({
        url: '../../Producto/ObtenerPorId',
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
//#endregion

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
        'IdProducto': window._idProducto,
        'Descripcion': $("#txtDescripcion").val(),
        'DescripcionExtendida': $("#txtDescripcionExtendida").val(),
        'Precio': $("#txtPrecio").val(),
        'IdMoneda': $("#cboMoneda").val(),
        'IdCategoria': $("#cboCategoria").val(),
        'IdNegocio': $("#cboNegocio").val(),
        'IdEstado': $("#cboEstado").val()
    };

    $.ajax({
        'url': '../../Producto/Modificar',
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

    if ($("#txtDescripcion").val() == '' || $("#txtDescripcion").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Descripcion] es requerido ';
    }

    if ($("#cboNegocio").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Negocio] es requerido ';
    }

    if ($("#txtPrecio").val() == '' || $("#txtPrecio").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Precio] es requerido ';
    }

    if ($("#cboMoneda").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Moneda] es requerido ';
    }

    if ($("#cboCategoria").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Categoria] es requerido ';
    }

    if ($("#cboEstado").val() == 0) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Estado] es requerido ';
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