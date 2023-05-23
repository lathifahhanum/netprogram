using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ProfilingController : Controller
    {
        private readonly ILogger<ProfilingController> _logger;

        public ProfilingController(ILogger<ProfilingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
