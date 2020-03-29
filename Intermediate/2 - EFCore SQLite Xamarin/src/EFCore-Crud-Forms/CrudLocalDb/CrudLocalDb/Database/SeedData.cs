using CrudLocalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudLocalDb.Database
{
    public class SeedData
    {
        public static IEnumerable<Tag> Tags = new List<Tag>()
        {
            new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Tag1",
                ItemForeignKey = Items.First().Id
            },
            new Tag()
            {
                Id = Guid.NewGuid(),
                Name = "Tag2",
                ItemForeignKey = Items.Last().Id
            }
        };

        public static IEnumerable<Item> Items = new List<Item>()
        {
            new Item()
            {
                Id = Guid.NewGuid(),
                Description = "Description 1",
                Text = "Text 1",
                Tags = Tags.ToList()
            },
            new Item()
            {
                Id = Guid.NewGuid(),
                Description = "Description 2",
                Text = "Text 2",
                Tags = Tags.ToList()
            },
        };
    }
}
