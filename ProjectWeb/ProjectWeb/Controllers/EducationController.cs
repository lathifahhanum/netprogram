using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectWeb.Models;
using ProjectWeb.Repository;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;
        public EducationController(IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }

        // GET: EducationController
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _educationRepository.GetAll();
            return View(entities);
        }

        // GET: EducationController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        // GET: EducationController/Create
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

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            _educationRepository.Insert(education);
            return RedirectToAction("Index");
        }

        // GET: EducationController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var universities = _universityRepository.GetAll();
            var selectListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            ViewBag.UniversityId = selectListUniversities;
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            _educationRepository.Update(education);
            return RedirectToAction("Index");
        }

        // GET: EducationController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        // POST: EducationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _educationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
