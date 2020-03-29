using CrudLocalDb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudLocalDb.Database
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public async Task<IEnumerable<Item>> GetAllWithTags()
        {
            var withTags = await DbSet.Include(x => x.Tags).ToListAsync();
            return withTags;
        }
    }
}