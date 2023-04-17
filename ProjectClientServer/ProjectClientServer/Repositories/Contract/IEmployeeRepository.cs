using ProjectClientServer.Models;
using ProjectClientServer.ViewModel;
using System.Collections;
using System.Collections.Generic;

namespace ProjectClientServer.Repositories.Contract
{
    public interface IEmployeeRepository:IGeneralRepository<Employee, string>
    {
        IEnumerable<EmployeeVM> GetAllTenure();
        EmployeeVM? GetTenureId(int id);
    }
}
