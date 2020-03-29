using CrudLocalDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CrudLocalDb.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tags config

            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Tag>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Tag>()
                .HasOne(x => x.Item)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.ItemForeignKey); 

            #endregion

            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = "itemdb.db";
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlite($"Filename={databasePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}