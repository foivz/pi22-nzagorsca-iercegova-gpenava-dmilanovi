var uspjesnoUnesen = true;

const unseiKorisnikaUBazu = async () => {
  var imeKorisnika = document.getElementById("imeKorisnika").value;
  var prezimeKorisnika = document.getElementById("prezimeKorisnika").value;
  var username = document.getElementById("username").value;
  var TablicaAutomobila = document.getElementById("TablicaAutomobila").value;
  var lozinka = document.getElementById("lozinka").value;
  var ponovljenaLozinka = document.getElementById("ponovljenaLozinka").value;
  if (lozinka !== ponovljenaLozinka) {
    alert("Lozinke se ne podudaraju");
    uspjesnoUnesen = false;
  } else {
    uspjesnoUnesen = true;
    const response = await fetch(
      "https://localhost:7236/api/Login/addUser?ime=" +
        imeKorisnika +
        "&prezime=" +
        prezimeKorisnika +
        "&username=" +
        username +
        "&lozinka=" +
        lozinka +
        "&tablicaAutomobila=" +
        TablicaAutomobila,
      {
        method: "POST",
        // headers: {
        //   "Content-Type": "application/json",
        // },
      }
    );
  }

  // const myJson = await response.json();

  // return myJson;
};

var formtest = document.getElementById("registracijaKorisnika");
function handleForm(event) {
  event.preventDefault();
}
formtest.addEventListener("submit", handleForm);

function prikazi() {
  Promise.any([unseiKorisnikaUBazu()]).then(() => {
    $(function () {
      if (uspjesnoUnesen) console.log("Korisnik uspjesno unesen");
      else console.log("Korisnik nije unesen u bazu podataka");
    });
  });
}
