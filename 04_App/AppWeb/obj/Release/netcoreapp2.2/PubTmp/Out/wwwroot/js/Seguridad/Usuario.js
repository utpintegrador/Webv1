var tb1;

$(document).ready(function () {

    $(".select2").select2();
    CargarData();

});


function CargarData() {

    $.fn.dataTable.ext.errMode = 'console';
    $('#tb1').DataTable({
        "dom": ObtenerDomGrilla(),
        "pagingType": "full_numbers",
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todo"]]
    });
};

function ObtenerDomGrilla() {
    return "<'row' <'col-md-12'p>>" +

        "<'clear'>" +
        "<'row' <'col-md-12'rt> >" +
        "<'clear'>" +

        "<'row' <'col-md-6'l> <'col-md-6'> >" +
        "<'row' <'col-md-12'i>>" +
        "<'clear'>" +
        "<'clear'>";
};