﻿// <auto-generated />
using System;
using Iowa.SqlServer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Iowa.SqlServer.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Iowa.Domain.Account.AccountAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("PreviousBalance")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("Iowa.Domain.Evaluation.EvaluationAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EvaluationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Evaluations", (string)null);
                });

            modelBuilder.Entity("Iowa.Domain.GameAggregate.GameAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("Iowa.Domain.UserAggregate.UserAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Iowa.Domain.GameAggregate.GameAggregate", b =>
                {
                    b.OwnsMany("Iowa.Domain.GameAggregate.Entities.Round", "Rounds", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("GameId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<long>("PreviousBalance")
                                .HasColumnType("bigint");

                            b1.Property<short>("RoundNumber")
                                .HasColumnType("smallint");

                            b1.Property<long>("Total")
                                .HasColumnType("bigint");

                            b1.HasKey("Id", "GameId");

                            b1.HasIndex("GameId");

                            b1.ToTable("Rounds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GameId");
                        });

                    b.OwnsMany("Iowa.Domain.GameAggregate.ValueObjects.Card", "Cards", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("GameId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<short>("PunishmentPercentChance")
                                .HasColumnType("smallint");

                            b1.Property<long>("PunishmentValue")
                                .HasColumnType("bigint");

                            b1.Property<long>("RewardValue")
                                .HasColumnType("bigint");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("nvarchar(256)");

                            b1.HasKey("Id");

                            b1.HasIndex("GameId");

                            b1.ToTable("Cards", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GameId");
                        });

                    b.Navigation("Cards");

                    b.Navigation("Rounds");
                });
#pragma warning restore 612, 618
        }
    }
}
