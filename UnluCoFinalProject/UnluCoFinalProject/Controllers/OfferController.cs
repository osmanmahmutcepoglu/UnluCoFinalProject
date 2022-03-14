using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Threading.Tasks;
using UnluCoFinalProject.Service.Features.OfferFeatures.Commands;
using UnluCoFinalProject.Service.Features.OfferFeatures.Queries;

namespace UnluCoFinalProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Offer")]
    public class OfferController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] int productId, [FromForm] int offerPrice)
        {
            var userId = User.FindFirstValue("uid");
            var result = await Mediator.Send(new CreateOfferCommand { UserId = userId, ProductId = productId, OfferPrice = offerPrice });
            if (result.Succeeded == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("rate")]
        public async Task<IActionResult> CreateRate([FromForm] int productId, [FromForm] int offerRate)
        {
            var userId = User.FindFirstValue("uid");
            var result = await Mediator.Send(new CreateOfferRateCommand { UserId = userId, ProductId = productId, OfferRate = offerRate });
            if (result.Succeeded == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("offerisaccept")]
        public async Task<IActionResult> CreateRate([FromForm] bool val, [FromForm] int offerId)
        {
            var result = await Mediator.Send(new GetAllMyProductsOffersAcceptQuery { IsAccept = val, OfferId = offerId });
            if (result.Succeeded == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteOfferByIdCommand { Id = id }));
        }

        [HttpGet]
        [Route("MyOffers")]
        public async Task<IActionResult> GetAllMyOffers()
        {
            var userId = User.FindFirstValue("uid");
            return Ok(await Mediator.Send(new GetAllMyOffersQuery { UserId = userId }));
        }

        [HttpGet]
        [Route("MyProductsOffers")]
        public async Task<IActionResult> GetAllMyProductsOffers()
        {
            var userId = User.FindFirstValue("uid");
            return Ok(await Mediator.Send(new GetAllMyProductsOffersQuery { UserId = userId }));
        }

        [HttpPut]
        [Route("OfferIsAccept")]
        public async Task<IActionResult> OfferIsAccept([FromForm] int offerId, [FromForm] bool isAccept)
        {
            var result = await Mediator.Send(new GetAllMyProductsOffersAcceptQuery { OfferId = offerId, IsAccept = isAccept });
            if (result.Succeeded == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
