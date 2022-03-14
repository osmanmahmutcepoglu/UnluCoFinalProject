using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UnluCoFinalProject.Service.Features.UtilityFeatures.Queries;

namespace UnluCoFinalProject.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/Utility")]
    public class UtilityController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("issold/{id}")]
        public async Task<IActionResult> GetIsSoldById(int id)
        {
            return Ok(await Mediator.Send(new GetIsSoldByIdQuery { Id = id }));
        }

        [HttpGet("issold")]
        public async Task<IActionResult> GetIsSoldAll()
        {
            return Ok(await Mediator.Send(new GetAllIsSoldQuery()));
        }

        [HttpGet("color/{id}")]
        public async Task<IActionResult> GetColorById(int id)
        {
            return Ok(await Mediator.Send(new GetColorByIdQuery { Id = id }));
        }

        [HttpGet("color")]
        public async Task<IActionResult> GetColorAll()
        {
            return Ok(await Mediator.Send(new GetAllColorQuery()));
        }

        [HttpGet("brand/{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            return Ok(await Mediator.Send(new GetBrandByIdQuery { Id = id }));
        }

        [HttpGet("brand")]
        public async Task<IActionResult> GetBrandAll()
        {
            return Ok(await Mediator.Send(new GetAllBrandQuery()));
        }

    }
}
