using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace RentACarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorController : ControllerBase
    {
        private IMediator _mediator;

        //TODO: Watch documentation
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}