using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UniversityController : Controller
    {
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(ILogger<UniversityController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
