using Microsoft.EntityFrameworkCore;
using ConsoleTest.Entities;

namespace ConsoleTest.DbContexts
{

    public class DeskInfoContext : DbContext
    {
        //LINQ queries against DBSet, will be translated against the mock Database instance
        public DbSet<Desk> desk { get; set; } = null!;
        public DbSet<BookingStatus> bookingStatus { get; set; } = null!;


        public DeskInfoContext(DbContextOptions<DeskInfoContext> options)
        : base(options)
        {
            //By exposing this ctor, we can provide these optins at the moment we register the DBContext. 
            //And overload parameters.
        }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //This tells the database that it is bieng used to connect to a sql light database. 
            optionsBuilder.UseSqlite("connectionstring");
            base.OnConfiguring(optionsBuilder);

        }*/
    }
}