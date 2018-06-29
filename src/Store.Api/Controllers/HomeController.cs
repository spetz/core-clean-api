using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Content("Store API.");
    }
}