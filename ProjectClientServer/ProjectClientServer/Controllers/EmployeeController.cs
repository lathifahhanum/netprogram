using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol.Core.Types;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories;
using ProjectClientServer.Repositories.Contract;
using ProjectClientServer.ViewModel;
using System.Collections;

namespace ProjectClientServer.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("/Employee")]
    public class EmployeeController : GeneralController<Employee,IEmployeeRepository, string>
    {
        private readonly IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository _repository) : base(_repository)
        {
            repository = _repository;
        }

        
        /*[HttpGet]
        public IEnumerable<EmployeeVM> GetTenure()
        {
            return _employeeRepository.GetAllTenure();
        }*/

        // GET
        [HttpGet("GetTenure")]
        public IActionResult GetTenure()
        {
            var entity = repository.GetAllTenure();
            return View(entity);
        }

        /*[HttpGet("DetailsTenure")]
        public ActionResult<EmployeeVM> DetailsTenure(int id)
        {
            var entity = _employeeRepository.GetTenureId(id);
            return View(entity);
        }*/


    }
}