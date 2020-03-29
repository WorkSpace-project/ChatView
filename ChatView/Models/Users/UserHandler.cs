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
                    return (from m in db.Mcustomers
                            where m.CustomerCode == email && m.Password == password
                            select m).FirstOrDefault();
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
