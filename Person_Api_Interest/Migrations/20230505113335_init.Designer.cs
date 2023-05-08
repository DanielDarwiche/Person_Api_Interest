﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Person_Api_Interest.Models;

#nullable disable

namespace Person_Api_Interest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230505113335_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Person_Api_Interest.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("InterestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            InterestDescription = "Tennis is a competitive sport where you hit a ball with a racket",
                            InterestName = "Tennis"
                        },
                        new
                        {
                            InterestId = 2,
                            InterestDescription = "Fotball is a team sport where you hit a ball, but not with your hand",
                            InterestName = "Fotball"
                        },
                        new
                        {
                            InterestId = 3,
                            InterestDescription = "Boxing is a competitive sport where you hit a person with a gloved hand",
                            InterestName = "Boxing"
                        },
                        new
                        {
                            InterestId = 4,
                            InterestDescription = "Readig is a calm activity",
                            InterestName = "Reading"
                        });
                });

            modelBuilder.Entity("Person_Api_Interest.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<string>("LinkURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            LinkId = 1,
                            LinkURL = "https://duckduckgo.com/?q=boxing&t=h_&ia=web"
                        },
                        new
                        {
                            LinkId = 2,
                            LinkURL = "https://duckduckgo.com/?q=boxing&t=h_&iax=images&ia=images"
                        },
                        new
                        {
                            LinkId = 3,
                            LinkURL = "https://duckduckgo.com/?q=tennis&t=h_&ia=web"
                        },
                        new
                        {
                            LinkId = 4,
                            LinkURL = "https://duckduckgo.com/?q=tennis&t=h_&iax=images&ia=images"
                        },
                        new
                        {
                            LinkId = 5,
                            LinkURL = "https://duckduckgo.com/?q=fotball&t=h_&iax=images&ia=images"
                        },
                        new
                        {
                            LinkId = 6,
                            LinkURL = "https://duckduckgo.com/?q=fotball+zlatan&t=h_&iar=images&iax=images&ia=images"
                        },
                        new
                        {
                            LinkId = 7,
                            LinkURL = "https://duckduckgo.com/?q=Reading&t=h_&iax=images&ia=images"
                        });
                });

            modelBuilder.Entity("Person_Api_Interest.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Age = 4,
                            FirstName = "Daniella",
                            LastName = "Khoury",
                            Phone = "07649024234"
                        },
                        new
                        {
                            PersonId = 2,
                            Age = 33,
                            FirstName = "Emelie",
                            LastName = "Bojanic",
                            Phone = "0764999934"
                        },
                        new
                        {
                            PersonId = 3,
                            Age = 38,
                            FirstName = "Jennifer",
                            LastName = "Dara",
                            Phone = "034049024234"
                        },
                        new
                        {
                            PersonId = 4,
                            Age = 42,
                            FirstName = "Elias",
                            LastName = "Jovanovic",
                            Phone = "033023454234"
                        },
                        new
                        {
                            PersonId = 5,
                            Age = 27,
                            FirstName = "Daniel",
                            LastName = "Darwiche",
                            Phone = "073535356565"
                        },
                        new
                        {
                            PersonId = 6,
                            Age = 29,
                            FirstName = "Alvin",
                            LastName = "Andersson",
                            Phone = "07634594994"
                        },
                        new
                        {
                            PersonId = 7,
                            Age = 49,
                            FirstName = "Damir",
                            LastName = "Slopovic",
                            Phone = "08191233"
                        },
                        new
                        {
                            PersonId = 8,
                            Age = 99,
                            FirstName = "Ulf",
                            LastName = "Karlsson",
                            Phone = "2342343434"
                        });
                });

            modelBuilder.Entity("Person_Api_Interest.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"));

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int?>("Linkid")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            RecordId = 1,
                            InterestId = 1,
                            Linkid = 3,
                            PersonId = 1
                        },
                        new
                        {
                            RecordId = 2,
                            InterestId = 1,
                            Linkid = 4,
                            PersonId = 1
                        },
                        new
                        {
                            RecordId = 3,
                            InterestId = 1,
                            Linkid = 3,
                            PersonId = 2
                        },
                        new
                        {
                            RecordId = 4,
                            InterestId = 2,
                            Linkid = 5,
                            PersonId = 3
                        },
                        new
                        {
                            RecordId = 5,
                            InterestId = 2,
                            Linkid = 6,
                            PersonId = 3
                        },
                        new
                        {
                            RecordId = 6,
                            InterestId = 3,
                            Linkid = 1,
                            PersonId = 4
                        },
                        new
                        {
                            RecordId = 7,
                            InterestId = 3,
                            Linkid = 2,
                            PersonId = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}