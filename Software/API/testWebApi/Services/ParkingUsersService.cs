using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository;
using WebAPI.Repository.Models;

namespace WebAPI.Services
{
    public class ParkingUsersService
    {
        public void AddNewUser(string ime, string prezime, string username, string lozinka, string tablicaAutomobila)
        {
            using (var context = new PI2201_DBContext())
            {
                var lastUserUserID = context.TmpUsers
                  .FromSqlRaw($"SELECT  TOP 1 * FROM tmp_users ORDER BY user_id DESC;").ToList();
                var lastUserCardID = context.TmpUsers
                  .FromSqlRaw($"SELECT  TOP 1 * FROM tmp_users ORDER BY card_id DESC;").ToList();
                TmpUser noviUser = new TmpUser();
                int noviUserID = lastUserUserID[0].UserId;
                int noviCardID = lastUserCardID[0].CardId;
                noviUserID++;
                noviCardID++;
                noviUser.UserId = noviUserID;
                noviUser.Name = ime;
                noviUser.Surname = prezime;
                noviUser.Lozinka = lozinka;
                noviUser.Username = username;
                noviUser.TipKorisnika = "Registrirani korisnik";
                noviUser.CardId = noviCardID;
                noviUser.CarTable = tablicaAutomobila;
                context.TmpUsers.Add(noviUser);
                context.SaveChanges();
            }
        }
        public List<TmpUser> GetAllParkingUsers()
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingUsers = context.TmpUsers.ToList();
                return parkingUsers;
            }
        }

        public List<TmpUser> GetSpecificUser(int user_Id, string lozinka)
        {
            using (var context = new PI2201_DBContext())
            {
                var users = context.TmpUsers.Where(x => x.UserId == user_Id && x.Lozinka == lozinka).ToList();
                return (List<TmpUser>)users;
            }
        }
    }
}
