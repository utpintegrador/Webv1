$(document).ready(function () {
    var imagenLocalStorage = GetItem('UrlImagen');
    var nombreUsuario = GetItem('Nombre');
    var apellidoUsuario = GetItem('Apellido');
    var correoUsuario = GetItem('CorreoElectronico');
    

    try {
        if (imagenLocalStorage == '') {
            $("#imgPerfilSideBar").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
        } else {
            $("#imgPerfilSideBar").attr("src", imagenLocalStorage);
        }
    } catch (error) {
        $("#imgPerfilSideBar").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
    }

    try {
        if (imagenLocalStorage == '') {
            $("#imgPerfilHeader").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
            
        } else {
            $("#imgPerfilHeader").attr("src", imagenLocalStorage);
        }
    } catch (error) {
        $("#imgPerfilHeader").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
    }

    try {
        if (imagenLocalStorage == '') {
            $("#imgPerfilHeaderClick").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');

        } else {
            $("#imgPerfilHeaderClick").attr("src", imagenLocalStorage);
        }
    } catch (error) {
        $("#imgPerfilHeaderClick").attr("src", 'https://encuentralo.s3.us-east-2.amazonaws.com/Aplicativo/sin_foto_perfil.jpg');
    }

    $("#lblCorreoUsuarioHeader").html(correoUsuario);

    var nombreCompleto = nombreUsuario + ' ' + apellidoUsuario
    $("#lblNombreUsuarioHeader").html(nombreCompleto);
    

});

function SetItem(llave, valor) {
    if (localStorage.getItem(llave) === null) {
        localStorage.setItem(llave, valor);
    } else {
        RemoveItem(llave);
        if (localStorage.getItem(llave) === null) {
            localStorage.setItem(llave, valor);
        }
    }
}

function GetItem(llave) {
    if (localStorage.getItem(llave) != null) {
        return localStorage.getItem(llave);
    }
    return '';
}

function RemoveItem(llave) {
    if (localStorage.getItem(llave) != null) {
        localStorage.removeItem(llave);
    }
}

$(document).on('click', '#btnCerrarSesionHeader', function () {
    if (!$('#btnCerrarSesion').hasClass('disabled')) {
        CerrarSesion();
        window.location.href = '/Home/Login';
    }
});

$(document).on('click', '#btnCerrarSesion', function () {
    if (!$('#btnCerrarSesion').hasClass('disabled')) {
        CerrarSesion();
        window.location.href = '/Home/Login';
    }
});

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
        html: mensaje,
        title: titulo,
        //text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    });
}

function MensajeSuccess(titulo, mensaje) {

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
        html: mensaje,
        title: titulo,
        //text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    });
}

function MensajeInfo(titulo, mensaje) {

    if (titulo == null) {
        titulo = 'Información';
    }

    if (titulo == '') {
        titulo = 'Información';
    }

    if (mensaje == null) {
        mensaje = 'Información';
    }

    if (mensaje == '') {
        mensaje = 'Información';
    }

    var icon = 'info';
    var className = 'btn btn-info';

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: className
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        html: mensaje,
        title: titulo,
        //text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    });
}

function MensajeSuccessConEspera(titulo, mensaje, urlDestino) {

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

    if (urlDestino == null) {
        urlDestino = '';
    }

    if (urlDestino == '') {
        urlDestino = '/Home/Index';
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
        html: mensaje,
        title: titulo,
        //text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    }).then(function (respuesta) {
        switch (respuesta.value) {
            case true:
                window.location.href = urlDestino;
                break;
            default:
                window.location.href = urlDestino;
                break;
        }

    });
}

function MensajeErrorConEspera(titulo, mensaje, urlDestino) {

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

    if (urlDestino == null) {
        urlDestino = '';
    }

    if (urlDestino == '') {
        urlDestino = '/Home/Index';
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
        html: mensaje,
        title: titulo,
        //text: mensaje,
        icon: icon,
        confirmButtonText: 'Ok!',
        reverseButtons: true
    }).then(function (respuesta) {
        switch (respuesta.value) {
            case true:
                window.location.href = urlDestino;
                break;
            default:
                window.location.href = urlDestino;
                break;
        }

    });
}

function ResponseTieneErrores(result) {
    var mensajeError = '';
    if (result != null) {
        if (result.ListaError != null) {
            if (result.ListaError.length > 0) {
                result.ListaError.forEach(function (item, indice, array) {
                    mensajeError = mensajeError + item.Mensaje + '<br/>'
                });
            }
        }
    }
    if (mensajeError != '') {
        MensajeError('Error', mensajeError);
        return true;
    } else {
        return false;
    }
}

function ValidacionModelo(result) {
    if (result != null) {
        if (result.responseJSON != null) {
            if (result.responseJSON.ListaError != null) {
                if (result.responseJSON.ListaError.length > 0) {
                    var mensajeError = '';
                    result.responseJSON.ListaError.forEach(function (item, indice, array) {
                        mensajeError = mensajeError + item.Mensaje + '<br/>'
                    });
                    if (mensajeError != '') {
                        MensajeError('Error', mensajeError);
                    }
                }
            }
        }
    }
}

function sleep(miliseconds) {
    var currentTime = new Date().getTime();
    while (currentTime + miliseconds >= new Date().getTime()) {
    }
}

function ObtenerNombreAutorizacion() {
    return 'Authorization';
}

function ObtenerNombreToken() {
    return 'Token';
}

function CerrarSesion() {
    RemoveItem('Nombre');
    RemoveItem('Apellido');
    RemoveItem('CorreoElectronico');
    RemoveItem('IdUsuario');
    RemoveItem('UrlImagen');
    RemoveItem('Token');
    RemoveItem('Menu');
}

function EvaluarRespuesta_401_403(result) {
    if (result != null) {
        if (result.responseJSON != null) {
            if (result.responseJSON.StatusCode != null) {
                if (result.responseJSON.StatusCode != '') {
                    var statusCode = result.responseJSON.StatusCode;
                    if (statusCode === 401) {
                        //Unauthorized
                        
                        //<i class="fa fa-lock" aria-hidden="true"></i>
                        CerrarSesion();
                        MensajeErrorConEspera('Error', '<i class="fa fa-lock" aria-hidden="true"></i> La sesión ha expirado', '/Home/Login');
                    } else if (statusCode == 403) {
                        //Forbidden
                        //<i class="fa fa-key" aria-hidden="true"></i>
                        MensajeErrorConEspera('Error', '<i class="fa fa-key" aria-hidden="true"></i> Acceso no admitido', '/Home/Index');
                    }
                }
            }
        }
    }
}

function ProcesarMenuLateral() {
    var stringStorage = GetItem('Menu');
    listadoMenu = JSON.parse(stringStorage);
    if (listadoMenu.length > 0) {
        var html = [];
        listadoMenu.forEach(function (item, indice, array) {

            if (item.ListaItem.length > 0) {
                html.push('<li>');
                html.push('    <a class="has-arrow waves-effect waves-dark" href="#" aria-expanded="false">');
                html.push('        <i class="' + item.Icono + '"></i>');
                html.push('        <span class="hide-menu">');
                html.push('            ' + item.Titulo);
                if (item.EstiloDeGrupo != '') {
                    html.push('            <span class="label label-rouded ' + item.EstiloDeGrupo + ' pull-right">' + item.ListaItem.length + '</span>');
                } else {
                    html.push('            <span class="label label-rouded label-themecolor pull-right">' + item.ListaItem.length + '</span>');
                }


                html.push('        </span>');
                html.push('    </a>');

                if (item.ListaItem != null) {
                    if (item.ListaItem.length > 0) {
                        html.push(ProcesarMenuLateralItems(item.ListaItem));
                    }
                }

                html.push('</li >');
            }

        });

        var stringContent = html.join('');
        $('#menuDinamico').html('');
        $('#menuDinamico').html(stringContent);

    }
}

function ProcesarMenuLateralItems(lista) {
    var html = [];
    html.push('    <ul aria-expanded="false" class="collapse">');

    lista.forEach(function (item, indice, array) {
        
        html.push('        <li>');
        html.push('            <a href="' + item.UrlAcceso + '"><i class="' + item.Icono + '" aria-hidden="true"></i> ' + item.Titulo + '</a>');
        html.push('        </li>');
        
    });

    html.push('    </ul >');

    var respuesta = html.join('');
    return respuesta;
}

$(document).on('click', '#btnVerPedidos', function () {
    if (!$('#btnVerPedidos').hasClass('disabled')) {
        window.location.href = '/Venta/Index';
    }
});

$(document).on('click', '#listaPedidosPorAtender', function () {
    if (!$('#listaPedidosPorAtender').hasClass('disabled')) {
        $.when(ObtenerPendientesAtencionPorIdUsuario(GetItem('IdUsuario')))
            .done(function (respuestaAjaxPorId) {

                if (respuestaAjaxPorId != null) {
                    if (respuestaAjaxPorId.Cuerpo != null) {

                        var cuerpo = GenerarHtmlNotificaciones(respuestaAjaxPorId.Cuerpo);
                        if (cuerpo != null) {
                            $('#notificacionesDePedido').html('');
                            $('#notificacionesDePedido').html(cuerpo);
                        }

                    } else {
                        //$('body').LoadingOverlay('hide', true);
                    }
                } else {
                    //$('body').LoadingOverlay('hide', true);
                }

            })
            .fail(function (jqXHR) {
                console.log(jqXHR);
                console.log('Error');
                //$('body').LoadingOverlay('hide', true);
            });
    }
});

function ObtenerPendientesAtencionPorIdUsuario(idUsuario) {
    return $.ajax({
        url: '../../Pedido/ObtenerPendientesAtencionPorIdUsuario',
        type: 'GET',
        data: {
            'id': idUsuario
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

function GenerarHtmlNotificaciones(listadoNotificaciones) {

    var html = [];

    //<i class="fa fa-link"></i>
    //<i class="ti-calendar"></i>
    //<i class="ti-settings"></i>
    //<i class="ti-user"></i>
    if (listadoNotificaciones.length == 0) {
        html.push('<li>');
        html.push('    <div class="drop-title">Sin Notificaciones</div>');
        html.push('</li>');
    } else {
        html.push('<li>');
        html.push('    <div class="drop-title">Notificaciones</div>');
        html.push('</li>');
        html.push('<li>');
        html.push('    <div class="message-center">');

        listadoNotificaciones.forEach(function (item, indice, array) {
            if (item != null) {
                html.push(GenerarHtmlNotificacionesIndividual(item));
            }
        });

        html.push('    </div>');
        html.push('</li>');
        html.push('<li>');
        html.push('    <a id="btnVerPedidos" class="nav-link text-center" href="javascript:void(0);"> <strong>Ver todo</strong> <i class="fa fa-angle-right"></i> </a>');
        html.push('</li>');
    }

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}

function GenerarHtmlNotificacionesIndividual(item) {
    var html = [];

    html.push('        <a href="#">');
    html.push('            <div class="btn btn-success btn-circle"><i class="ti-calendar"></i></div>');
    html.push('            <div class="mail-contnet">');
    html.push('                <h5>Cliente: ' + item.Nombre + '</h5> <span class="mail-desc">Monto: ' + item.Total + '</span> <span class="time">Fecha: ' + item.FechaRegistro + '</span>');
    html.push('            </div>');
    html.push('        </a>');

    var cuerpoHtml = html.join('');
    return cuerpoHtml;
}

