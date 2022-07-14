// Initialize and add the map
let map;
function initMap() {
  lat = 42.651375;
  lng = 18.091252;
  const uluru = { lat: lat, lng: lng };
  map = new google.maps.Map(document.getElementById("map"), {
    zoom: 15,
    center: uluru,
    mapTypeId: "satellite",
  });
  //console.log("AAAAAA", map);
  promjena();
}
function promjena() {
  const plava = "Ikonice/ikonica.png";
  const crvena = "Ikonice/crvena-ikona.png";
  const zelena = "Ikonice/zelena-ikona.png";
  var brojSlobodnihMjesta = 0;
  var brojZauzetihMjesta = 0;
  var ukupanBrojMjesta = 0;
  Promise.allSettled([userAction3(), userAction(), userAction2()]).then((podaci3) => {
    $(function () {
      var infoWindow = new google.maps.InfoWindow();
      console.log(podaci3);
      function isInfoWindowOpen(infoWindow) {
        var map = infoWindow.getMap();
        return map !== null && typeof map !== "undefined";
      }
      var parkingSpots = podaci3[1];
      var parkingSessions = podaci3[0];
      var parkingSpacess = podaci3[2];
      var valueParkingSpota = parkingSpots[Object.keys(parkingSpots)[1]];
      var valueParkingSessiona =
        parkingSessions[Object.keys(parkingSessions)[1]];
      var valueParkingSpacea =
      parkingSpacess[Object.keys(parkingSpacess)[1]];
      for (var i = 0; i < valueParkingSpota.length; i++) {
        brojSlobodnihMjesta++;
        var data = valueParkingSpota[i];
        var labelParkingSpace;
        for(var j = 0; j < valueParkingSpacea.length; j++){
          if(valueParkingSpota[i].sptParkingSpaceId === valueParkingSpacea[j].pspParkingSpaceId){
            labelParkingSpace = valueParkingSpacea[j].pspLabel;
            console.log(labelParkingSpace);
            break;
          }
        }
        console.log(labelParkingSpace);
        const marker6 = new google.maps.Marker({
          position: {
            lat: valueParkingSpota[i].sptLatitude,
            lng: valueParkingSpota[i].sptLongitude,
          },
          map: map,
          icon: zelena,
        });

        (function (marker6, data) {
          const contentString =
            "</div>" +
            `<h2 id="firstHeading" class="firstHeading">${labelParkingSpace} (${data.sptLabel})</h2>` +
            '<div id="bodyContent">' +
            `<p><b>Parking spot ID</b>: ${data.sptParkingSpotId}</p>` +
            `<p><b>Parking space ID</b>: ${data.sptParkingSpaceId}</p>` +
            `<p><b>Latitude</b>: ${data.sptLatitude}</p>` +
            `<p><b>Longitude</b>: ${data.sptLongitude}</p>` +
            `<p><b>Tip parkirnog spota</b>: ${data.sptSpotType}</p>` +
            `<p><b>Slobodno mjesto:</b> Da </p>` +
            "</div>" +
            "</div>";

          google.maps.event.addListener(marker6, "click", function (e) {
            if (isInfoWindowOpen(infoWindow)) {
              infoWindow.close();
            }
            infoWindow.setContent(contentString);
            infoWindow.open(map, marker6);
          });
        })(marker6, data);

        for (var j = 0; j < valueParkingSessiona.length; j++) {
          if (
            valueParkingSessiona[j].pssParkingSpotId ==
            valueParkingSpota[i].sptParkingSpotId
          ) {
            brojZauzetihMjesta++;
            brojSlobodnihMjesta--;
            const marker6 = new google.maps.Marker({
              position: {
                lat: valueParkingSpota[i].sptLatitude,
                lng: valueParkingSpota[i].sptLongitude,
              },
              map: map,
              icon: crvena,
            });

            (function (marker6, data) {
              const contentString =
                "</div>" +
                `<h2 id="firstHeading" class="firstHeading">${labelParkingSpace} (${data.sptLabel})</h2>` +
                '<div id="bodyContent">' +
                `<p><b>Parking spot ID</b>: ${data.sptParkingSpotId}</p>` +
                `<p><b>Parking space ID</b>: ${data.sptParkingSpaceId}</p>` +
                `<p><b>Latitude</b>: ${data.sptLatitude}</p>` +
                `<p><b>Longitude</b>: ${data.sptLongitude}</p>` +
                `<p><b>Tip parkirnog spota</b>: ${data.sptSpotType}</p>` +
                `<p><b>Slobodno mjesto:</b> Ne </p>` +
                "</div>" +
                "</div>";

              google.maps.event.addListener(marker6, "click", function (e) {
                if (isInfoWindowOpen(infoWindow)) {
                  infoWindow.close();
                }
                infoWindow.setContent(contentString);
                infoWindow.open(map, marker6);
              });
            })(marker6, data);
          }
        }
      }
      document.getElementById("brojSlobodnihMjestaPocetna").value =
        brojSlobodnihMjesta.toString();
      ukupanBrojMjesta = brojSlobodnihMjesta + brojZauzetihMjesta;
      document.getElementById("ukupanBrojMjestaPocetna").value =
        ukupanBrojMjesta.toString();
      document.getElementById("brojZauzetihhMjestaPocetna").value =
        brojZauzetihMjesta.toString();
    });
  });
}

const userAction = async () => {
  const response = await fetch(
    "https://localhost:7236/api/Parking/allParkingSpots",
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  const myJson = await response.json();
  return myJson;
};

const userAction2 = async () => {
  const response = await fetch(
    "https://localhost:7236/api/Parking/allParkingSpaces",
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  const myJson = await response.json();
  return myJson;
};

const userAction3 = async () => {
  var datum = document.getElementById("datumPocetna").value;
  const response3 = await fetch(
    "https://localhost:7236/api/Parking/parkingSessionsPerDate?vrijeme=" +
      datum,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  const myJson3 = await response3.json();

  return myJson3;
};
window.initMap = initMap;

const parkingSpaces = async () => {
  const response = await fetch(
    "https://localhost:7236/api/Parking/allParkingSpaces",
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  const myJson = await response.json();

  return myJson;
};

function dodajParkingSpaces() {
  Promise.allSettled([parkingSpaces()]).then((parkirniSpaceovi) => {
    $(function () {
      var park = parkirniSpaceovi[0];
      var valueParkingSpacea = park[Object.keys(park)[1]];
      var tempList = document.getElementById("parkirniSpaceovi");
      for (var i = 0; i < valueParkingSpacea.length; i++) {
        var option = document.createElement("option");
        option.text = valueParkingSpacea[i].pspLabel;
        option.value = valueParkingSpacea[i].pspParkingSpaceId;
        tempList.add(option);
      }
    });
  });
}
window.onload = dodajParkingSpaces();

var formtest = document.getElementById("mojaForma");
function handleForm(event) {
  event.preventDefault();
}
formtest.addEventListener("submit", handleForm);

const odredeniParkingSpaces = async () => {
  var idSpacea = document.getElementById("parkirniSpaceovi").value;
  const response = await fetch(
    "https://localhost:7236/api/Parking/specificParkingSpace?id=" + idSpacea,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  const myJson = await response.json();

  return myJson;
};

function prikazi() {
  Promise.allSettled([odredeniParkingSpaces()]).then((parkirniSpaceovi2) => {
    $(function () {
      var park = parkirniSpaceovi2[0];
      var valueParkingSpacea = park[Object.keys(park)[1]];
      pokaziNaKarti(
        valueParkingSpacea[0].pspLatitude,
        valueParkingSpacea[0].pspLongitude
      );
    });
  });
}
function pokaziNaKarti(lat, lng) {
  map.setCenter({ lat: lat, lng: lng });
  map.setZoom(19);
}
