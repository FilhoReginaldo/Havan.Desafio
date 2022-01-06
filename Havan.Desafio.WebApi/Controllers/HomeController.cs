using Microsoft.AspNetCore.Mvc;

namespace Havan.Desafio.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => new RedirectResult("~/help");


    }
}