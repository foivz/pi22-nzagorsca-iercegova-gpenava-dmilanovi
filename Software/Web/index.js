// Initialize and add the map
function initMap() {
  // The location of Uluru
  const uluru = { lat: 42.650537, lng: 18.091115 };
  // The map, centered at Uluru
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 15,
    center: uluru,
  });
  const iconbase = 'ikonica.png';
  // The marker, positioned at Uluru
  const marker1 = new google.maps.Marker({
    position: { lat: 42.650537, lng: 18.091115 },
    map: map,
    icon: iconbase,
  });
  const markerIzaGrada = new google.maps.Marker({
    position: { lat: 42.64238, lng: 18.112 },
    map: map,
    icon: iconbase,
  });
  const markerZicara = new google.maps.Marker({
    position: { lat: 42.6429, lng: 18.11165 },
    map: map,
    icon: iconbase,
  });
  const marker4 = new google.maps.Marker({
    position: { lat: 42.64238, lng: 18.112 },
    map: map,
    icon: iconbase,
  });
  const marker5 = new google.maps.Marker({
    position: { lat: 42.64238, lng: 18.112 },
    map: map,
    icon: iconbase,
  });
  const marker6 = new google.maps.Marker({
    position: { lat: 42.64238, lng: 18.112 },
    map: map,
    icon: iconbase,
  });

}

window.initMap = initMap;