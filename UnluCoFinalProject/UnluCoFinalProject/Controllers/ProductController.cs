using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UnluCoFinalProject.Service.Features.ProductFeatures.Commands;
using UnluCoFinalProject.Service.Features.ProductFeatures.Queries;

namespace UnluCoFinalProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            return Ok(await Mediator.Send(new GetCategoryFilterByIdQuery { CategoryId = categoryId }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("issold")]
        public async Task<IActionResult> IsSold([FromForm] int id, [FromForm] string isSold)
        {

            var result = await Mediator.Send(new ProductsIsSoldQuery { IsSold = isSold, ProductId = id });
            if (result.Succeeded == false)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }


    }
}
