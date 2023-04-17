using Microsoft.EntityFrameworkCore;
using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;
using ProjectClientServer.ViewModel;
using System.Collections;

namespace ProjectClientServer.Repositories
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        
        public EmployeeRepository(MyContext context) : base(context)
        {
            
        }

        public IEnumerable<EmployeeVM> GetAllTenure()
        {
            var employees = (IEnumerable<EmployeeVM>)_context.TbMEmployees
                .Join(_context.TbTrProfilings, e => e.Nik, p => p.EmployeeNik,
                (e, p) => new
                {
                    WorkingPeriod = DateTime.Today.Year - e.HiringDate.Year,
                    p.EducationId,
                    p.EmployeeNik,
                    e,
                    p,
                })
                .Join(_context.TbMEducations, ep => ep.p.EducationId, d => d.Id,
                (ep, d) => new EmployeeVM
                {
                    Nik = ep.e.Nik,
                    Name = (ep.e.FirstName + " " + ep.e.LastName),
                    WorkingPeriod = ep.WorkingPeriod,
                    Degree = d.Degree,
                })
                .Where(ep => ep.WorkingPeriod > 5)
               .OrderByDescending(ep => ep.WorkingPeriod);

            return employees;
        }

        public EmployeeVM? GetTenureId(int id)
        {
            return _context.Set<EmployeeVM>().Find(id);
        }

    }
}
