using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class EducationController : Controller
    {
        private readonly ILogger<EducationController> _logger;

        public EducationController(ILogger<EducationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
