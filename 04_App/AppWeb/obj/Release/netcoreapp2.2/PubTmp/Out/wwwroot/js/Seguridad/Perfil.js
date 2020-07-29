window._idUsuario = 0;
window._mensajeValidacion = '';

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();

    $('.dropify').dropify();
    $('#fileInput').dropify();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    window._idUsuario = GetItem('IdUsuario');

    $.when(ObtenerPorId())
        .done(function (respuestaAjax) {
            if (respuestaAjax != null) {
                if (respuestaAjax.Cuerpo != null) {
                    $("#txtNombre").val(respuestaAjax.Cuerpo.Nombre);
                    $("#txtApellido").val(respuestaAjax.Cuerpo.Apellido);
                    $("#txtCorreoElectronico").val(respuestaAjax.Cuerpo.CorreoElectronico);
                    window._idUsuario = respuestaAjax.IdUsuario;

                    if (respuestaAjax.Cuerpo.UrlImagen != '') {
                        $("#imgUsuario").attr("src", respuestaAjax.Cuerpo.UrlImagen);
                        //$('#inputImagen').attr("data-default-file", respuestaAjax.UrlImagen);
                        //$('#inputImagen').dropify();
                    }

                    $('#frmWrapper').LoadingOverlay('hide', true);
                }
            }
        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
        });

});

//document.getElementById('uploader').onsubmit = function () {
//    var formdata = new FormData(); //FormData object
//    var fileInput = document.getElementById('fileInput');
//    //Iterating through each files selected in fileInput
//    for (i = 0; i < fileInput.files.length; i++) {
//        //Appending each file to FormData object
//        formdata.append(fileInput.files[i].name, fileInput.files[i]);
//    }
//    //Creating an XMLHttpRequest and sending
//    var xhr = new XMLHttpRequest();
//    xhr.open('POST', '../../Usuario/Upload');
//    xhr.send(formdata);
//    xhr.onreadystatechange = function () {
//        if (xhr.readyState == 4 && xhr.status == 200) {
//            alert(xhr.responseText);
//        }
//    }
//    return false;
//}

//$("#uploader").submit(function (event) {

//    alert("Handler for .submit() called.");


//    var formdata = new FormData(); //FormData object
//    var fileInput = document.getElementById('fileInput');
//    //Iterating through each files selected in fileInput
//    for (i = 0; i < fileInput.files.length; i++) {
//        //Appending each file to FormData object
//        formdata.append(fileInput.files[i].name, fileInput.files[i]);
//    }
//    //Creating an XMLHttpRequest and sending
//    var xhr = new XMLHttpRequest();
//    xhr.open('POST', '../../Usuario/Upload');
//    xhr.send(formdata);
//    xhr.onreadystatechange = function () {
//        if (xhr.readyState == 4 && xhr.status == 200) {
//            alert(xhr.responseText);
//        }
//    }
//    return false;

//});


$(document).on('click', '#btnSubir', function () {

    $('#sticky').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    window._idUsuario = GetItem('IdUsuario');
    var formdata = new FormData(); //FormData object
    var fileInput = document.getElementById('fileInput');
    formdata.append('IdUsuario', window._idUsuario.toString());

    for (i = 0; i < fileInput.files.length; i++) {
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '../../Usuario/ActualizarImagen', true);
    xhr.send(formdata);
    xhr.onreadystatechange = function () {

        if (xhr != null && xhr.readyState == 4) {
            var objetoDeserializado = JSON.parse(xhr.response);
            //console.log(objetoDeserializado);
            switch (objetoDeserializado.ProcesadoOk) {
                case -1:
                    MensajeError('Error', 'No se encontró el usuario');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo modificar la imágen');
                    break;
                case 1:
                    //$("#sticky").modal('hide');//ocultamos el modal
                    //$('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
                    //$('.modal-backdrop').remove();//eliminamos el backdrop del modal
                    
                    $('div.jquery-modal').removeClass('jquery-modal');
                    MensajeSuccess('Confirmación', 'La imágen fue modificada satisfactoriamente!');
                    if (objetoDeserializado.UrlImagen != '' && objetoDeserializado.UrlImagen != null) {
                        SetItem('UrlImagen', objetoDeserializado.UrlImagen);
                        $("#imgUsuario").attr("src", null);
                        $("#imgUsuario").attr("src", objetoDeserializado.UrlImagen);

                        try {
                            $("#imgPerfilSideBar").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
                            $("#imgPerfilSideBar").attr("src", objetoDeserializado.UrlImagen);
                        } catch (error) {
                            $("#imgPerfilSideBar").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
                        }

                        try {
                            $("#imgPerfilHeader").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
                            $("#imgPerfilHeader").attr("src", objetoDeserializado.UrlImagen);
                        } catch (error) {
                            $("#imgPerfilHeader").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
                        }

                        try {
                            $("#imgPerfilHeaderClick").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
                            $("#imgPerfilHeaderClick").attr("src", objetoDeserializado.UrlImagen);
                        } catch (error) {
                            $("#imgPerfilHeaderClick").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
                        }

                        //$('#inputImagen').attr("data-default-file", respuestaAjax.UrlImagen);
                        //$('#inputImagen').dropify();
                    }
                    break;
            }
            $('#sticky').LoadingOverlay('hide', true);
        }
    }
    return false;
});

function ObtenerPorId() {
    //var id = ObtenerParametroUrl();
    return $.ajax({
        url: '../../Usuario/ObtenerPorId',
        type: 'GET',
        data: {
            'id': window._idUsuario
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

function ObtenerParametroUrl() {
    var sPageURL = window.location.href;
    var indexOfLastSlash = sPageURL.lastIndexOf("/");

    if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
        return sPageURL.substring(indexOfLastSlash + 1);
    else
        return 0;
}

$(document).on('click', '#btnGuardar', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnGuardar').hasClass('disabled')) {
        if (Validar()) {
            //console.log(window._idUsuario);
            $('#frmWrapper').LoadingOverlay('show', {
                background: 'rgba(25, 118, 210, 0.1)'
            });

            Actualizar();
        } else {
            //Mostrar mensaje de error
            console.log(window._mensajeValidacion);
        }
    }
});

function Actualizar() {

    var prm = {
        'IdUsuario': GetItem('IdUsuario'),
        'Nombre': $("#txtNombre").val(),
        'Apellido': $("#txtApellido").val(),
        'CorreoElectronico': $("#txtCorreoElectronico").val()
    };

    $.ajax({
        'url': '../../Usuario/Modificar',
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
        $('#frmWrapper').LoadingOverlay('hide', true);
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

                        SetItem('Nombre', $("#txtNombre").val());
                        SetItem('Apellido', $("#txtApellido").val());
                        SetItem('CorreoElectronico', $("#txtCorreoElectronico").val());
                        var nombreUsuario = GetItem('Nombre');
                        var apellidoUsuario = GetItem('Apellido');
                        var correoUsuario = GetItem('CorreoElectronico');
                        $("#lblCorreoUsuarioHeader").html(correoUsuario);
                        var nombreCompleto = nombreUsuario + ' ' + apellidoUsuario
                        $("#lblNombreUsuarioHeader").html(nombreCompleto);

                        break;
                }
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('#frmWrapper').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    }).always(function (result) {
        
    });

};

function Validar() {
    window._mensajeValidacion = '';
    if ($("#txtNombre").val() == '') {
        window._mensajeValidacion = window._mensajeValidacion + ' * El nombre es requerido <br/>';
    }

    if ($("#txtApellido").val() == '') {
        window._mensajeValidacion = window._mensajeValidacion + ' * El apellido es requerido <br/>';    }

    if ($("#txtCorreoElectronico").val() == '') {
        window._mensajeValidacion = window._mensajeValidacion + ' * El correo electrónico es requerido <br/>';
    }

    if (window._mensajeValidacion == '') {
        return true;
    }
    else {
        return false;
    }
}

$(document).on('click', '#btnCambiarImagen', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnCambiarImagen').hasClass('disabled')) {
        //var cuerpoModal = GenerarCuerpoModalDeVisualizar();
        //$('#sticky').empty();
        //$('#sticky').append(cuerpoModal);

        $('#sticky').modal({
            escapeClose: true,
            //clickClose: false,
            showClose: true
        });
        //$('#fileInput').dropify();
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

        $('body').LoadingOverlay('show', {
            background: 'rgba(25, 118, 210, 0.1)'
        });

        window._idUsuario = GetItem('IdUsuario');
        var prm = {
            'id': window._idUsuario
        };

        $.ajax({
            'url': '../../Usuario/EliminarImagen',
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
            switch (result.ProcesadoOk) {
                case -1:
                    MensajeError('Error', 'No se encontró el usuario');
                    break;
                case 0:
                    MensajeError('Error', 'No se pudo modificar la imágen');
                    break;
                case 1:
                    //$("#sticky").modal('hide');//ocultamos el modal
                    //$('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
                    //$('.modal-backdrop').remove();//eliminamos el backdrop del modal

                    $('div.jquery-modal').removeClass('jquery-modal');
                    MensajeSuccess('Confirmación', 'La imágen fue modificada satisfactoriamente!');
                    if (result.UrlImagen != '' && result.UrlImagen != null) {
                        $("#imgUsuario").attr("src", null);
                        $("#imgUsuario").attr("src", result.UrlImagen);
                        $("#imgPerfilHeader").attr("src", null);
                        $("#imgPerfilHeader").attr("src", result.UrlImagen);
                        $("#imgPerfilHeaderClick").attr("src", null);
                        $("#imgPerfilHeaderClick").attr("src", result.UrlImagen);
                        //$('#inputImagen').attr("data-default-file", respuestaAjax.UrlImagen);
                        //$('#inputImagen').dropify();
                    }
                    break;
            }

        }).fail(function (jqXHR, textStatus, errorThrown) {
            $('body').LoadingOverlay('hide', true);
        });
    }
});

function HabilitarControlesMenu(valor) {
    if (valor === true) {
        $('#btnGuardar').removeClass('disabled');
        $('#btnInicio').removeClass('disabled');
    } else {
        $('#btnGuardar').addClass('disabled');
        $('#btnInicio').addClass('disabled');
    }
};