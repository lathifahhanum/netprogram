using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using ProjectWeb.Repository;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        // GET: RoleController
        [HttpGet]
        public ActionResult Index()
        {
            var entities = _roleRepository.GetAll();
            return View(entities);
        }

        // GET: RoleController/Details/5
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        // GET: RoleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            _roleRepository.Insert(role);
            return RedirectToAction("Index");
        }

        // GET: RoleController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            _roleRepository.Update(role);
            return RedirectToAction("Index");
        }

        // GET: RoleController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            _roleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
