var colorPrimary = '#007bff';
var colorSuccess = '#28a745';
var colorWarning = '#ffc107';
var colorSecondary = '#6c757d';
var colorDanger = '#dc3545';
var colorInfo = '#17a2b8';

$(document).ready(function () {

    ValidacionInicial();
    ProcesarMenuLateral();

    var usuario = GetItem('IdUsuario');
    ObtenerResumenGraficoWeb();
    ObtenerGraficoVentas();
    ObtenerGraficoCompras();

    //if (usuario != '') {
        //procesarResumenMesActual();
        //procesarGraficoTotalVentas();
        //procesarGraficoProductosTop();
        //procesarGraficoCategoriasTop();
        //procesarGraficoDeValoracion();
    //}
});

function ObtenerResumenGraficoWeb() {

    $('#frmWrapper').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var currentTime = new Date()
    var prm = {
        'IdUsuario': GetItem('IdUsuario'),
        'Anio': currentTime.getFullYear(),
        'Mes': currentTime.getMonth() + 1
    };

    $.ajax({
        'url': '../../GraficoWeb/ObtenerResumenWeb',
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
            //console.log(result);
            if (result.Cuerpo != null) {
                $('#resumenCantidadProductosOfrecidos').html(result.Cuerpo.CantidadProductosOfrecidos);
                $('#resumenCantidadVentasRealizadas').html(result.Cuerpo.CantidadVentas);
                $('#resumenCantidadComprasRealizadas').html(result.Cuerpo.CantidadCompras);
                //$('#resumenValoracionComoComprador').html(result.Cuerpo.ValoracionObtenidaComoComprador);
                //$('#resumenValoracionComoVendedor').html(result.Cuerpo.ValoracionObtenidaComoVendedor);
            } else {
                $('#resumenCantidadProductosOfrecidos').html('0');
                $('#resumenCantidadVentasRealizadas').html('0');
                $('#resumenCantidadComprasRealizadas').html('0');
                //$('#resumenValoracionComoComprador').html('0');
                //$('#resumenValoracionComoVendedor').html('0');
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('#frmWrapper').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });

};


function ObtenerGraficoVentas() {

    $('#grafico1').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'IdUsuario': GetItem('IdUsuario'),
        'CantidadMeses': 6
    };

    $.ajax({
        'url': '../../GraficoMovil/ObtenerResumenVentas',
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

        $('#grafico1').LoadingOverlay('hide', true);
        EvaluarRespuesta_401_403(result);
        if (!ResponseTieneErrores(result)) {

            if (result.Cuerpo != null) {
                if (result.Cuerpo.length > 0) {
                    var arrayPeriodos = [];
                    var arrayValores = [];
                    var arrayColores = [];
                    result.Cuerpo.forEach(function (item, indice, array) {
                        arrayPeriodos.push(item.NombreMes + '-' + item.Anio);
                        arrayValores.push(item.Total);
                        arrayColores.push(colorSuccess);
                    });

                    generarGraficoTotalVentas(arrayPeriodos, arrayValores, arrayColores);
                }
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('#grafico1').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });
}

function ObtenerGraficoCompras() {

    $('#grafico2').LoadingOverlay('show', {
        background: 'rgba(25, 118, 210, 0.1)'
    });
    var prm = {
        'IdUsuario': GetItem('IdUsuario'),
        'CantidadMeses': 6
    };

    $.ajax({
        'url': '../../GraficoMovil/ObtenerResumenCompras',
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

        $('#grafico2').LoadingOverlay('hide', true);
        EvaluarRespuesta_401_403(result);
        if (!ResponseTieneErrores(result)) {

            if (result.Cuerpo != null) {
                if (result.Cuerpo.length > 0) {
                    var arrayPeriodos = [];
                    var arrayValores = [];
                    var arrayColores = [];
                    result.Cuerpo.forEach(function (item, indice, array) {
                        arrayPeriodos.push(item.NombreMes + '-' + item.Anio);
                        arrayValores.push(item.Total);
                        arrayColores.push(colorInfo);
                    });

                    generarGraficoTotalCompras(arrayPeriodos, arrayValores, arrayColores);
                }
            }
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        $('#grafico2').LoadingOverlay('hide', true);
        ValidacionModelo(jqXHR);
    });
}

//#region Funciones Main
//function procesarResumenMesActual() {
//    $.when(obtenerResumenActual())
//        .done(function (respuestaAjax) {
//            if (respuestaAjax != null) {
//                var cabeceraResumen = generarResumen(respuestaAjax);
//                if (cabeceraResumen != '') {
//                    //asignar el html generado al div
//                    $('#resumenMesActual').empty();
//                    $('#resumenMesActual').append(cabeceraResumen);
//                }
//            }
//        })
//        .fail(function (jqXHR) {
//            console.log(jqXHR);
//            console.log('Error al cargar los resumenes actuales');
//        });
//}

function procesarGraficoTotalVentas() {

    $.when(obtenerTotalVentas())
        .done(function (respuestaAjax) {
            if (respuestaAjax != null) {
                if (respuestaAjax.length > 0) {

                    //Obtener arrays
                    var arrayPeriodos = [];
                    var arrayValores = [];
                    var arrayColores = [];
                    respuestaAjax.forEach(function (item, indice, array) {
                        arrayPeriodos.push(item.Periodo);
                        arrayValores.push(item.Valor);
                        arrayColores.push(item.CodigoColorHexadecimal);
                    });

                    generarGraficoTotalVentas(arrayPeriodos, arrayValores, arrayColores);
                }
            }
        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar grafico de total ventas');
        });
}

function procesarGraficoTotalCompras() {

    $.when(obtenerTotalVentas())
        .done(function (respuestaAjax) {
            if (respuestaAjax != null) {
                if (respuestaAjax.length > 0) {

                    //Obtener arrays
                    var arrayPeriodos = [];
                    var arrayValores = [];
                    var arrayColores = [];
                    respuestaAjax.forEach(function (item, indice, array) {
                        arrayPeriodos.push(item.Periodo);
                        arrayValores.push(item.Valor);
                        arrayColores.push(item.CodigoColorHexadecimal);
                    });

                    generarGraficoTotalVentas(arrayPeriodos, arrayValores, arrayColores);
                }
            }
        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar grafico de total ventas');
        });
}

function procesarGraficoProductosTop() {

    $.when(obtenerProductosTop())
        .done(function (respuestaAjax) {

            var arrayPeriodos = [];
            var arrayProductos = [];

            if (respuestaAjax != null) {
                if (respuestaAjax.ListaPeriodo.length > 0 && respuestaAjax.ListaProducto.length > 0) {

                    //Obteniendo Periodos
                    respuestaAjax.ListaPeriodo.forEach(function (item, indice, array) {
                        arrayPeriodos.push(item.Periodo);
                    });

                    //Obteniendo los productos
                    var producto = null;
                    respuestaAjax.ListaProducto.forEach(function (itemCabecera, indice, array) {

                        var arrayValores = [];
                        var arrayColores = [];
                        itemCabecera.ListaValores.forEach(function (itemDetalle, indice, array) {
                            arrayValores.push(itemDetalle.Valor);
                            arrayColores.push(itemDetalle.CodigoColorHexadecimal);
                        });

                        producto = {
                            label: itemCabecera.DescripcionProducto,
                            data: arrayValores,
                            backgroundColor: arrayColores,
                            borderColor: arrayColores,
                            borderWidth: 1
                        };

                        arrayProductos.push(producto);
                    });
                }
            }

            generarGraficoProductosTop(arrayPeriodos, arrayProductos);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar grafico de total ventas');
        });

}

function procesarGraficoCategoriasTop() {

    $.when(obtenerCategoriasTop())
        .done(function (respuestaAjax) {

            var arrayPeriodos = [];
            var arrayCategorias = [];

            if (respuestaAjax != null) {
                if (respuestaAjax.ListaPeriodo.length > 0 && respuestaAjax.ListaCategoria.length > 0) {

                    //Obteniendo Periodos
                    respuestaAjax.ListaPeriodo.forEach(function (item, indice, array) {
                        arrayPeriodos.push(item.Periodo);
                    });

                    //Obteniendo los categorias
                    var categoria = null;
                    respuestaAjax.ListaCategoria.forEach(function (itemCabecera, indice, array) {

                        var arrayValores = [];
                        var arrayColores = [];
                        itemCabecera.ListaValores.forEach(function (itemDetalle, indice, array) {
                            arrayValores.push(itemDetalle.Valor);
                            arrayColores.push(itemDetalle.CodigoColorHexadecimal);
                        });

                        categoria = {
                            label: itemCabecera.DescripcionCategoria,
                            data: arrayValores,
                            backgroundColor: arrayColores,
                            borderColor: arrayColores,
                            borderWidth: 1
                        };

                        arrayCategorias.push(categoria);
                    });
                }
            }

            generarGraficoCategoriasTop(arrayPeriodos, arrayCategorias);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar grafico de total ventas');
        });

}

function procesarGraficoDeValoracion() {
    var ctx = document.getElementById("grafico4").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ["12/2019", "01/2020", "02/2020", "03/2020", "04/2020", "05/2020"],
            datasets: [
                {
                    label: 'Comprador',
                    data: [2, 1, 3, 5, 4, 2],
                    backgroundColor: [
                        colorSuccess,
                        colorSuccess,
                        colorSuccess,
                        colorSuccess,
                        colorSuccess,
                        colorSuccess
                    ],
                    borderColor: [
                        colorSuccess,
                        colorSuccess,
                        colorSuccess,
                        colorSuccess,
                        colorSuccess,
                        colorSuccess
                    ],
                    borderWidth: 1
                },
                {
                    label: 'Vendedor',
                    data: [2, 1, 3, 5, 2.5, 3.5],
                    backgroundColor: [
                        colorDanger,
                        colorDanger,
                        colorDanger,
                        colorDanger,
                        colorDanger,
                        colorDanger
                    ],
                    borderColor: [
                        colorDanger,
                        colorDanger,
                        colorDanger,
                        colorDanger,
                        colorDanger,
                        colorDanger
                    ],
                    borderWidth: 1
                }
            ]
        },
        options: {
            legend: {
                display: true,
                position: 'right',
                labels: {
                    fontColor: 'rgb(255, 99, 132)'
                }
            },
            title: {
                display: false,
                text: 'Custom Chart Title'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}
//#endregion

//#region Funciones Ajax

//function obtenerResumenActual() {

//    var idUsuario = 2;
//    return $.ajax({
//        url: '../../Home/ObtenerCabecera',
//        type: 'GET',
//        data: {
//            'idUsuario': idUsuario
//        },
//        dataType: 'json',
//        contentType: 'application/json; charset=utf-8',
//        beforeSend: function (request) {
//            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
//        }
//    });

//};

function obtenerTotalVentas() {

    var idUsuario = 2;
    return $.ajax({
        url: '../../Home/ObtenerTotalVentas',
        type: 'GET',
        data: {
            'idUsuario': idUsuario
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        }
    });

};

function obtenerProductosTop() {

    var idUsuario = 2;
    return $.ajax({
        url: '../../Home/ObtenerProductosTop',
        type: 'GET',
        data: {
            'idUsuario': idUsuario,
            'cantidad': 3
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        }
    });

};

function obtenerCategoriasTop() {

    var idUsuario = 2;
    return $.ajax({
        url: '../../Home/ObtenerCategoriasTop',
        type: 'GET',
        data: {
            'idUsuario': idUsuario,
            'cantidad': 3
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (request) {
            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));
        }
    });

};

//#endregion

//#region Generacion de Html

//function generarResumen(listaDatos) {
//    var cuerpoHtml = '';
//    if (listaDatos != null) {
//        if (listaDatos.length > 0) {
//            var html = [];

//            listaDatos.forEach(function (item, indice, array) {
//                html.push(
//                    '<div class="col-sm-6 col-lg-3">',
//                    '    <div class="card ' + item.ColorFondo + '">',
//                    '        <div class="card-body">',
//                    '            <div class="d-flex no-block">',
//                    '                <div class="m-r-20 align-self-center">',
//                    '                    <span style="font-size:35px; color:white;"><i class="' + item.Icono + '" aria-hidden="true"></i></span>',
//                    '                </div>',
//                    '                <div class="align-self-center">',
//                    '                    <h6 class="text-white m-t-10 m-b-0">' + item.Titulo + '</h6>',
//                    '                    <h2 class="m-t-0 text-white">' + item.Valor + '</h2>',
//                    '                </div>',
//                    '            </div>',
//                    '        </div>',
//                    '    </div>',
//                    '</div>'
//                );
//            });
//            cuerpoHtml = html.join('');
//        }
//    }
//    return cuerpoHtml;
//}

function generarGraficoTotalVentas(arrayPeriodos, arrayValores, arrayColores) {
    var ctx = document.getElementById("grafico1").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: arrayPeriodos,
            datasets: [
                {
                    label: 'Monto',
                    data: arrayValores,
                    backgroundColor: arrayColores,
                    borderColor: arrayColores,
                    borderWidth: 1
                }
            ]
        },
        options: {
            legend: {
                display: false,
                position: 'right',
                labels: {
                    fontColor: '#474747'
                }
            },
            title: {
                display: false,
                text: 'Custom Chart Title'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function generarGraficoTotalCompras(arrayPeriodos, arrayValores, arrayColores) {
    var ctx = document.getElementById("grafico2").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: arrayPeriodos,
            datasets: [
                {
                    label: 'Monto',
                    data: arrayValores,
                    backgroundColor: arrayColores,
                    borderColor: arrayColores,
                    borderWidth: 1
                }
            ]
        },
        options: {
            legend: {
                display: false,
                position: 'right',
                labels: {
                    fontColor: '#474747'
                }
            },
            title: {
                display: false,
                text: 'Custom Chart Title'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function generarGraficoProductosTop(arrayPeriodos, arrayProductos) {
    var ctx = document.getElementById("grafico2").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: arrayPeriodos,
            datasets: arrayProductos
        },
        options: {
            legend: {
                display: true,
                position: 'right',
                labels: {
                    fontColor: '#474747'
                }
            },
            title: {
                display: false,
                text: 'Custom Chart Title'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

function generarGraficoCategoriasTop(arrayPeriodos, arrayCategorias) {
    var ctx = document.getElementById("grafico3").getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: arrayPeriodos,
            datasets: arrayCategorias
        },
        options: {
            legend: {
                display: true,
                position: 'right',
                labels: {
                    fontColor: '#474747'
                }
            },
            title: {
                display: false,
                text: 'Custom Chart Title'
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

//#endregion


//function ObtenerResumenGraficoWeb() {
//    var currentTime = new Date()
//    var prm = {
//        'IdUsuario': GetItem('IdUsuario'),
//        'Anio': currentTime.getFullYear(),
//        'Mes': currentTime.getMonth() + 1
//    };

//    return $.ajax({
//        url: '../../GraficoWeb/ObtenerResumenWeb',
//        type: 'POST',
//        data: prm,
//        dataType: 'json',
//        headers: {
//            //'Authorization': 'Valor del token debe ir aca'
//        },
//        contentType: 'application/json; charset=utf-8',
//        beforeSend: function (request) {
//            request.setRequestHeader(ObtenerNombreAutorizacion(), GetItem(ObtenerNombreToken()));

//        },
//        complete: function (json) {
//            EvaluarRespuesta_401_403(json);
//        }
//    });
//}
