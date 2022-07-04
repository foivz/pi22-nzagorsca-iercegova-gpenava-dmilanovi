// Initialize and add the map
function initMap() {
  const uluru = { lat: 42.651375, lng: 18.091252 };
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 15,
    center: uluru,
  });
  const plava = 'ikonica.png';
  const crvena = 'crvena-ikona.png';
  const zelena = 'zelena-ikona.png';

  Promise.any([userAction()])
  .then( markers => {
    for(var i=0; i<markers.length-1;i++)
  {
    console.log("markers[i]",markers[i]);
    const marker6 = new google.maps.Marker({
      position: { lat: markers[i].sptLatitude, lng: markers[i].sptLongitude },
      map: map,
      icon: plava,
    });
  }
  })
  .catch( error => {
    console.error("Failed to fetch")
  });

}

const userAction = async () => {
  const response = await fetch('https://localhost:7236/api/Parking/allParkingSpots', {
    method: 'GET',
   // body: myBody, // string or object
    headers: {
      'Content-Type': 'application/json'
    }
  });
  const myJson = await response.json(); //extract JSON from the http response
  // do something with myJson

  return myJson;
  
}
window.initMap = initMap;