$(document).ready(function () {
    //$('.selectpicker').selectpicker();
    $(".select2").select2();
    DropZone();

    $.when(obtenerMoneda(), obtenerCategoria(), obtenerEstado(), obtenerNegocio())
        .done(function (respuestaMonedaAjax, respuestaCategoriaAjax, respuestaEstadoAjax, respuestaNegocioAjax) {

            if (respuestaMonedaAjax != null) {

                if (respuestaMonedaAjax.length > 0) {

                    var cboMoneda = $('#cboMoneda');
                    cboMoneda.empty();
                    respuestaMonedaAjax[0].forEach(function (item, indice, array) {
                        cboMoneda.append($('<option/>', {
                            value: item.IdMoneda,
                            text: item.Descripcion
                        }));
                    });
                }
            }

            if (respuestaCategoriaAjax != null) {

                if (respuestaCategoriaAjax.length > 0) {

                    var cboCategoria = $('#cboCategoria');
                    cboCategoria.empty();
                    respuestaCategoriaAjax[0].forEach(function (item, indice, array) {
                        cboCategoria.append($('<option/>', {
                            value: item.IdCategoria,
                            text: item.Descripcion
                        }));
                    });
                }
            }

            if (respuestaEstadoAjax != null) {

                if (respuestaEstadoAjax.length > 0) {

                    var cboEstado = $('#cboEstado');
                    cboEstado.empty();
                    respuestaEstadoAjax[0].forEach(function (item, indice, array) {
                        cboEstado.append($('<option/>', {
                            value: item.IdEstado,
                            text: item.Descripcion
                        }));
                    });
                }
            }

            if (respuestaNegocioAjax != null) {

                if (respuestaNegocioAjax.length > 0) {

                    var cboNegocio = $('#cboNegocio');
                    cboNegocio.empty();
                    respuestaNegocioAjax[0].forEach(function (item, indice, array) {
                        cboNegocio.append($('<option/>', {
                            value: item.IdNegocio,
                            text: item.NumeroDocumentoIdentidad + ' - ' + item.RazonSocial
                        }));
                    });
                }
            }
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
function obtenerMoneda() {

    var select = $('#cboMoneda');
    return $.ajax({
        url: '../../Moneda/ObtenerCombo',
        type: 'GET',
        data: {
            'primerValor': ''
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
        }
    });

};

function obtenerCategoria() {

    var select = $('#cboCategoria');
    return $.ajax({
        url: '../../Categoria/ObtenerCombo',
        type: 'GET',
        data: {
            'primerValor': ''
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
        }
    });

};

function obtenerEstado() {

    var select = $('#cboEstado');
    return $.ajax({
        url: '../../Estado/ObtenerCombo',
        type: 'GET',
        data: {
            'primerValor': ''
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
        }
    });

};

function obtenerNegocio() {

    var select = $('#cboNegocio');
    return $.ajax({
        url: '../../Negocio/ObtenerCombo',
        type: 'GET',
        data: {
            'primerValor': ''
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            select.empty();
        }
    });

};
//#endregion


