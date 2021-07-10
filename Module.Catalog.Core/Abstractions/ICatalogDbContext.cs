using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Abstractions
{
    public interface ICatalogDbContext
    {
        public DbSet<Brand> Brands { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}