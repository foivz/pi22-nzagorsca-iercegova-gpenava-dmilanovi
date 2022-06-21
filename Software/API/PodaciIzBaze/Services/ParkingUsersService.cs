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
    }
}
