﻿using Microsoft.AspNetCore.Mvc;

namespace ProjectClientServer.Controllers
{
    public class UniversityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
