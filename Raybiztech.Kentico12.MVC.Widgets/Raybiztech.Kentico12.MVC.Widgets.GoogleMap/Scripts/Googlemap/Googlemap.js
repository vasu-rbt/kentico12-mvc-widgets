function initialize() {
    var latitude = document.getElementById('latitude').value;
    var logitude = document.getElementById('logitude').value;
    var list = document.getElementById("googlemap");
    var js = document.createElement('div');
    js.id = new Date().getTime().toString(16);
    js.setAttribute('style', "width: 100%;height: 400px;")
    list.after(js);
    var mapOptions = {
        center: new google.maps.LatLng(latitude, logitude),
        zoom: 4,
        mapTypeId: 'roadmap',
    };
    var map = new google.maps.Map(document.getElementById(js.id), mapOptions);
    var bounds = new google.maps.LatLngBounds();
    var latlng = new google.maps.LatLng(latitude, logitude);
    var marker = new google.maps.Marker({
        map: map,
        position: latlng,
        title: 'Google Map'
    });
    bounds.extend(latlng);
}