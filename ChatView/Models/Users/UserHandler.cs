using ChatView.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatView.Models.Users
{
    public class UserHandler
    {
        public async Task<Mcustomer> Authenticate(string email, string password)
        {
            using (Context db = new Context())
            {
                try
                {
                    Mcustomer user= (from m in db.Mcustomers
                            where m.CustomerCode == email && m.Password == password
                            select m).FirstOrDefault();
                    if (user!=null)
                    {
                        user.Online = true;
                        db.Mcustomers.Update(user);
                        db.SaveChanges();
                    }
                    return user;
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    throw;
                }
            }
        }
        public async Task OfflineUser(Guid id)
        {
            using (Context db = new Context())
            {
                try
                {
                        Mcustomer cust = db.Mcustomers.Where(s => s.Id == id).FirstOrDefault();
                        if (cust != null)
                        {
                            cust.Online = false;
                            db.Mcustomers.Update(cust);
                            db.SaveChanges();
                        }
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    throw;
                }

            }
        }
    }
}
