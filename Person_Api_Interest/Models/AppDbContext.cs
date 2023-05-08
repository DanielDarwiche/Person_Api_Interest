using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Person_Api_Interest.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data Person
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    PersonId = 1,
                    FirstName = "Daniella",
                    LastName = "Khoury",
                    Phone = "07649024234",
                    Age = 4
                });
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    PersonId = 2,
                    FirstName = "Emelie",
                    LastName = "Bojanic",
                    Phone = "0764999934",
                    Age = 33
                });
            modelBuilder.Entity<Person>().
             HasData(new Person
             {
                 PersonId = 3,
                 FirstName = "Jennifer",
                 LastName = "Dara",
                 Phone = "034049024234",
                 Age = 38
             });
            modelBuilder.Entity<Person>().
             HasData(new Person
             {
                 PersonId = 4,
                 FirstName = "Elias",
                 LastName = "Jovanovic",
                 Phone = "033023454234",
                 Age = 42
             });
            modelBuilder.Entity<Person>().
             HasData(new Person
             {
                 PersonId = 5,
                 FirstName = "Daniel",
                 LastName = "Darwiche",
                 Phone = "073535356565",
                 Age = 27
             });
            modelBuilder.Entity<Person>().
             HasData(new Person
             {
                 PersonId = 6,
                 FirstName = "Alvin",
                 LastName = "Andersson",
                 Phone = "07634594994",
                 Age = 29
             });
            modelBuilder.Entity<Person>().
             HasData(new Person
             {
                 PersonId = 7,
                 FirstName = "Damir",
                 LastName = "Slopovic",
                 Phone = "08191233",
                 Age = 49
             });
            modelBuilder.Entity<Person>().
           HasData(new Person
           {
               PersonId = 8,
               FirstName = "Ulf",
               LastName = "Karlsson",
               Phone = "2342343434",
               Age = 99
           });
            // seed data Interest
            modelBuilder.Entity<Interest>().
                HasData(new Interest
                {
                    InterestId = 1,
                    InterestName = "Tennis",
                    InterestDescription = "Tennis is a competitive sport where you hit a ball with a racket"
                });
            modelBuilder.Entity<Interest>().
              HasData(new Interest
              {
                  InterestId = 2,
                  InterestName = "Fotball",
                  InterestDescription = "Fotball is a team sport where you hit a ball, but not with your hand"
              });
            modelBuilder.Entity<Interest>().
              HasData(new Interest
              {
                  InterestId = 3,
                  InterestName = "Boxing",
                  InterestDescription = "Boxing is a competitive sport where you hit a person with a gloved hand"
              });
            modelBuilder.Entity<Interest>().
              HasData(new Interest
              {
                  InterestId = 4,
                  InterestName = "Reading",
                  InterestDescription = "Readig is a calm activity"
              });

            // seed data Link

            modelBuilder.Entity<Link>().
                HasData(new Link
                {
                    LinkId = 1,
                    LinkURL = "https://duckduckgo.com/?q=boxing&t=h_&ia=web"
                });
            modelBuilder.Entity<Link>().
           HasData(new Link
           {
               LinkId = 2,
               LinkURL = "https://duckduckgo.com/?q=boxing&t=h_&iax=images&ia=images"
           });
            modelBuilder.Entity<Link>().
           HasData(new Link
           {
               LinkId = 3,
               LinkURL = "https://duckduckgo.com/?q=tennis&t=h_&ia=web"
           });
            modelBuilder.Entity<Link>().
           HasData(new Link
           {
               LinkId = 4,
               LinkURL = "https://duckduckgo.com/?q=tennis&t=h_&iax=images&ia=images"
           });
            modelBuilder.Entity<Link>().
          HasData(new Link
          {
              LinkId = 5,
              LinkURL = "https://duckduckgo.com/?q=fotball&t=h_&iax=images&ia=images"
          });
            modelBuilder.Entity<Link>().
          HasData(new Link
          {
              LinkId = 6,
              LinkURL = "https://duckduckgo.com/?q=fotball+zlatan&t=h_&iar=images&iax=images&ia=images"
          });
            modelBuilder.Entity<Link>().
           HasData(new Link
           {
               LinkId = 7,
               LinkURL = "https://duckduckgo.com/?q=Reading&t=h_&iax=images&ia=images"
           });


            modelBuilder.Entity<Record>().
                HasData(new Record
                {
                    RecordId = 1,
                    InterestId = 1,
                    PersonId = 1,
                    Linkid = 3,
                });
            modelBuilder.Entity<Record>().
             HasData(new Record
             {
                 RecordId = 2,
                 InterestId = 1,
                 PersonId = 1,
                 Linkid = 4,
             });
            modelBuilder.Entity<Record>().
             HasData(new Record
             {
                 RecordId = 3,
                 InterestId = 1,
                 PersonId = 2,
                 Linkid = 3,
             });
            modelBuilder.Entity<Record>().
             HasData(new Record
             {
                 RecordId = 4,
                 InterestId = 2,
                 PersonId = 3,
                 Linkid = 5,
             });
            modelBuilder.Entity<Record>().
             HasData(new Record
             {
                 RecordId = 5,
                 InterestId = 2,
                 PersonId = 3,
                 Linkid = 6,
             });
            modelBuilder.Entity<Record>().
             HasData(new Record
             {
                 RecordId = 6,
                 InterestId = 3,
                 PersonId = 4,
                 Linkid = 1,
             });
            modelBuilder.Entity<Record>().
             HasData(new Record
             {
                 RecordId = 7,
                 InterestId = 3,
                 PersonId = 4,
                 Linkid = 2,
             });
        }
    }
}