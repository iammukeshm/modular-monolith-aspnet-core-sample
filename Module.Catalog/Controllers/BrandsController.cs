using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Commands.Register;
using Module.Catalog.Core.Queries.GetAll;
using System.Threading.Tasks;

namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterBrandCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}