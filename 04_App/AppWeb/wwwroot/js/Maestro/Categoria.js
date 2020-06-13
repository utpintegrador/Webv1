$(document).ready(function () {
    //$('.selectpicker').selectpicker();
    $(".select2").select2();
    ProcesarCargaDeProductos();
});

//#region Funciones Main


function ProcesarCargaDeProductos() {

    $.when(obtenerCategorias())
        .done(function (respuestaAjax) {
            if (respuestaAjax != null) {

                if (respuestaAjax.length > 0) {
                    var cuerpoListado = GenerarHtmlListado(respuestaAjax);
                    $('#cuerpoListado').empty();
                    $('#cuerpoListado').append(cuerpoListado);

                    $('.slimControl').perfectScrollbar();
                }
            }
        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
            console.log('Error al cargar los resumenes actuales');
        });

}

function Editar(id) {
    var url = '/Categoria/Edit/' + id;
    window.location.href = url;
}

function Eliminar(id) {

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-danger'//,
            //cancelButton: 'btn btn-transparent'
        },
        buttonsStyling: true
    });

    swalWithBootstrapButtons.fire({
        title: "Confirmación",
        text: "¿ Está seguro de eliminar el registro?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: 'Ok!',
        cancelButtonText: 'No!',
        confirmButtonColor: '#d33',
        reverseButtons: true
    })
        .then(function (respuesta) {
            switch (respuesta.value) {
                case true:
                    console.log('se eliminara');
                    //EliminarRegistro(entidad.IdCliente);
                    break;
                default:
                    console.log('no se eliminara');
                    break;
            }

        });
}
//#endregion

//#region Funciones Ajac
function obtenerCategorias() {

    return $.ajax({
        url: '../../Categoria/Obtener',
        type: 'GET',
        data: {
            'IdEstado': 1,
            'Descripcion': 'HOLA',
            'Pagina': 1,
            'Tamanio': 10,
            'ColumnaOrden': 'Descripcion',
            'ColumnaDireccion': 'desc'
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8'
    });

};
//#endregion

//#region Generacion Html

function GenerarHtmlListado(listado) {

    var html = [];
    listado.forEach(function (item, indice, array) {
        html.push(
            '<div class="row">',
            '    <div class="col-md-12">',
            '        <div class="card">',
            '            <div class="card-body">',
            '                <div class="row">',
            '                    <div class="col-lg-8 col-md-8 slimControl" style="height: 250px;">',
            '                        <div class="col-md-12">',
            '                            <div class="card-header row bg-white" style="margin-top:-8px;">',
            '                                <div class="col-md-12">',
            '                                    <button type="submit" class="btn btn-sm btn-warning waves-effect waves-light m-t-10" onclick="Editar(' + item.IdCategoria + ');">',
            '                                        <i class="fa fa-pencil" aria-hidden="true"></i> Editar',
            '                                    </button>',
            '                                    <button type="submit" class="btn btn-sm btn-danger waves-effect waves-light m-t-10" onclick="Eliminar(' + item.IdCategoria + ');">',
            '                                        <i class="fa fa-trash-o" aria-hidden="true"></i> Eliminar',
            '                                    </button>',
            '                                    <button type="submit" class="btn btn-sm btn-secondary waves-effect waves-light m-t-10" onclick="VerImagen(' + item.IdCategoria + ');">',
            '                                        <i class="fa fa-eye" aria-hidden="true"></i> Ver Imagenes',
            '                                    </button>',
            '                                </div>',
            '                            </div>',
            '                            <div class="card card-body">',
            '                                <div class="form-horizontal">',
            '                                    <div class="form-group row" style="margin-bottom:0px;">',
            '                                        <label class="col-sm-3 control-label col-form-label">Descripcion</label>',
            '                                        <div class="col-sm-9">',
            '                                            <input type="text" class="form-control form-control-sm bg-white" value="' + item.Descripcion + '" readonly>',
            '                                        </div>',
            '                                    </div>',

            '                                    <div class="form-group row" style="margin-bottom:0px;">',
            '                                        <label class="col-sm-3 control-label col-form-label">Estado</label>',
            '                                        <div class="col-sm-9">',
            '                                            <input type="text" class="form-control form-control-sm bg-white" value="' + item.Estado + '" readonly>',
            '                                        </div>',
            '                                    </div>',
            '                                </div>',
            '                            </div>',
            '                        </div>',
            '                    </div>',
            '                    <div class="col-lg-4 col-md-4">',
            '                            <div class="align-middle" style="margin-bottom:0px;">',
            '                                <img src="' + item.UrlImagen + '" style="max-height:230px; width:100%; margin-top:20px" class="img-fluid" />',
            '                            </div>',
            '                    </div>',
            '                </div>',
            '            </div>',
            '        </div>',
            '    </div>',
            '</div>'
        );
    });

    var cuerpoHtml = html.join('');
    return cuerpoHtml;
}

//#endregion


function VerImagen(id) {
    //var objetoDeserializado = JSON.parse(valorSeleccionado);
    //if (objetoDeserializado != null) {
    //    if (objetoDeserializado.IdProducto != null) {
    //var a = "Test";
    $.ajax({
        url: "../../PasarelaProducto/Details/" + id,
        type: "GET",
        data: {},
        success: function (response) {
            if (response != null) {
                var cuerpoModal = GenerarCuerpoModalDeCategoria(response);
                $('#sticky').empty();
                $('#sticky').append(cuerpoModal);

                $('#sticky').modal({
                    escapeClose: true,
                    clickClose: false,
                    showClose: false
                });
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
    //    }
    //}
}

function GenerarCuerpoModalDeCategoria(objetoSeleccionado) {

    var html = [];

    var htmlImagenSlides = [];
    var htmlImagenSrc = [];

    //Imagenes del carrousel
    if (objetoSeleccionado.ListaImagen != null) {
        if (objetoSeleccionado.ListaImagen.length > 0) {
            objetoSeleccionado.ListaImagen.forEach(function (productoImagen, indice, array) {

                var imagenActiva = '';
                /*INICIO IMAGEN SLIDE CONTROL*/
                if (productoImagen.Predeterminado) {
                    imagenActiva = ' class="active"';
                } else {
                    imagenActiva = '';
                }

                htmlImagenSlides.push('<li data-target="#carouselExampleIndicators" data-slide-to="' + productoImagen.Indice + '"' + imagenActiva + '></li>');
                /*FIN IMAGEN SLIDE*/

                /*INICIO IMAGEN SRC*/

                if (productoImagen.Predeterminado) {
                    imagenActiva = ' active';
                } else {
                    imagenActiva = '';
                }

                htmlImagenSrc.push(
                    '<div class="carousel-item' + imagenActiva + '">',
                    '    <img class="d-block w-100 tamanioimagenproductopopup"',
                    '            src="' + productoImagen.UrlImagen + '" alt="' + productoImagen.Descripcion + '" style="margin-left: auto;margin-right: auto;">'
                );

                htmlImagenSrc.push(
                    '</div>'
                );
                /*FIN IMAGEN SRC*/

            });
        }
    }

    //Resultado
    html.push(
        '<div class="modal-content border-0">',
        '    <div class="card-header bg-white">',
        objetoSeleccionado.Descripcion,
        '    </div>',
        '    <div class="card-body">',
        '        <div id="carouselExampleIndicators" class="carousel slide" style="background-color: #606060;" data-ride="carousel">',
        '            <ol class="carousel-indicators">'
    );

    html = html.concat(htmlImagenSlides);

    html.push(
        '            </ol>',
        '            <div class="carousel-inner imagenproducto">'
    );

    html = html.concat(htmlImagenSrc);

    html.push(
        '            </div>',
        '            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">',
        '                <span class="carousel-control-prev-icon" aria-hidden="true"></span>',
        '                <span class="sr-only">Anterior</span>',
        '            </a>',
        '            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">',
        '                <span class="carousel-control-next-icon" aria-hidden="true"></span>',
        '                <span class="sr-only">Siguiente</span>',
        '            </a>',
        '        </div>',
        '    </div>',
        '    <div class="card-footer bg-white">',
        '        <a href="#" rel="modal:close" class="btn btn-danger float-right"><i class="fa fa-times" aria-hidden="true"></i> Cerrar</a>',
        '    </div>',
        '</div>'
    );

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}