using System;
using System.Collections.Generic;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Backpack> Backpacks { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterTitle> CharacterTitles { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Backpack>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.CharacterId }).HasName("backpacks_pk");

            entity.ToTable("backpacks");

            entity.HasOne(d => d.Character).WithMany(p => p.Backpacks)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("backpacks_characters");

            entity.HasOne(d => d.Item).WithMany(p => p.Backpacks)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("backpacks_items");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("characters_pk");

            entity.ToTable("characters");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(120);
        });

        modelBuilder.Entity<CharacterTitle>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.TitleId }).HasName("character_titles_pk");

            entity.ToTable("character_titles");

            entity.Property(e => e.AcquiredAt).HasColumnType("datetime");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterTitles)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_titles_characters");

            entity.HasOne(d => d.Title).WithMany(p => p.CharacterTitles)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_titles_titles");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("items_pk");

            entity.ToTable("items");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("titles_pk");

            entity.ToTable("titles");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack()
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 1
            }
        });
        
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item()
            {
                Id = 1,
                Name = "Sword",
                Weight = 10
            }
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                CurrentWeight = 50,
                MaxWeight = 100
            }
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = new DateTime(2024-01-01)
            }
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title()
            {
                Id = 1,
                Name = "Knight"
            }
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
