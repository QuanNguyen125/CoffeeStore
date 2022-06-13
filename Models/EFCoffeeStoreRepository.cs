using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeStore.Models
{
    public class EFCoffeeStoreRepository : ICoffeeStoreRepository
    {
        private CoffeeStoreDbContext context;
        public EFCoffeeStoreRepository(CoffeeStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Coffee> Coffees => context.Coffees;
    }
}
