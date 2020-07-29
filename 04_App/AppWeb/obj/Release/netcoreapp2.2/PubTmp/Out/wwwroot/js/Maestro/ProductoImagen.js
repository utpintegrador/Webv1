$(document).ready(function () {
    
    ValidacionInicial();
    ProcesarMenuLateral();
    DropZone();

    RecargarData();
});

function RecargarData() {

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    $.when(ObtenerImagenes())
        .done(function (respuestaAjax) {

            if (respuestaAjax != null) {
                if (respuestaAjax.Cuerpo != null) {

                    $('#txtDescripcion').val(respuestaAjax.Cuerpo.Descripcion);

                    if (respuestaAjax.Cuerpo.ListaImagen != null) {
                        if (respuestaAjax.Cuerpo.ListaImagen.length > 0) {
                            var cuerpo = GenerarCuerpoHtml(respuestaAjax.Cuerpo.ListaImagen);
                            $('#divData').empty();
                            $('#divData').append(cuerpo);
                        }
                    }
                }
            }

            $('#frmWrapper').LoadingOverlay('hide', true);
            HabilitarControlesMenu(true);
        })
        .fail(function (jqXHR) {
            $('#frmWrapper').LoadingOverlay('hide', true);
            HabilitarControlesMenu(true);
            console.log(jqXHR);
            console.log('Error al cargar');
        });
}

$(document).on('click', '#btnRecargar', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnRecargar').hasClass('disabled')) {
        RecargarData();
    }
});

function GenerarCuerpoHtml(lista) {
    var html = [];
    lista.forEach(function (item, indice, array) {
        html.push(GenerarCuerpoHtmlIndividual(item));
    });

    var cuerpoHtml = html.join('');
    return cuerpoHtml;
}

function GenerarCuerpoHtmlIndividual(imagen) {

    var html = [];

    html.push('<div class="col-lg-3 col-md-6">');
    html.push('    <div class="card">');
    html.push('        <div class="card-body text-center">');
    html.push('            <a class="image-popup-vertical-fit" data-effect="mfp-zoom-in" href="' + imagen.UrlImagen + '">');
    html.push('                <img class="img-responsive imagenproducto"');//style="height:180px; max-width:300px;" max-height:180px;
    html.push('                    src="' + imagen.UrlImagen + '" alt="' + imagen.UrlImagen + '">');
    html.push('            </a>');
    html.push('            <button class="btn btn-danger btn-sm waves-effect btn-rounded waves-light m-t-15" type="button" id="btnMostrarDetalle" onclick="Eliminar(' + imagen.IdProductoImagen + ');">');
    html.push('                <i class="fa fa-trash-o"></i> Eliminar');
    html.push('            </button>');
    html.push('        </div>');
    html.push('    </div>');
    html.push('</div>');

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}

function Eliminar(id) {
    if (id == null) {
        return;
    }

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
                EliminarRegistro(id);
                break;
            default:
                //console.log('no se eliminara');
                break;
        }

    });
}

function EliminarRegistro(id) {

    $('#divData').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    var prm = {
        'id': id
    };

    $.ajax({
        'url': '../../ProductoImagen/Eliminar',
        'type': 'POST',
        'data': prm,
        'dataType': 'json',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
            HabilitarControlesMenu(false);
        }
    }).done(function (result, textStatus, jqXhr) {
        HabilitarControlesMenu(true);
        $('#divData').LoadingOverlay('hide', true);
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
        $('#divData').LoadingOverlay('hide', true);
    });

};

function ObtenerImagenes() {

    var idProductoTemp = $('#ValorIdProducto').val();

    return $.ajax({
        url: '../../ProductoImagen/Obtener',
        type: 'GET',
        data: {
            'id': idProductoTemp
        },
        dataType: 'json',
        headers: {
            //'Authorization': 'Valor del token debe ir aca'
        },
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
            HabilitarControlesMenu(false);
        },
        complete: function (json) {
            EvaluarRespuesta_401_403(json);
        }
    });
}

//https://stackoverflow.com/questions/17702394/how-do-i-change-the-default-text-in-dropzone-js
function DropZone() {
    // Get the template HTML and remove it from the doumenthe template HTML and remove it from the doument
    var previewNode = document.querySelector("#template");
    previewNode.id = "";
    var previewTemplate = previewNode.parentNode.innerHTML;
    previewNode.parentNode.removeChild(previewNode);

    var myDropzone = new Dropzone(document.body, { // Make the whole body a dropzone
        url: '../../ProductoImagen/SubirImagenes', // Set the url
        thumbnailWidth: 80,
        thumbnailHeight: 80,
        parallelUploads: 1,
        maxFiles: 5,
        maxFilesize: 0.3,
        previewTemplate: previewTemplate,
        autoQueue: false, // Make sure the files aren't queued until manually added
        previewsContainer: "#previews", // Define the container to display the previews
        clickable: ".fileinput-button", // Define the element that should be used as click trigger to select files.
        dictDefaultMessage: "Arrastrar archivos en esta zona",
        dictFileTooBig: "Archivo muy grande ({{filesize}}MiB). Máximo tamaño permitido: {{maxFilesize}}MiB.",
        dictMaxFilesExceeded: "No esta permitido cargar mas archivos.",
        acceptedFiles: "image/*"
    });

    myDropzone.on("addedfile", function (file) {
        // Hookup the start button
        file.previewElement.querySelector(".start").onclick = function () {
            myDropzone.enqueueFile(file);
        };
    });

    // Update the total progress bar
    myDropzone.on("totaluploadprogress", function (progress) {
        document.querySelector("#total-progress .progress-bar").style.width = progress + "%";
    });

    myDropzone.on("sending", function (file, xhr, formData) {

        $('#seccionSubirImagenes').LoadingOverlay('show', {
            background: 'rgba(25, 118, 210, 0.1)'
        });

        var idProductoActual = $('#ValorIdProducto').val();
        formData.append('IdProducto', idProductoActual);
        // Show the total progress bar when upload starts
        document.querySelector("#total-progress").style.opacity = "1";
        // And disable the start button
        file.previewElement.querySelector(".start").setAttribute("disabled", "disabled");
    });

    myDropzone.on("complete", function (file) {
        myDropzone.removeFile(file);
    });

    // Hide the total progress bar when nothing's uploading anymore
    myDropzone.on("queuecomplete", function (progress) {
        document.querySelector("#total-progress").style.opacity = "0";

        $('#seccionSubirImagenes').LoadingOverlay('hide', true);
        RecargarData();
        MensajeSuccess('Confirmación', 'Se completó la carga de imagenes');
    });

    // Setup the buttons for all transfers
    // The "add files" button doesn't need to be setup because the config
    // `clickable` has already been specified.
    document.querySelector("#actions .start").onclick = function () {
        myDropzone.enqueueFiles(myDropzone.getFilesWithStatus(Dropzone.ADDED));
    };
    //document.querySelector("#actions .cancel").onclick = function () {
    //    myDropzone.removeAllFiles(true);
    //};
}

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnRecargar').removeClass('disabled');
        $('#btnRetornar').removeClass('disabled');
        $('#btnAgregarImagenes').removeClass('disabled');
        $('#btnIniciarSubida').removeClass('disabled');
        $('#btnEliminarItem').removeClass('disabled');
    } else {
        $('#btnRecargar').addClass('disabled');
        $('#btnRetornar').addClass('disabled');
        $('#btnAgregarImagenes').addClass('disabled');
        $('#btnIniciarSubida').addClass('disabled');
        $('#btnEliminarItem').addClass('disabled');
    }
};
