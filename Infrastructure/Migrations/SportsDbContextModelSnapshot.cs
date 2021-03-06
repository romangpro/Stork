﻿// <auto-generated />
using System;
using Infrastructure.Sports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SportsDbContext))]
    partial class SportsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Infrastructure.Sports.ConferenceDao", b =>
                {
                    b.Property<uint>("ConferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbr")
                        .HasColumnType("TEXT");

                    b.Property<uint>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ConferenceId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Conference");
                });

            modelBuilder.Entity("Infrastructure.Sports.DivisionDao", b =>
                {
                    b.Property<uint>("DivisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbr")
                        .HasColumnType("TEXT");

                    b.Property<uint>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("DivisionId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("Infrastructure.Sports.LeagueDao", b =>
                {
                    b.Property<uint>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbr")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("LeagueId");

                    b.ToTable("League");
                });

            modelBuilder.Entity("Infrastructure.Sports.SeasonDao", b =>
                {
                    b.Property<uint>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT");

                    b.Property<uint>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("SeasonId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("Infrastructure.Sports.TeamDao", b =>
                {
                    b.Property<uint>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbr")
                        .HasColumnType("TEXT");

                    b.Property<uint>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Infrastructure.Sports.TeamMapDao", b =>
                {
                    b.Property<uint>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ConferenceId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("DivisionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeasonId", "TeamId");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMap");
                });

            modelBuilder.Entity("Infrastructure.Sports.ConferenceDao", b =>
                {
                    b.HasOne("Infrastructure.Sports.LeagueDao", "League")
                        .WithMany("Conferences")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Sports.DivisionDao", b =>
                {
                    b.HasOne("Infrastructure.Sports.LeagueDao", "League")
                        .WithMany("Divisions")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Sports.SeasonDao", b =>
                {
                    b.HasOne("Infrastructure.Sports.LeagueDao", "League")
                        .WithMany("Seasons")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Sports.TeamDao", b =>
                {
                    b.HasOne("Infrastructure.Sports.LeagueDao", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Sports.TeamMapDao", b =>
                {
                    b.HasOne("Infrastructure.Sports.ConferenceDao", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Sports.DivisionDao", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Sports.SeasonDao", "Season")
                        .WithMany("TeamMaps")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Sports.TeamDao", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
