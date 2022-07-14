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

const dohvatiParkingSpotsZaParkingSpace = async () => {
  var idSpacea = document.getElementById("parkirniSpaceovi").value;
  const response = await fetch(
    "https://localhost:7236/api/Parking/TypeOfParkingSpotsPerParkingSpace?Id=280",
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

const dohvatiSenzore = async () => {
  var idSpacea = document.getElementById("parkirniSpaceovi").value;
  const response = await fetch('https://localhost:7236/api/Parking/SensorsForParkingSpace?Id=280', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    }
  });
  const myJson = await response.json();

  return myJson;

}

const dohvatiPostotke = async () => {
  var datum = document.getElementById("datumStatitika").value;
  const response = await fetch('https://localhost:7236/api/MachineLearning/PercentageOfFreeParking?datum=2021-07-02T20:20', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    }
  });
  const myJson = await response.json();

  return myJson;

}


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
  
    Chart.defaults.global.defaultFontSize = 16;
    Chart.defaults.global.defaultFontColor = '#b3b3b3';
    Chart.defaults.global.defaultFontFamily = 'Helvetica';
    if (myDoughnutChart_2 != undefined)
      myDoughnutChart_2.destroy();
  
    if (drugiChart != undefined)
      drugiChart.destroy();
  
    if (prviChart != undefined)
      prviChart.destroy();
  
    Promise.any([dohvatiSenzore()])
      .then(podaci2 => {
        $(function () {
          var x = 0;
          prviChart = new Chart(document.getElementById("prvi"), {
            type: 'bar',
            data: {
              labels: ["Senzor ID:" + podaci2[x].snrSensorId, "Senzor ID:" + podaci2[x + 1].snrSensorId, "Senzor ID:" + podaci2[x + 2].snrSensorId, "Senzor ID:" + podaci2[x + 3].snrSensorId, "Senzor ID:" + podaci2[x + 4].snrSensorId, "Senzor ID:" + podaci2[x + 5].snrSensorId, "Senzor ID:" + podaci2[x + 6].snrSensorId, "Senzor ID:" + podaci2[x + 7].snrSensorId, "Senzor ID:" + podaci2[x + 8].snrSensorId, "Senzor ID:" + podaci2[x + 9].snrSensorId,],
              datasets: [
                {
                  label: "Battery",
                  backgroundColor: "#3e95cd",
  
                  data: [podaci2[x].snrNbpsBatteryLevel, podaci2[x + 1].snrNbpsBatteryLevel, podaci2[x + 2].snrNbpsBatteryLevel, podaci2[x + 3].snrNbpsBatteryLevel, podaci2[x + 4].snrNbpsBatteryLevel, podaci2[x + 5].snrNbpsBatteryLevel, podaci2[x + 6].snrNbpsBatteryLevel, podaci2[x + 7].snrNbpsBatteryLevel, podaci2[x + 8].snrNbpsBatteryLevel, podaci2[x + 9].snrNbpsBatteryLevel,]
                }
              ]
            },
            options: {
              legend: { display: false },
              title: {
                display: true,
                text: 'Prikaz 10 senzora parkirnog spacea s najslabijim baterijama'
              },
            }
          });
        })
      })
    Promise.any([dohvatiPostotke()]).then((podaci3) => {
      $(function () {
        // console.log(podaci3);
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
        var varijablica25;
        var varijablica26;
        var varijablica27;
        var varijablica28;
        var varijablica29;
        var varijablica30;
        var varijablica31;
        var varijablica32;
        var varijablica33;
        var varijablica34;
        var varijablica35;
        var varijablica36;
        var varijablica37;
        var varijablica38;
        var varijablica39;
        var varijablica40;
        var varijablica41;
        var varijablica42;
        var varijablica43;
        var varijablica44;
        var varijablica45;
        var varijablica46;
        var varijablica47;
        var varijablica48;
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
        var satiIminute25;
        var satiIminute26;
        var satiIminute27;
        var satiIminute28;
        var satiIminute29;
        var satiIminute30;
        var satiIminute31;
        var satiIminute32;
        var satiIminute33;
        var satiIminute34;
        var satiIminute35;
        var satiIminute36;
        var satiIminute37;
        var satiIminute38;
        var satiIminute39;
        var satiIminute40;
        var satiIminute41;
        var satiIminute42;
        var satiIminute43;
        var satiIminute44;
        var satiIminute45;
        var satiIminute46;
        var satiIminute47;
        var satiIminute48;
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
        var podaci25;
        var podaci26;
        var podaci27;
        var podaci28;
        var podaci29;
        var podaci30;
        var podaci31;
        var podaci32;
        var podaci33;
        var podaci34;
        var podaci35;
        var podaci36;
        var podaci37;
        var podaci38;
        var podaci39;
        var podaci40;
        var podaci41;
        var podaci42;
        var podaci43;
        var podaci44;
        var podaci45;
        var podaci46;
        var podaci47;
        var podaci48;
        for (var z = 0; z < 48; z++) {
          varijablica1 = podaci3[0].split(";");
          varijablica2 = podaci3[1].split(";");
          varijablica4 = podaci3[3].split(";");
          varijablica3 = podaci3[2].split(";");
          varijablica5 = podaci3[4].split(";");
          varijablica6 = podaci3[5].split(";");
          varijablica7 = podaci3[6].split(";");
          varijablica8 = podaci3[7].split(";");
          varijablica9 = podaci3[8].split(";");
          varijablica10 = podaci3[9].split(";");
          varijablica11 = podaci3[10].split(";");
          varijablica12 = podaci3[11].split(";");
          varijablica13 = podaci3[12].split(";");
          varijablica14 = podaci3[13].split(";");
          varijablica15 = podaci3[14].split(";");
          varijablica16 = podaci3[15].split(";");
          varijablica17 = podaci3[16].split(";");
          varijablica18 = podaci3[17].split(";");
          varijablica19 = podaci3[18].split(";");
          varijablica20 = podaci3[19].split(";");
          varijablica21 = podaci3[20].split(";");
          varijablica22 = podaci3[21].split(";");
          varijablica23 = podaci3[22].split(";");
          varijablica24 = podaci3[23].split(";");
          varijablica25 = podaci3[24].split(";");
          varijablica26 = podaci3[25].split(";");
          varijablica27 = podaci3[26].split(";");
          varijablica28 = podaci3[27].split(";");
          varijablica29 = podaci3[28].split(";");
          varijablica30 = podaci3[29].split(";");
          varijablica31 = podaci3[30].split(";");
          varijablica32 = podaci3[31].split(";");
          varijablica33 = podaci3[32].split(";");
          varijablica34 = podaci3[33].split(";");
          varijablica35 = podaci3[34].split(";");
          varijablica36 = podaci3[35].split(";");
          varijablica37 = podaci3[36].split(";");
          varijablica38 = podaci3[37].split(";");
          varijablica39 = podaci3[38].split(";");
          varijablica40 = podaci3[39].split(";");
          varijablica41 = podaci3[40].split(";");
          varijablica42 = podaci3[41].split(";");
          varijablica43 = podaci3[42].split(";");
          varijablica44 = podaci3[43].split(";");
          varijablica45 = podaci3[44].split(";");
          varijablica46 = podaci3[45].split(";");
          varijablica47 = podaci3[46].split(";");
          varijablica48 = podaci3[47].split(";");
          satiIminute1 = varijablica1[1].split(',');
          satiIminute2 = varijablica2[1].split(',');
          satiIminute3 = varijablica3[1].split(',');
          satiIminute4 = varijablica4[1].split(',');
          satiIminute5 = varijablica5[1].split(',');
          satiIminute6 = varijablica6[1].split(',');
          satiIminute7 = varijablica7[1].split(',');
          satiIminute8 = varijablica8[1].split(',');
          satiIminute9 = varijablica9[1].split(',');
          satiIminute10 = varijablica10[1].split(',');
          satiIminute11 = varijablica11[1].split(',');
          satiIminute12 = varijablica12[1].split(',');
          satiIminute13 = varijablica13[1].split(',');
          satiIminute14 = varijablica14[1].split(',');
          satiIminute15 = varijablica15[1].split(',');
          satiIminute16 = varijablica16[1].split(',');
          satiIminute17 = varijablica17[1].split(',');
          satiIminute18 = varijablica18[1].split(',');
          satiIminute19 = varijablica19[1].split(',');
          satiIminute20 = varijablica20[1].split(',');
          satiIminute21 = varijablica21[1].split(',');
          satiIminute22 = varijablica22[1].split(',');
          satiIminute23 = varijablica23[1].split(',');
          satiIminute24 = varijablica24[1].split(',');
          satiIminute25 = varijablica25[1].split(',');
          satiIminute26 = varijablica26[1].split(',');
          satiIminute27 = varijablica27[1].split(',');
          satiIminute28 = varijablica28[1].split(',');
          satiIminute29 = varijablica29[1].split(',');
          satiIminute30 = varijablica30[1].split(',');
          satiIminute31 = varijablica31[1].split(',');
          satiIminute32 = varijablica32[1].split(',');
          satiIminute33 = varijablica33[1].split(',');
          satiIminute34 = varijablica34[1].split(',');
          satiIminute35 = varijablica35[1].split(',');
          satiIminute36 = varijablica36[1].split(',');
          satiIminute37 = varijablica37[1].split(',');
          satiIminute38 = varijablica38[1].split(',');
          satiIminute39 = varijablica39[1].split(',');
          satiIminute40 = varijablica40[1].split(',');
          satiIminute41 = varijablica41[1].split(',');
          satiIminute42 = varijablica42[1].split(',');
          satiIminute43 = varijablica43[1].split(',');
          satiIminute44 = varijablica44[1].split(',');
          satiIminute45 = varijablica45[1].split(',');
          satiIminute46 = varijablica46[1].split(',');
          satiIminute47 = varijablica47[1].split(',');
          satiIminute48 = varijablica48[1].split(',');
        }
        drugiChart = new Chart(document.getElementById("treci"), {
          type: 'bar',
          data: {
            labels: [varijablica1[0], varijablica2[0], varijablica3[0], varijablica4[0], varijablica5[0], varijablica6[0], varijablica7[0], varijablica8[0], varijablica9[0], varijablica10[0], varijablica11[0], varijablica12[0], varijablica13[0], varijablica14[0], varijablica15[0], varijablica16[0], varijablica17[0], varijablica18[0], varijablica19[0], varijablica20[0], varijablica21[0], varijablica22[0], varijablica23[0], varijablica24[0], varijablica25[0], varijablica26[0], varijablica27[0], varijablica28[0], varijablica29[0], varijablica30[0], varijablica31[0], varijablica32[0], varijablica33[0], varijablica34[0], varijablica35[0], varijablica36[0], varijablica37[0], varijablica38[0], varijablica39[0], varijablica40[0], varijablica41[0], varijablica42[0], varijablica43[0], varijablica44[0], varijablica45[0], varijablica46[0], varijablica47[0], varijablica48[0]],
            datasets: [
              {
                fill: false,
                borderColor: '#1971c2',
                label: "Postotak zauzetosti parkirnih mjesta",
                backgroundColor: "#3e95cd",
                data: [satiIminute1[0], satiIminute2[0], satiIminute3[0], satiIminute4[0], satiIminute5[0], satiIminute6[0], satiIminute7[0], satiIminute8[0], satiIminute9[0], satiIminute10[0], satiIminute11[0], satiIminute12[0], satiIminute13[0], satiIminute14[0], satiIminute15[0], satiIminute16[0], satiIminute17[0], satiIminute18[0], satiIminute19[0], satiIminute20[0], satiIminute21[0], satiIminute22[0], satiIminute23[0], satiIminute24[0], satiIminute25[0], satiIminute26[0], satiIminute27[0], satiIminute28[0], satiIminute29[0], satiIminute30[0], satiIminute31[0], satiIminute32[0], satiIminute33[0], satiIminute34[0], satiIminute35[0], satiIminute36[0], satiIminute37[0], satiIminute38[0], satiIminute39[0], satiIminute40[0], satiIminute41[0], satiIminute42[0], satiIminute43[0], satiIminute44[0], satiIminute45[0], satiIminute46[0], satiIminute47[0], satiIminute48[0]]
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
              }],
            },
            legend: { display: false },
            title: {
              display: true,
              text: 'Postotak zauzetosti parkirališta za odabrani datum:'
            },
  
          }
        });
      })
    })
      .catch(error => {
        console.error("Failed to fetch")
      });
  
    Promise.any([dohvatiParkingSpotsZaParkingSpace()])
      .then(datas => {
        // console.log(datas);
        var splitano = datas[0].split(";");
        //console.log(splitano);
        var regularSplitano;
        var handicappedSplitano;
        var reservedSplitano;
        var taxiSplitano;
        var chargingSplitano;
        for (var i = 0; i < 5; i++) {
          if (splitano[i] == "" || splitano[i] == undefined) {
            break;
          } else {
            var splitanI = splitano[i].split(':');
            if (splitanI[0].localeCompare("Regular") === 0)
              regularSplitano = splitanI[1];
            else if (splitanI[0].localeCompare("Handicapped") == 0)
              handicappedSplitano = splitanI[1];
            else if (splitanI[0].localeCompare("TAXI") == 0)
              taxiSplitano = splitanI[1];
            else if (splitanI[0].localeCompare("Reserved") == 0)
              reservedSplitano = splitanI[1];
            else if (splitanI[0].localeCompare("Charging") == 0)
              chargingSplitano = splitanI[1];
          }
        }
        $(function () {
          var ctx_2 = document.getElementById("drugi").getContext('2d');
          var data_2 = {
            datasets: [{
              data: [regularSplitano, handicappedSplitano, reservedSplitano, taxiSplitano, chargingSplitano],
              backgroundColor: [
                '#3c8dbc',
                '#f56954',
                '#f39c12',
                '#f4dddd',
                '#80D943',
              ],
            }],
            labels: [
              'Obično parking mjesto',
              'Invalidsko parking mjesto',
              'Rezervirano parking mjesto',
              'Mjesto za TAXI',
              'Parking mjesto za punjenje',
            ]
          };
  
          myDoughnutChart_2 = new Chart(ctx_2, {
            type: 'doughnut',
            data: data_2,
            options: {
              responsive: false,
              maintainAspectRatio: false,
              legend: {
                position: 'bottom',
                labels: {
                  boxWidth: 12
                }
              }
            }
          });
  
  
        });
      })
      .catch(error => {
        console.error("Failed to fetch")
      });
}
window.onload = dodajParkingSpaces();