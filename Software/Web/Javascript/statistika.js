var formtest = document.getElementById("mojaForma");
function handleForm(event) {
  event.preventDefault();
}
formtest.addEventListener("submit", handleForm);

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
      //console.log(parkirniSpaceovi);
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
