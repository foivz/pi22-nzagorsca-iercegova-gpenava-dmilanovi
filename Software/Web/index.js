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
      var parkingSpots = podaci3[1];
      var parkingSessions = podaci3[0];
      var valueParkingSpota = parkingSpots[Object.keys(parkingSpots)[1]];
      var valueParkingSessiona =
        parkingSessions[Object.keys(parkingSessions)[1]];
      console.log(parkingSessions);
      for (var i = 0; i < valueParkingSpota.length; i++) {
        brojSlobodnihMjesta++;
        const marker6 = new google.maps.Marker({
          position: {
            lat: valueParkingSpota[i].sptLatitude,
            lng: valueParkingSpota[i].sptLongitude,
          },
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
              position: {
                lat: valueParkingSpota[i].sptLatitude,
                lng: valueParkingSpota[i].sptLongitude,
              },
              map: map,
              icon: crvena,
            });
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

// function initMap() {
//   const uluru = { lat: 42.651375, lng: 18.091252 };
//   const map = new google.maps.Map(document.getElementById("map"), {
//     zoom: 15,
//     center: uluru,
//   });
//   const plava = "ikonica.png";
//   const crvena = "crvena-ikona.png";
//   const zelena = "zelena-ikona.png";

//   Promise.any([userAction()])
//     .then((markers) => {
//       for (var i = 0; i < markers.length - 1; i++) {
//         if (markers[i].sptOccupied == true) {
//           const marker6 = new google.maps.Marker({
//             position: {
//               lat: markers[i].sptLatitude,
//               lng: markers[i].sptLongitude,
//             },
//             map: map,
//             icon: crvena,
//           });
//         } else {
//           const marker6 = new google.maps.Marker({
//             position: {
//               lat: markers[i].sptLatitude,
//               lng: markers[i].sptLongitude,
//             },
//             map: map,
//             icon: zelena,
//           });
//         }
//       }
//     })
//     .catch((error) => {
//       console.error("Failed to fetch");
//     });
// }

// const userAction = async () => {
//   const response = await fetch(
//     "https://localhost:7236/api/Parking/allParkingSpots",
//     {
//       method: "GET",
//       // body: myBody, // string or object
//       headers: {
//         "Content-Type": "application/json",
//       },
//     }
//   );
//   const myJson = await response.json(); //extract JSON from the http response
//   // do something with myJson

//   return myJson;
// };
// window.initMap = initMap;

// function initMap2() {
//   Promise.any([userAction()])
//     .then((markers) => {
//       for (var i = 0; i < markers.length - 1; i++) {
//         const contentString =
//           '<div id="content">' +
//           '<div id="siteNotice">' +
//           "</div>" +
//           '<h1 id="firstHeading" class="firstHeading"></h1>' +
//           '<div id="bodyContent">' +
//           "<p><b>Uluru</b>, also referred to as <b>Ayers Rock</b>, is a large " +
//           "sandstone rock formation in the southern part of the " +
//           "Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) " +
//           "south west of the nearest large town, Alice Springs; 450&#160;km " +
//           "(280&#160;mi) by road. Kata Tjuta and Uluru are the two major " +
//           "features of the Uluru - Kata Tjuta National Park. Uluru is " +
//           "sacred to the Pitjantjatjara and Yankunytjatjara, the " +
//           "Aboriginal people of the area. It has many springs, waterholes, " +
//           "rock caves and ancient paintings. Uluru is listed as a World " +
//           "Heritage Site.</p>" +
//           '<p>Attribution: Uluru, <a href="https://en.wikipedia.org/w/index.php?title=Uluru&oldid=297882194">' +
//           "https://en.wikipedia.org/w/index.php?title=Uluru</a> " +
//           "(last visited June 22, 2009).</p>" +
//           "</div>" +
//           "</div>";

//         const infowindow = new google.maps.InfoWindow({
//           content: contentString,
//         });

//         markers[i].addListener("click", () => {
//           infowindow.open({
//             anchor: markers[i],
//             map,
//             shouldFocus: false,
//           });
//         });
//       }
//     })
//     .catch((error) => {
//       console.error("Failed to fetch", error);
//     });
// }

// window.initMap2 = initMap2;
