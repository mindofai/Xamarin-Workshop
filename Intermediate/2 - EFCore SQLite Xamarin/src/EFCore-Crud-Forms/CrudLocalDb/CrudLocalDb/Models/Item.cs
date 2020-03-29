using CrudLocalDb.Database;
using System;
using System.Collections.Generic;

namespace CrudLocalDb.Models
{
    public class Item : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}