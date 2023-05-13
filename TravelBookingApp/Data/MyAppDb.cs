using Microsoft.EntityFrameworkCore;
using TravelBookingApp.Model;

namespace TravelBookingApp.Data
{
    public class MyAppDb : DbContext
    {

        public MyAppDb(DbContextOptions<MyAppDb> options): base(options)
        {

        }

        // Table for Users
        public DbSet<Users> UsersTable { get; set; }


        // Table for Airline
        public DbSet<Airlines> AirlinesTable { get; set; }


        // Table for Flight
        public DbSet<Flights> FlightsTable { get; set; }

        // Table for Journey
        public DbSet<Journeys> JourneysTable { get; set; }


        // Inserting sample data to Users table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(

                new Users()
                {
                    Id = 1,
                    Name = "Ajinkya",
                    Email = "ajinkya@gmail.com",
                    Password = "Ajinkya123",
                    Role = "admin"
                },
                new Users()
                {
                    Id = 2,
                    Name = "Ajay",
                    Email = "ajay@gmail.com",
                    Password = "Ajay123",
                    Role = "user"
                },
                new Users()
                {
                    Id = 3,
                    Name = "Sam",
                    Email = "Sam@gmail.com",
                    Password = "Sam123",
                    Role = "user"
                },
                new Users()
                {
                    Id = 4,
                    Name = "Ram",
                    Email = "Ram@gmail.com",
                    Password = "Ram123",
                    Role = "user"
                },
                new Users()
                {
                    Id = 5,
                    Name = "John",
                    Email = "john@gmail.com",
                    Password = "John123",
                    Role = "user"
                });
        }
    }
}
