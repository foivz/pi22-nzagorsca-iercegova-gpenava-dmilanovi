function ucitavanje(){
    const odredeniParkingSpaceSaDatumom2 = async () => {
      const response = await fetch(
        "https://localhost:7236/api/MachineLearning/PercentageOfParking?id=280&datum=2021-07-02T20:20",
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

    const dohvatiPostotke2 = async () => {
      const response = await fetch('https://localhost:7236/api/Parking/PercentageForParkingSpace?Id=280&datum=2021-07-02T20:20', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        }
      });
      const myJson = await response.json();

      return myJson;

    }


    Chart.defaults.global.defaultFontSize = 16;
    Chart.defaults.global.defaultFontColor = '#b3b3b3';
    Chart.defaults.global.defaultFontFamily = 'Helvetica';
    if (drugiChart != undefined)
      drugiChart.destroy();

    Promise.allSettled([odredeniParkingSpaceSaDatumom2()]).then(
      (parkirniSpaceovi2) => {
        $(function () {
          var park = parkirniSpaceovi2[0];
          var valueParkingSpacea = park[Object.keys(park)[1]];
          var cijeliBroj = valueParkingSpacea[0].pslLoad.toString().split(".");
          document.getElementById("postotakZauzetosti").value = cijeliBroj[0] + "%";
          console.log(valueParkingSpacea[0].pslLoad);
        });
      }
    );
    Promise.any([dohvatiPostotke2()]).then((podaci3) => {
      $(function () {
        var varijablica1;
        var varijablica2;
        var varijablica3;
        var varijablica4;
        var varijablica5;
        var varijablica6;
        var varijablica7;
        var varijablica8;
        var varijablica9;
        var varijablica10;
        var varijablica11;
        var varijablica12;
        var varijablica13;
        var varijablica14;
        var varijablica15;
        var varijablica16;
        var varijablica17;
        var varijablica18;
        var varijablica19;
        var varijablica20;
        var varijablica21;
        var varijablica22;
        var varijablica23;
        var varijablica24;
        var satiIminute1;
        var satiIminute2;
        var satiIminute3;
        var satiIminute4;
        var satiIminute5;
        var satiIminute6;
        var satiIminute7;
        var satiIminute8;
        var satiIminute9;
        var satiIminute10;
        var satiIminute11;
        var satiIminute12;
        var satiIminute13;
        var satiIminute14;
        var satiIminute15;
        var satiIminute16;
        var satiIminute17;
        var satiIminute18;
        var satiIminute19;
        var satiIminute20;
        var satiIminute21;
        var satiIminute22;
        var satiIminute23;
        var satiIminute24;
        var podaci1;
        var podaci2;
        var podaci30;
        var podaci4;
        var podaci5;
        var podaci6;
        var podaci7;
        var podaci8;
        var podaci9;
        var podaci10;
        var podaci11;
        var podaci12;
        var podaci13;
        var podaci14;
        var podaci15;
        var podaci16;
        var podaci17;
        var podaci18;
        var podaci19;
        var podaci20;
        var podaci21;
        var podaci22;
        var podaci23;
        var podaci24;
        for (var z = 0; z < 24; z++) {
          varijablica1 = podaci3[0].pslDatetime.split("T");
          varijablica2 = podaci3[1].pslDatetime.split("T");
          varijablica3 = podaci3[2].pslDatetime.split("T");
          varijablica4 = podaci3[3].pslDatetime.split("T");
          varijablica5 = podaci3[4].pslDatetime.split("T");
          varijablica6 = podaci3[5].pslDatetime.split("T");
          varijablica7 = podaci3[6].pslDatetime.split("T");
          varijablica8 = podaci3[7].pslDatetime.split("T");
          varijablica9 = podaci3[8].pslDatetime.split("T");
          varijablica10 = podaci3[9].pslDatetime.split("T");
          varijablica11 = podaci3[10].pslDatetime.split("T");
          varijablica12 = podaci3[11].pslDatetime.split("T");
          varijablica13 = podaci3[12].pslDatetime.split("T");
          varijablica14 = podaci3[13].pslDatetime.split("T");
          varijablica15 = podaci3[14].pslDatetime.split("T");
          varijablica16 = podaci3[15].pslDatetime.split("T");
          varijablica17 = podaci3[16].pslDatetime.split("T");
          varijablica18 = podaci3[17].pslDatetime.split("T");
          varijablica19 = podaci3[18].pslDatetime.split("T");
          varijablica20 = podaci3[19].pslDatetime.split("T");
          varijablica21 = podaci3[20].pslDatetime.split("T");
          varijablica22 = podaci3[21].pslDatetime.split("T");
          varijablica23 = podaci3[22].pslDatetime.split("T");
          varijablica24 = podaci3[23].pslDatetime.split("T");
          satiIminute1 = varijablica1[1].split('.');
          satiIminute2 = varijablica2[1].split('.');
          satiIminute3 = varijablica3[1].split('.');
          satiIminute4 = varijablica4[1].split('.');
          satiIminute5 = varijablica5[1].split('.');
          satiIminute6 = varijablica6[1].split('.');
          satiIminute7 = varijablica7[1].split('.');
          satiIminute8 = varijablica8[1].split('.');
          satiIminute9 = varijablica9[1].split('.');
          satiIminute10 = varijablica10[1].split('.');
          satiIminute11 = varijablica11[1].split('.');
          satiIminute12 = varijablica12[1].split('.');
          satiIminute13 = varijablica13[1].split('.');
          satiIminute14 = varijablica14[1].split('.');
          satiIminute15 = varijablica15[1].split('.');
          satiIminute16 = varijablica16[1].split('.');
          satiIminute17 = varijablica17[1].split('.');
          satiIminute18 = varijablica18[1].split('.');
          satiIminute19 = varijablica19[1].split('.');
          satiIminute20 = varijablica20[1].split('.');
          satiIminute21 = varijablica21[1].split('.');
          satiIminute22 = varijablica22[1].split('.');
          satiIminute23 = varijablica23[1].split('.');
          satiIminute24 = varijablica24[1].split('.');
          podaci1 = podaci3[0].pslLoad;
          podaci2 = podaci3[1].pslLoad;
          podaci30 = podaci3[2].pslLoad;
          podaci4 = podaci3[3].pslLoad;
          podaci5 = podaci3[4].pslLoad;
          podaci6 = podaci3[5].pslLoad;
          podaci7 = podaci3[6].pslLoad;
          podaci8 = podaci3[7].pslLoad;
          podaci9 = podaci3[8].pslLoad;
          podaci10 = podaci3[9].pslLoad;
          podaci11 = podaci3[10].pslLoad;
          podaci12 = podaci3[11].pslLoad;
          podaci13 = podaci3[12].pslLoad;
          podaci14 = podaci3[13].pslLoad;
          podaci15 = podaci3[14].pslLoad;
          podaci16 = podaci3[15].pslLoad;
          podaci17 = podaci3[16].pslLoad;
          podaci18 = podaci3[17].pslLoad;
          podaci19 = podaci3[18].pslLoad;
          podaci20 = podaci3[19].pslLoad;
          podaci21 = podaci3[20].pslLoad;
          podaci22 = podaci3[21].pslLoad;
          podaci23 = podaci3[22].pslLoad;
          podaci24 = podaci3[23].pslLoad;
        }
        drugiChart = new Chart(document.getElementById("treci"), {
          type: 'line',
          data: {
            labels: [satiIminute1[0], satiIminute2[0], satiIminute3[0], satiIminute4[0], satiIminute5[0], satiIminute6[0], satiIminute7[0], satiIminute8[0], satiIminute9[0], satiIminute10[0], satiIminute11[0], satiIminute12[0], satiIminute13[0], satiIminute14[0], satiIminute15[0], satiIminute16[0], satiIminute17[0], satiIminute18[0], satiIminute19[0], satiIminute20[0], satiIminute21[0], satiIminute22[0], satiIminute23[0], satiIminute24[0]],
            datasets: [
              {
                fill: false,
                borderColor: '#1971c2',
                label: "Postotak zauzetosti",
                backgroundColor: "#3e95cd",
                pointRadius: 5,
                pointHoverRadius: 8,
                
                  data: [podaci1, podaci2, podaci30, podaci4, podaci5, podaci6, podaci7, podaci8, podaci9, podaci10, podaci11, podaci12, podaci13, podaci14, podaci15, podaci16, podaci17, podaci18, podaci19, podaci20, podaci21, podaci22, podaci23, podaci24]
              }
            ]
          },
          options: {
            scales: {
              yAxes: [{
                scaleLabel: {
                  display: true,
                  labelString: 'Postotak (%)'
                }
              }]
              
            },
            legend: { display: false },
            title: {
              display: true,
              text: 'Postotak zauzetosti:'
            },

          }
        });
      })
    })
      .catch(error => {
        console.error("Failed to fetch")
      });
  }
window.onload = ucitavanje();

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

