using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AccountRoleController : Controller
    {
        private readonly ILogger<AccountRoleController> _logger;

        public AccountRoleController(ILogger<AccountRoleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
