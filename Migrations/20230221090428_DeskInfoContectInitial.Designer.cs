﻿// <auto-generated />
using ConsoleTest.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleTest.Migrations
{
    [DbContext(typeof(DeskInfoContext))]
    [Migration("20230221090428_DeskInfoContectInitial")]
    partial class DeskInfoContectInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.14");

            modelBuilder.Entity("ConsoleTest.Entities.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("deskID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("deskID");

                    b.ToTable("bookingStatus");
                });

            modelBuilder.Entity("ConsoleTest.Entities.Desk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeskNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("desk");
                });

            modelBuilder.Entity("ConsoleTest.Entities.BookingStatus", b =>
                {
                    b.HasOne("ConsoleTest.Entities.Desk", "desk")
                        .WithMany("BookingStatus")
                        .HasForeignKey("deskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("desk");
                });

            modelBuilder.Entity("ConsoleTest.Entities.Desk", b =>
                {
                    b.Navigation("BookingStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
