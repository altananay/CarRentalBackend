using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : ControllerBase
    {
        IFakeCreditCardService _fakeCreditCardService;

        public FakePaymentController(IFakeCreditCardService fakeCreditCardService)
        {
            _fakeCreditCardService = fakeCreditCardService;
        }

        [HttpPost("getall")]
        public IActionResult GetAll(FakeCreditCard fakeCreditCard)
        {
            var result = _fakeCreditCardService.GetAll(fakeCreditCard);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
