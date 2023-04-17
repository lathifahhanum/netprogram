using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectWeb.Repository.Contracts;
using ProjectWeb.ViewModels;

namespace ProjectWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AccountController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var gender = new List<SelectListItem>() {
                new SelectListItem
                {
                    Text = "Male",
                    Value = "0",
                },
                new SelectListItem
                {
                    Text = "Female",
                    Value = "1",
                }
            };
            ViewBag.Gender = gender;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            var result = _accountRepository.Register(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login() { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            var result = _accountRepository.Login(loginVM);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Email or password is incorrect");
                return View();
            }

            var sessionFullName = _employeeRepository.GetFullName(loginVM.Email);
            HttpContext.Session.SetString("FullName", sessionFullName);

            return RedirectToAction("Index", "Home");
        }

    }
}
