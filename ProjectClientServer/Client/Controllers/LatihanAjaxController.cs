using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class LatihanAjaxController : Controller
    {
        private readonly ILogger<LatihanAjaxController> _logger;

        public LatihanAjaxController(ILogger<LatihanAjaxController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
