window._idUsuario = 0;
window._idUsuario = 0;
window._mensajeValidacion = '';

$(document).ready(function () {
    //$('.selectpicker').selectpicker();
    $(".select2").select2();
    //DropZone();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');
    window._idUsuario = ObtenerParametroUrl();

    $.when(ObtenerTiposUsuario(), ObtenerEstados(), ObtenerPorId(window._idUsuario))
        .done(function (respuestaTiposUsuarioAjax, respuestaEstadosAjax, respuestaUsuarioPorId) {

            var cboTipoUsuario = $('#cboTipoUsuario');
            cboTipoUsuario.append($('<option/>', { value: 0, text: 'Seleccione' }));
            var cboEstado = $('#cboEstado');
            cboEstado.append($('<option/>', { value: 0, text: 'Seleccione' }));

            if (respuestaEstadosAjax[0].Cuerpo != null) {
                if (respuestaEstadosAjax[0].Cuerpo.length > 0) {
                    respuestaEstadosAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboEstado.append($('<option/>', { value: item.IdEstado, text: item.Descripcion }));
                    });
                }
            }

            if (respuestaTiposUsuarioAjax[0].Cuerpo != null) {
                if (respuestaTiposUsuarioAjax[0].Cuerpo.length > 0) {
                    respuestaTiposUsuarioAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboTipoUsuario.append($('<option/>', { value: item.IdTipoUsuario, text: item.Descripcion }));
                    });
                }
            }

            cboTipoUsuario.val(respuestaUsuarioPorId[0].Cuerpo.IdTipoUsuario).trigger('change');
            cboEstado.val(respuestaUsuarioPorId[0].Cuerpo.IdEstado).trigger('change');
            $('#txtCorreoElectronico').val(respuestaUsuarioPorId[0].Cuerpo.CorreoElectronico);
            $('#txtNombre').val(respuestaUsuarioPorId[0].Cuerpo.Nombre);
            $('#txtApellido').val(respuestaUsuarioPorId[0].Cuerpo.Apellido);

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });

});

//#region Funciones Ajax
function ObtenerTiposUsuario() {
    //'primerItem': 'Todos'
    var select = $('#cboTipoUsuario');
    return $.ajax({
        url: '../../TipoUsuario/ObtenerCombo',
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
        url: '../../Usuario/ObtenerPorId',
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
        'IdUsuario': window._idUsuario,
        'CorreoElectronico': $("#txtCorreoElectronico").val(),
        'Nombre': $("#txtNombre").val(),
        'Apellido': $("#txtApellido").val(),
        'IdEstado': $("#cboEstado").val(),
        'IdTipoUsuario': $("#cboTipoUsuario").val()
    };

    $.ajax({
        'url': '../../Usuario/ModificarModoAdmin',
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

    if ($("#txtCorreoElectronico").val() == '' || $("#txtCorreoElectronico").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [CorreoElectronico] es requerido ';
    }

    if ($("#txtNombre").val() == '' || $("#txtNombre").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Nombre] es requerido ';
    }

    if ($("#txtApellido").val() == '' || $("#txtApellido").val() == null) {
        window._mensajeValidacion = window._mensajeValidacion + ' * El campo [Apellido] es requerido ';
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

$(document).on('click', '#btnCambiarImagen', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnCambiarImagen').hasClass('disabled')) {
        var cuerpoModal = GenerarCuerpoModalDeVisualizar();
        $('#sticky').empty();
        $('#sticky').append(cuerpoModal);

        $('#sticky').modal({
            escapeClose: true,
            clickClose: false,
            showClose: true
        });
        $('#fileInput').dropify();
    }
});

function GenerarCuerpoModalDeVisualizar() {

    var html = [];

    html.push(
        '<div class="row">',
        '    <div class="col-md-12">',
        '        <form id="uploader" onsubmit="return false">',
        '            <label for="fileInput">Seleccione imágen</label>',
        '            <input id="fileInput" type="file" class="dropify" data-max-file-size="300KB">',//multiple
        '            <center class="m-t-10">',
        '               <button id="btnSubir" type="submit" class="btn btn-primary btn-sm"><i class="fa fa-upload" aria-hidden="true"></i> Subir</button>',
        '            </center>',
        '        </form>',
        '    </div>',
        '</div>',
    );

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}

$(document).on('click', '#btnEliminarImagen', function () {
    if (!$('#btnEliminarImagen').hasClass('disabled')) {
        var prm = {
            'id': window._idUsuario
        };

        $.ajax({
            'url': '../../Usuario/EliminarImagen',
            'type': 'POST',
            'data': prm,
            'dataType': 'json',
            headers: {
                'Authorization': 'Valor del token debe ir aca'
            },
            beforeSend: function () {
            }
        }).done(function (result, textStatus, jqXhr) {

            var mensaje = 'Error al intentar eliminar el registro';
            var icon = 'success';
            var className = 'btn btn-success';

            if (result != null) {
                switch (result.ProcesadoOk) {
                    case -1:
                        mensaje = 'El registro no existe';
                        icon = 'error';
                        className = 'btn btn-danger';
                        break;
                    case 0:
                        mensaje = 'No se pudo modificar el registro';
                        icon = 'error';
                        className = 'btn btn-danger';
                        break;
                    case 1:
                        mensaje = 'El registro fue modificado satisfactoriamente!';
                        break;
                }
            }

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: className
                },
                buttonsStyling: false
            });

            swalWithBootstrapButtons.fire({
                title: "Confirmación",
                text: mensaje,
                icon: icon,
                confirmButtonText: 'Ok!',
                reverseButtons: true
            });

        }).fail(function (jqXHR, textStatus, errorThrown) {

        });
    }
});
