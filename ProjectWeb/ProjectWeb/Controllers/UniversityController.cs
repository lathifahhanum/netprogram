using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }


        //get
        [HttpGet]//index ini method utk merender view
        public IActionResult Index()
        {
            var entities = _universityRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var universities = _universityRepository.GetAll();
            var selectListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            ViewBag.UniversityId = selectListUniversities;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(University university)
        {
            _universityRepository.Insert(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(University university)
        {
            _universityRepository.Update(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _universityRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
