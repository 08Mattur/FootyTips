﻿// <auto-generated />
using System;
using FootyTips.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootyTips.Migrations
{
    [DbContext(typeof(FootyTipsContext))]
    partial class FootyTipsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("FootyTips.Data.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KickOff")
                        .HasColumnType("TEXT");

                    b.Property<int>("RefereeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RefereeId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Referee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeGround")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FootyTips.Data.Models.TeamMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Corners")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fouls")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Goals")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHome")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RedCards")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Shots")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShotsOnTarget")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YellowCards")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMatches");
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.Property<int>("SeasonsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeasonsId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("SeasonTeam");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Match", b =>
                {
                    b.HasOne("FootyTips.Data.Models.Referee", "Referee")
                        .WithMany("MatchesOfficiated")
                        .HasForeignKey("RefereeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Referee");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Season", b =>
                {
                    b.HasOne("FootyTips.Data.Models.Competition", "Competition")
                        .WithMany("Seasons")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("FootyTips.Data.Models.TeamMatch", b =>
                {
                    b.HasOne("FootyTips.Data.Models.Match", "Match")
                        .WithMany("Teams")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootyTips.Data.Models.Team", "Team")
                        .WithMany("Matches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.HasOne("FootyTips.Data.Models.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootyTips.Data.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootyTips.Data.Models.Competition", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Match", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Referee", b =>
                {
                    b.Navigation("MatchesOfficiated");
                });

            modelBuilder.Entity("FootyTips.Data.Models.Team", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
