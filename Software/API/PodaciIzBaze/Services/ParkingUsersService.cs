using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodaciIzBaze.Services
{
    public class ParkingUsersService
    {
        public void AddNewUser(TmpUser user)
        {
            using (var context = new PI2201_DBContext())
            {
                context.TmpUsers.Add(user);
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
