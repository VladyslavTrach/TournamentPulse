﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentPulse.Infrastructure.Data;

#nullable disable

namespace TournamentPulse.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231011144626_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TournamentPulse.Core.Entities.Academy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssociationId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociationId");

                    b.HasIndex("CountryId");

                    b.ToTable("Academies");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.AgeClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgeClasses");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Association", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgeClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankClassId")
                        .HasColumnType("int");

                    b.Property<int>("WeightClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgeClassId");

                    b.HasIndex("RankClassId");

                    b.HasIndex("WeightClassId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Fighter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademyId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AgeClassId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankClassId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<int>("WeightClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcademyId");

                    b.HasIndex("AgeClassId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RankClassId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeightClassId");

                    b.ToTable("Fighters");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.FighterCategoryTournament", b =>
                {
                    b.Property<int>("FighterId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("FighterId", "CategoryId", "TournamentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TournamentId");

                    b.ToTable("FighterCategoryTournaments");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.RankClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RankClasses");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreditCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.WeightClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.Property<int>("MinWeight")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeightClasses");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Academy", b =>
                {
                    b.HasOne("TournamentPulse.Core.Entities.Association", "Association")
                        .WithMany("Academies")
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.Country", "Country")
                        .WithMany("Academies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Association");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Category", b =>
                {
                    b.HasOne("TournamentPulse.Core.Entities.AgeClass", "AgeClass")
                        .WithMany()
                        .HasForeignKey("AgeClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.RankClass", "RankClass")
                        .WithMany()
                        .HasForeignKey("RankClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.WeightClass", "WeightClass")
                        .WithMany()
                        .HasForeignKey("WeightClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AgeClass");

                    b.Navigation("RankClass");

                    b.Navigation("WeightClass");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Fighter", b =>
                {
                    b.HasOne("TournamentPulse.Core.Entities.Academy", "Academy")
                        .WithMany("Fighters")
                        .HasForeignKey("AcademyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.AgeClass", "AgeClass")
                        .WithMany("Fighters")
                        .HasForeignKey("AgeClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.RankClass", "RankClass")
                        .WithMany("Fighters")
                        .HasForeignKey("RankClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.Tournament", "Tournament")
                        .WithMany("Fighters")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.User", "User")
                        .WithMany("Fighters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.WeightClass", "WeightClass")
                        .WithMany("Fighters")
                        .HasForeignKey("WeightClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Academy");

                    b.Navigation("AgeClass");

                    b.Navigation("Category");

                    b.Navigation("RankClass");

                    b.Navigation("Tournament");

                    b.Navigation("User");

                    b.Navigation("WeightClass");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.FighterCategoryTournament", b =>
                {
                    b.HasOne("TournamentPulse.Core.Entities.Category", "Category")
                        .WithMany("FighterCategoryTournaments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.Fighter", "Fighter")
                        .WithMany("FighterCategoryTournaments")
                        .HasForeignKey("FighterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TournamentPulse.Core.Entities.Tournament", "Tournament")
                        .WithMany("FighterCategoryTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Fighter");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Academy", b =>
                {
                    b.Navigation("Fighters");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.AgeClass", b =>
                {
                    b.Navigation("Fighters");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Association", b =>
                {
                    b.Navigation("Academies");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Category", b =>
                {
                    b.Navigation("FighterCategoryTournaments");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Country", b =>
                {
                    b.Navigation("Academies");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Fighter", b =>
                {
                    b.Navigation("FighterCategoryTournaments");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.RankClass", b =>
                {
                    b.Navigation("Fighters");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.Tournament", b =>
                {
                    b.Navigation("FighterCategoryTournaments");

                    b.Navigation("Fighters");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.User", b =>
                {
                    b.Navigation("Fighters");
                });

            modelBuilder.Entity("TournamentPulse.Core.Entities.WeightClass", b =>
                {
                    b.Navigation("Fighters");
                });
#pragma warning restore 612, 618
        }
    }
}
