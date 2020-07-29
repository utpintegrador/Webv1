window._idPedido = 0;

$(document).ready(function () {
    ValidacionInicial();
    ProcesarMenuLateral();

    window._idPedido = ObtenerParametroUrl();

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });

    $.when(ObtenerNotaPedido(window._idPedido))
        .done(function (respuestaAjax) {

            if (respuestaAjax.Cuerpo != null) {
                $('#txtNombreVendedor').html('<i class="fa fa-user-o" aria-hidden="true"></i> ' + respuestaAjax.Cuerpo.NombreVendedor);
                //$('#txtDireccionVendedor').html('<i class="fa fa-map-marker" aria-hidden="true"></i>');
                $('#txtTelefonoVendedor').html('<i class="fa fa-mobile" aria-hidden="true"></i> ' + respuestaAjax.Cuerpo.TelefonoVendedor);
                $('#txtDocumentoVendedor').html('<i class="fa fa-id-card-o" aria-hidden="true"></i> ' + respuestaAjax.Cuerpo.DescripcionTipoDocumentoIdentificacionVendedor + ' - ' + respuestaAjax.Cuerpo.DocumentoIdentificacionVendedor);

                $('#txtNombreCliente').html('<i class="fa fa-user-o" aria-hidden="true"></i> ' + respuestaAjax.Cuerpo.NombreComprador);
                $('#txtDireccionCliente').html(respuestaAjax.Cuerpo.Direccion);
                $('#txtTelefonoCliente').html('<i class="fa fa-mobile" aria-hidden="true"></i> ' + respuestaAjax.Cuerpo.TelefonoComprador);
                $('#txtDocumentoCliente').html('<i class="fa fa-id-card-o" aria-hidden="true"></i> ' + respuestaAjax.Cuerpo.DescripcionTipoDocumentoIdentificacionComprador + ' - ' + respuestaAjax.Cuerpo.DocumentoIdentificacionComprador);

                $('#txtEstado').html(respuestaAjax.Cuerpo.DescripcionEstado);
                $('#txtTotal').html(respuestaAjax.Cuerpo.Total.toFixed(2));
                $('#txtMoneda').html(respuestaAjax.Cuerpo.DescripcionMoneda);
                $('#txtFechaRegistro').html(respuestaAjax.Cuerpo.FechaRegistro);

                var cuerpoTabla = GenerarTabla(respuestaAjax.Cuerpo.ListaDetalle);
                if (cuerpoTabla != '') {
                    $('#ListadoDetalles').html('');
                    $('#ListadoDetalles').html(cuerpoTabla);
                }
            }

            $('#frmWrapper').LoadingOverlay('hide', true);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error');
            $('#frmWrapper').LoadingOverlay('hide', true);
        });

});

function GenerarTabla(lista) {
    
    if (lista != null) {
        if (lista.length > 0) {
            var html = [];
            var indiceFor = 1;
            lista.forEach(function (item, indice, array) {

                html.push('<tr>');
                html.push('    <td class="text-center">' + indiceFor + '</td>');
                html.push('    <td>' + item.DescripcionProducto + '</td>');
                html.push('    <td class="text-center">' + item.Cantidad.toFixed(2) + ' </td>');
                html.push('    <td class="text-center"> ' + item.PrecioUnitario.toFixed(2) + ' </td>');
                html.push('    <td class="text-right"> ' + item.SubTotalPorItem.toFixed(2) + ' </td>');
                html.push('</tr>');

                indiceFor = indiceFor + 1;
            });

            var cuerpoHtml = html.join('');
            return cuerpoHtml;
        }
    }
    return '';
}

function ObtenerNotaPedido(id) {

    return $.ajax({
        url: '../../Pedido/ObtenerNotaPedidoPorId',
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
}

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