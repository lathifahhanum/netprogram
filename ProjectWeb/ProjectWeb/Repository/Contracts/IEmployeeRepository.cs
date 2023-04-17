using ProjectWeb.Models;

namespace ProjectWeb.Repository.Contracts
{
    public interface IEmployeeRepository:IGeneralRepository<Employee, string>
    {
        string GetFullName(string email);
        /*IEnumerable<Employee> GetAll();
        Employee? GetById(string id);
        IEnumerable<Employee> Search(string name);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(string id);*/
    }
}
