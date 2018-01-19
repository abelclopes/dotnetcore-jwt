using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Authentication;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api")]
    public class LoginController : Controller
    {
        // GET api/service
        [HttpGet]
        [Route("service")]
        [Authorize]
        public string Get()
        {
            return "Congratulations, you were authorized to use this service.";
        }

        [HttpGet]
        public JsonResult  Post(string username, string password)
        {
            var context = Request.HttpContext;
            var Token =  TokenProviderMiddleware.Invoke(context: context);

            return Json(Token);
        }
    }
}