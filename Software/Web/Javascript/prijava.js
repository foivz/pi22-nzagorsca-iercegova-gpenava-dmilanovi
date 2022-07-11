var formtest = document.getElementById("prijavaKorisnika");
function handleForm(event) {
  event.preventDefault();
}
formtest.addEventListener("submit", handleForm);

const popisSvihKorisnika = async () => {
  const response = await fetch("https://localhost:7236/api/Login/allUsers", {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  });
  const myJson = await response.json();

  return myJson;
};

function prikazi() {
  Promise.any([popisSvihKorisnika()]).then((korisnici) => {
    $(function () {
      var postojiKorisnik = false;
      var korisnickoImeLogin = document.getElementById("username").value;
      var lozinkaLogin = document.getElementById("lozinka").value;
      for (var i = 0; i < korisnici.length; i++) {
        if (
          korisnickoImeLogin == korisnici[i].username &&
          lozinkaLogin == korisnici[i].lozinka
        ) {
          postojiKorisnik = true;
          sessionStorage.setItem("username", korisnickoImeLogin);
          sessionStorage.setItem("card_id", korisnici[i].cardId);
          window.location.href = "../index.html";
        }
      }
      if (!postojiKorisnik) alert("Ne postoji korisnik u bazi podataka");
    });
  });
}
