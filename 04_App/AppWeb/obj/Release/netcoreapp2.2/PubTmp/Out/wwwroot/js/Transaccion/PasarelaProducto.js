
$(document).ready(function () {

});

$(document).on('click', '#btnAgregarAlCarro', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnAgregarAlCarro').hasClass('disabled')) {
        //console.log('click');
    }
});

function MostrarDetalle(valorSeleccionado) {
    var objetoDeserializado = JSON.parse(valorSeleccionado);
    if (objetoDeserializado != null) {
        if (objetoDeserializado.IdProducto != null) {
            //var a = "Test";
            $.ajax({
                url: "../../PasarelaProducto/Details/" + objetoDeserializado.IdProducto,
                type: "GET",
                data: {},
                success: function (response) {
                    if (response != null) {
                        var cuerpoModal = GenerarCuerpoModalDeProducto(response);
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
        }
    }
}

function GenerarCuerpoModalDeProducto(objetoSeleccionado) {

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

                if (productoImagen.Descripcion != '') {
                    htmlImagenSrc.push(
                        '    <div class="carousel-caption d-none d-md-block">',
                        //'        <h5>My Caption Title (1st Image)</h5>',
                        '        <h4><span class="badge badge-secondary">' + productoImagen.Descripcion + '</span></h4>',
                        '    </div>'
                    );
                }

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
        '        <p class="card-text m-t-10">' + objetoSeleccionado.DescripcionExtendida + '</p>',
        '        <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>',
        '    </div>',
        '    <div class="card-footer bg-white">',
        '        <a href="#" rel="modal:close" class="btn btn-danger float-right"><i class="fa fa-times" aria-hidden="true"></i> Cerrar</a>',
        '    </div>',
        '</div>'
    );

    var cuerpoHtml = html.join('');
    return cuerpoHtml;

}

function AgregarAlCarro(valorSeleccionado) {

    //console.log(idProducto);
    //console.log(cantidad);

    var objetoDeserializado = JSON.parse(valorSeleccionado);
    console.log(objetoDeserializado);

    //var prm = {
    //    'IdProducto': idProducto,
    //    'Cantidad': cantidad,
    //    'IdUsuario':11
    //};

    //return $.ajax({
    //    'url': '/Carro/Agregar',
    //    'type': 'GET',
    //    'data': prm,
    //    'dataType': 'json'
    //});

};

/*
$(document).on('click', '#btnRecargar', function () {
    //console.log($("#cboEstado[class^='chosen']").val());
    if (!$('#btnRecargar').hasClass('disabled')) {
        RecargarData();
    }
});


<script>
    $(document).on('click',function(){
        $('.collapse').collapse('hide');
    })
</script> 
*/