using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFDbContext _context;

        public ProductRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Product> Products
        {
            get { return _context.Products; }
        }
    }
}
