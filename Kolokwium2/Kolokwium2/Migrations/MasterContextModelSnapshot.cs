﻿// <auto-generated />
using System;
using Kolokwium2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(MasterContext))]
    partial class MasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2.Models.Backpack", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "CharacterId")
                        .HasName("backpacks_pk");

                    b.HasIndex("CharacterId");

                    b.ToTable("backpacks", (string)null);

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CharacterId = 1,
                            Amount = 1
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("characters_pk");

                    b.ToTable("characters", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 50,
                            FirstName = "John",
                            LastName = "Doe",
                            MaxWeight = 100
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.CharacterTitle", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime");

                    b.HasKey("CharacterId", "TitleId")
                        .HasName("character_titles_pk");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles", (string)null);

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("items_pk");

                    b.ToTable("items", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sword",
                            Weight = 10
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("titles_pk");

                    b.ToTable("titles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Knight"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Backpack", b =>
                {
                    b.HasOne("Kolokwium2.Models.Character", "Character")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .IsRequired()
                        .HasConstraintName("backpacks_characters");

                    b.HasOne("Kolokwium2.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("backpacks_items");

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Kolokwium2.Models.CharacterTitle", b =>
                {
                    b.HasOne("Kolokwium2.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .IsRequired()
                        .HasConstraintName("character_titles_characters");

                    b.HasOne("Kolokwium2.Models.Title", "Title")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .IsRequired()
                        .HasConstraintName("character_titles_titles");

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Kolokwium2.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("Kolokwium2.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("Kolokwium2.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
