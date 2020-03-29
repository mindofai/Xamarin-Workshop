using CrudLocalDb.Database;
using System;

namespace CrudLocalDb.Models
{
    public class Tag : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ItemForeignKey { get; set; }
        public Item Item { get; set; }
    }
}
