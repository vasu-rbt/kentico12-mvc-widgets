function initialize() {
    $('.googlemap_class').each(function () {
        var mapOptions = {
            center: new google.maps.LatLng(this.attributes['data-latitude'].value, this.attributes['data-longitude'].value),
            zoom: 4,
            mapTypeId: 'roadmap',
        };
        var map = new google.maps.Map(document.getElementById(this.attributes['id'].value), mapOptions);
        var bounds = new google.maps.LatLngBounds();
        var latlng = new google.maps.LatLng(this.attributes['data-latitude'].value, this.attributes['data-longitude'].value);
        var marker = new google.maps.Marker({
            map: map,
            position: latlng,
            title: 'Google Map'
        });
        bounds.extend(latlng);
    });
}