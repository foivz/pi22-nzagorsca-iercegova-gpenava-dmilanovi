// Initialize and add the map
function initMap() {
  const uluru = { lat: 42.651375, lng: 18.091252 };
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 15,
    center: uluru,
  });
  const plava = "ikonica.png";
  const crvena = "crvena-ikona.png";
  const zelena = "zelena-ikona.png";
  var brojSlobodnihMjesta = 0;
  var brojZauzetihMjesta = 0;
  var ukupanBrojMjesta = 0;
  Promise.allSettled([userAction3(), userAction()]).then((podaci3) => {
    $(function () {
      var infoWindow = new google.maps.InfoWindow();
      var parkingSpots = podaci3[1];
      var parkingSessions = podaci3[0];
      var valueParkingSpota = parkingSpots[Object.keys(parkingSpots)[1]];
      var valueParkingSessiona =
        parkingSessions[Object.keys(parkingSessions)[1]];

      for (var i = 0; i < valueParkingSpota.length; i++) {
        brojSlobodnihMjesta++;

        var data = valueParkingSpota[i];
        var myLatlng = new google.maps.LatLng(
          data.sptLatitude,
          data.sptLongitude
        );
        const marker6 = new google.maps.Marker({
          position: myLatlng,
          map: map,
          icon: zelena,
        });

        for (var j = 0; j < valueParkingSessiona.length; j++) {
          if (
            valueParkingSessiona[j].pssParkingSpotId ==
            valueParkingSpota[i].sptParkingSpotId
          ) {
            brojZauzetihMjesta++;
            brojSlobodnihMjesta--;
            const marker6 = new google.maps.Marker({
              position: myLatlng,
              map: map,
              icon: crvena,
            });
            (function (marker6, data) {
              const contentString =
                "</div>" +
                `<h1 id="firstHeading" class="firstHeading">${data.sptLabel}</h1>` +
                '<div id="bodyContent">' +
                `<p><b>Parking spot ID</b>: ${data.sptParkingSpotId}</p>` +
                `<p><b>Parking space ID</b>: ${data.sptParkingSpaceId}</p>` +
                `<p><b>Latitude</b>: ${data.sptLatitude}</p>` +
                `<p><b>Longitude</b>: ${data.sptLongitude}</p>` +
                `<p><b>Tip parkirnog spota</b>: ${data.sptSpotType}</p>` +
                `<p><b>Slobodno mjesto:</b> NE </p>` +
                "</div>" +
                "</div>";

              google.maps.event.addListener(marker6, "click", function (e) {
                infoWindow.setContent(contentString);
                infoWindow.open(map, marker6);
              });
            })(marker6, data);
          }
        }
        (function (marker6, data) {
          const contentString =
            "</div>" +
            `<h1 id="firstHeading" class="firstHeading">${data.sptLabel}</h1>` +
            '<div id="bodyContent">' +
            `<p><b>Parking spot ID</b>: ${data.sptParkingSpotId}</p>` +
            `<p><b>Parking space ID</b>: ${data.sptParkingSpaceId}</p>` +
            `<p><b>Latitude</b>: ${data.sptLatitude}</p>` +
            `<p><b>Longitude</b>: ${data.sptLongitude}</p>` +
            `<p><b>Tip parkirnog spota</b>: ${data.sptSpotType}</p>` +
            `<p><b>Slobodno mjesto:</b> DA </p>` +
            "</div>" +
            "</div>";

          google.maps.event.addListener(marker6, "click", function (e) {
            infoWindow.setContent(contentString);
            infoWindow.open(map, marker6);
          });
        })(marker6, data);
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
      console.log(parkirniSpaceovi);
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

// const odredeniParkingSpaces = async () => {
//   var idSpacea = document.getElementById("parkirniSpaceovi").value;
//   const response = await fetch(
//     "https://localhost:7236/api/Parking/specificParkingSpace?id=" + idSpacea,
//     {
//       method: "GET",
//       headers: {
//         "Content-Type": "application/json",
//       },
//     }
//   );
//   const myJson = await response.json();

//   return myJson;
// };

var form = document.getElementById("mojaForma");
function handleForm(event) {
  event.preventDefault();
}
form.addEventListener("submit", handleForm);

// function prikazi() {
//   Promise.allSettled([parkingSpaces()]).then((parkirniSpaceovi) => {
//     $(function () {
//       console.log(tempList.value);
//       var park = parkirniSpaceovi[0];
//       var valueParkingSpacea = park[Object.keys(park)[1]];
//       var tempList = document.getElementById("parkirniSpaceovi");
//       for (var i = 0; i < valueParkingSpacea.length; i++) {}
//     });
//   });
// }

//// PREBACENO ODOZGO

// var contentString =
//   `<div id="content">` +
//   `<div id="siteNotice">` +
//   `</div>` +
//   `<h1 id="firstHeading" class="firstHeading">${valueParkingSpota[i].sptLatitude}</h1>` +
//   '<div id="bodyContent">' +
//   "<p><b>Uluru</b>, also referred to as <b>Ayers Rock</b>, is a large " +
//   "sandstone rock formation in the southern part of the " +
//   "Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) " +
//   "south west of the nearest large town, Alice Springs; 450&#160;km " +
//   "(280&#160;mi) by road. Kata Tjuta and Uluru are the two major " +
//   "features of the Uluru - Kata Tjuta National Park. Uluru is " +
//   "sacred to the Pitjantjatjara and Yankunytjatjara, the " +
//   "Aboriginal people of the area. It has many springs, waterholes, " +
//   "rock caves and ancient paintings. Uluru is listed as a World " +
//   "Heritage Site.</p>" +
//   '<p>Attribution: Uluru, <a href="https://en.wikipedia.org/w/index.php?title=Uluru&oldid=297882194">' +
//   "https://en.wikipedia.org/w/index.php?title=Uluru</a> " +
//   "(last visited June 22, 2009).</p>" +
//   "</div>" +
//   "</div>";

// var infowindow = new google.maps.InfoWindow({
//   content: contentString,
// });

// map.addListener("click", (mapsMouseEvent) => {
//   infoWindow = new google.maps.InfoWindow({
//     position: mapsMouseEvent.latLng,
//   });
//   infowindow.setContent(
//     JSON.strongify(mapsMouseEvent.latLng.toJSON(), null, 2)
//   );
//   infoWindow.open(map);
// });

// marker6.addListener("click", () => {
//   console.log(marker6.position);
//   infowindow.open({
//     anchor: marker6,
//     map,
//     shouldFocus: false,
//   });
//   map.addListener("click", function () {
//     if (infoWindow) infoWindow.close();
//   });
// });
