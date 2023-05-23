using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
