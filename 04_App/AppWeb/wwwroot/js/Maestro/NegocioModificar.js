var map;

$(document).ready(function () {
    //$('.selectpicker').selectpicker();
    $(".select2").select2();


});

function initMap() {
    // The location of Uluru
    var uluru = { lat: -11.986751, lng: -77.073557 };
    // The map, centered at Uluru
    map = new google.maps.Map(
        document.getElementById('map'), {
            zoom: 16,
            center: uluru
        });
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}