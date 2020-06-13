$(document).ready(function () {

    //if (ValidarLogin()) {
    //    ConfigurarCombos();
    $.when(CargarEstado())
        .done(function (resultEstado) {

            var select = $('#cboEstado');
            $.each(resultEstado, function () {
                select.append($("<option />").val(this.IdEstado).text(this.Descripcion));
            });

            console.log(resultEstado);
            select.val(resultEstado.IdEstado);

        })
        .fail(function (jqXHR) {
            console.log(jqXHR);
        });
    //}

});

function CargarEstado() {

    var select = $('#cboEstado');
    var prm = {
        'idTipoEstado': 1
    };

    return $.ajax({
        'url': '/Estado/ObtenerPorIdTipoEstado',
        'type': 'GET',
        'data': prm,
        'dataType': 'json',
        beforeSend: function () {
            select.empty();
        }
    });

};

