using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        public ActionResult<T> Single<T>(T model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return model;
        }        
    }
}