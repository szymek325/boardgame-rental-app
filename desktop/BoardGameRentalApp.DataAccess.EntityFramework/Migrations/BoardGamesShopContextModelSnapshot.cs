﻿// <auto-generated />
using System;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoardGameRentalApp.DataAccess.EntityFramework.Migrations
{
    [DbContext(typeof(BoardGamesShopContext))]
    partial class BoardGamesShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("gr")
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 3, 31, 17, 59, 39, 112, DateTimeKind.Utc).AddTicks(7976));

                    b.Property<string>("Name");

                    b.Property<float>("PricePerDay");

                    b.Property<float>("SuggestedDeposit");

                    b.HasKey("Id");

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactNumber");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 3, 31, 17, 59, 39, 116, DateTimeKind.Utc).AddTicks(2455));

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.GameRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardGameId");

                    b.Property<float>("ChargedDeposit");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 3, 31, 17, 59, 39, 116, DateTimeKind.Utc).AddTicks(2630));

                    b.Property<float>("PaymentAmount");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("ClientId");

                    b.ToTable("GameRentals");
                });

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.GameRental", b =>
                {
                    b.HasOne("BoardGameRentalApp.Core.Entities.BoardGame", "BoardGame")
                        .WithMany("GameRentals")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoardGameRentalApp.Core.Entities.Client", "Client")
                        .WithMany("GameRentals")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
