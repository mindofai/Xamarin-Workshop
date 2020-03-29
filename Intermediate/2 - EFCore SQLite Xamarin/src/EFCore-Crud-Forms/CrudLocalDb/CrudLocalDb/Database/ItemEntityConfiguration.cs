using CrudLocalDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CrudLocalDb.Database
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder
                .HasKey(x => x.Id)
                .HasName("ItemId");

            builder.Property(x => x.Id)
                .HasDefaultValue(Guid.NewGuid());

            builder
                .Property(x => x.Text)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(x => x.Tags)
                .WithOne(x => x.Item);

            //builder.HasData(SeedData.Items);
        }
    }
}