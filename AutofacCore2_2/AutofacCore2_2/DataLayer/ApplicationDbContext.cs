using AutofacCore2_2.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutofacCore2_2.DataLayer
{
    //LD DB001 - need to generate Interface returning DbContext

    /// <summary>
    /// Interface of the "DbFactory" returning new or existing instance of "ApplicationDbContext"
    /// </summary>
    public interface IDbFactory
    {
        ApplicationDbContext Init();
    }

    /// <summary>
    /// Concrete Implementation. Returns an instance on "ApplicationDbContext" by method "Init"
    /// </summary>
    public class DbFactory : IDbFactory
    {
        ApplicationDbContext dbContext;

        public ApplicationDbContext Init()
        {
            return dbContext ?? (dbContext = new ApplicationDbContext());
        }
    }

    /// <summary>
    /// Implements the "ApplicationDbContext"
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(){ }

        public DbSet<Person> Persons { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
