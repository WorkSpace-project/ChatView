using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatView.Models.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ChatView.Models.DataContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //bashir pos live
            //optionsBuilder.UseSqlServer(@"Server=sql5052.site4now.net;DB_A54BD3_Bashir111999;User Id = DB_A54BD3_Bashir111999_admin;Password =bashir.111;Integrated Security=False; Trusted_Connection=False;");
             //optionsBuilder.UseSqlServer(@"Data Source=SQL5052.site4now.net;Initial Catalog=DB_A54BD3_Bashir111999;User Id=DB_A54BD3_Bashir111999_admin;Password=bashir.111;");

            //local
            optionsBuilder.UseSqlServer(@"Server=SADAQAT-PC\SQLEXPRESS01;Database=ChatView;Trusted_Connection=True;");
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public Context()
        {
            //Database.SetCommandTimeout(150000);
        }
        public virtual DbSet<Mcustomer> Mcustomers { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
    }
}
