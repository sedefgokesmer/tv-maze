﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TVMazeScraper.Data;

#nullable disable

namespace TVMazeScraper.Migrations
{
    [DbContext(typeof(TVMazeContext))]
    partial class TVMazeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("TVMazeScraper.Models.CastInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Showid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("personid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Showid");

                    b.HasIndex("personid");

                    b.ToTable("CastInfo");
                });

            modelBuilder.Entity("TVMazeScraper.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("TVMazeScraper.Models.Show", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("TVMazeScraper.Models.CastInfo", b =>
                {
                    b.HasOne("TVMazeScraper.Models.Show", null)
                        .WithMany("Cast")
                        .HasForeignKey("Showid");

                    b.HasOne("TVMazeScraper.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("personid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("TVMazeScraper.Models.Show", b =>
                {
                    b.Navigation("Cast");
                });
#pragma warning restore 612, 618
        }
    }
}