using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ONUR\\SQLEXPRESS; initial catalog=ReProduceDB; integrated Security=true; TrustServerCertificate=True") ;


        }
         

        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companies { get; set; }


    }
}
