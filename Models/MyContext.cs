using Microsoft.EntityFrameworkCore;
namespace cSharpBelt.Models
{ 

    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }

        // DON'T FORGET TO COME BACK AND ADD YOUR DBSETS
        public DbSet<User> Users {get;set;}
        public DbSet<Happening> Happenings {get;set;}
        public DbSet<Attending> Attendings {get;set;}
    }
}
