using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;

        public AdminController(ILogger<AdminController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
