using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Commands.Register
{
    public class RegisterBrandCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }
    internal class BrandCommandHandler : IRequestHandler<RegisterBrandCommand, int>
    {
        private readonly ICatalogDbContext _context;
        public BrandCommandHandler(ICatalogDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(RegisterBrandCommand command, CancellationToken cancellationToken)
        {
            if (await _context.Brands.AnyAsync(c => c.Name == command.Name, cancellationToken))
            {
                throw new Exception("Brand with the same name already exists.");
            }
            var brand = new Brand { Detail = command.Detail, Name = command.Name };
            await _context.Brands.AddAsync(brand, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return brand.Id;
        }
    }
}
