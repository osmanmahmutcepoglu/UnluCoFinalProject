using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UnluCoFinalProject.Service.Features.CategoryFeatures.Commands;
using UnluCoFinalProject.Service.Features.CategoryFeatures.Queries;

namespace UnluCoFinalProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCategoryQuery()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
