$(document).ready(function () {
    
    ValidacionInicial();
    ProcesarMenuLateral();
    $(".select2").select2();

    DropZone();

    RecargarData();
});

function RecargarData() {

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    $.when(ObtenerNegocios(), ObtenerMonedas(), ObtenerCategorias())
        .done(function (respuestaNegociosAjax, respuestaMonedasAjax, respuestaCategoriasAjax) {

            var cboNegocio = $('#cboNegocio');
            cboNegocio.append($('<option/>', { value: 0, text: 'Seleccione' }));

            var cboMoneda = $('#cboMoneda');
            cboMoneda.append($('<option/>', { value: 0, text: 'Seleccione' }));
            cboMoneda.select2({
                minimumResultsForSearch: Infinity
            });

            var cboCategoria = $('#cboCategoria');
            cboCategoria.append($('<option/>', { value: 0, text: 'Seleccione' }));

            if (respuestaNegociosAjax[0].Cuerpo != null) {
                if (respuestaNegociosAjax[0].Cuerpo.length > 0) {
                    respuestaNegociosAjax[0].Cuerpo.forEach(function (item, indice, array) {
                        cboNegocio.append($('<option/>', { value: item.IdNegocio, text: item.Nombre }));
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

            $('#frmWrapper').LoadingOverlay('hide', true);



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

function DropZone() {
    var previewNode = document.querySelector("#template");
    previewNode.id = "";
    var previewTemplate = previewNode.parentNode.innerHTML;
    previewNode.parentNode.removeChild(previewNode);

    var myDropzone = new Dropzone(document.body, { 
        url: '../../Producto/SubirArchivo', 
        thumbnailWidth: 80,
        thumbnailHeight: 80,
        parallelUploads: 1,
        maxFiles: 1,
        maxFilesize: 0.5,
        previewTemplate: previewTemplate,
        autoQueue: false, 
        previewsContainer: "#previews", 
        clickable: ".fileinput-button", 
        dictDefaultMessage: "Arrastrar archivos en esta zona",
        dictFileTooBig: "Archivo muy grande ({{filesize}}MiB). Máximo tamaño permitido: {{maxFilesize}}MiB.",
        dictMaxFilesExceeded: "No esta permitido cargar mas archivos.",
        acceptedFiles: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    });

    myDropzone.on("addedfile", function (file) {

        var ext = file.name.split('.').pop();
        if (ext.indexOf("xlsx") != -1) {
            $(file.previewElement).find("[data-dz-thumbnail]").attr("src", "../../img/Excel-icon.png");
        }

        file.previewElement.querySelector(".start").onclick = function () {
            myDropzone.enqueueFile(file);
        };
    });

    myDropzone.on("totaluploadprogress", function (progress) {
        document.querySelector("#total-progress .progress-bar").style.width = progress + "%";
    });

    myDropzone.on("sending", function (file, xhr, formData) {
        $('#seccionSubirImagenes').LoadingOverlay('show', {
            background: 'rgba(25, 118, 210, 0.1)'
        });

        var idNegocio = $('#cboNegocio').val();
        var idMoneda = $('#cboMoneda').val();
        var idCategoria = $('#cboCategoria').val();

        formData.append('IdNegocio', idNegocio);
        formData.append('IdMoneda', idMoneda);
        formData.append('IdCategoria', idCategoria);

        document.querySelector("#total-progress").style.opacity = "1";
        file.previewElement.querySelector(".start").setAttribute("disabled", "disabled");
    });

    myDropzone.on("complete", function (file) {
        $('#seccionSubirImagenes').LoadingOverlay('hide', true);
    });

    //myDropzone.on("queuecomplete", function (progress) {
    //    document.querySelector("#total-progress").style.opacity = "0";

    //    $('#seccionSubirImagenes').LoadingOverlay('hide', true);
    //    //RecargarData();
    //    MensajeSuccess('Confirmación', 'Se completó la carga de imagenes');
    //});

    myDropzone.on("success", function (file, response) {

        if (response.StatusCode == 200) {
            myDropzone.removeFile(file);
            MensajeSuccess('Confirmación', 'Se completó la carga de imagenes');
        }

    });

    myDropzone.on("error", function (file, response) {
        $('#seccionSubirImagenes').LoadingOverlay('hide', true);
        //$('#lblErrorMessage').html('Error al subir archivo');
        $(file.previewElement).addClass("dz-error").find('[data-dz-errormessage]').text('');
        $('#tbInformacion').html('');
        if (response != null) {
            if (response.ListaError != null) {
                if (response.ListaError.length > 0) {
                    $(file.previewElement).addClass("dz-error").find('[data-dz-errormessage]').text('Error al subir archivo');
                    var mensajes = [];
                    response.ListaError.forEach(function (item, indice, array) {
                        mensajes.push('<tr>');
                        mensajes.push('<td>' + item.Mensaje + '</td>');
                        mensajes.push('</tr>');
                    });
                    var cuerpoHtml = mensajes.join('');
                    $('#tbInformacion').html(cuerpoHtml);
                    myDropzone.removeFile(file);
                    //$(file.previewElement).addClass("dz-error").find('[data-dz-errormessage]').text(cuerpoHtml);

                }
            }
        }

    });

    document.querySelector("#actions .start").onclick = function () {
        myDropzone.enqueueFiles(myDropzone.getFilesWithStatus(Dropzone.ADDED));
    };

}

$(document).on('click', '#btnLimpiar', function () {
    if (!$('#btnLimpiar').hasClass('disabled')) {
        $('#tbInformacion').html('');
    }
});

