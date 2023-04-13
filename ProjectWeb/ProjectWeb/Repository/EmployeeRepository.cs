using ProjectWeb.Contexts;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Repository
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        /*private readonly MyContext _context;
        public EmployeeRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().ToList();
        }

        public Employee? GetById(string id)
        {
            return _context.Set<Employee>().Find(id);
        }

        public int Insert(Employee employee)
        {
            _context.Set<Employee>().Add(employee);
            return _context.SaveChanges();
        }

        public IEnumerable<Employee> Search(string name)
        {
            return GetAll().Where(x => x.FirstName.Contains(name));
        }

        public int Update(Employee employee)
        {
            _context.Set<Employee>().Update(employee);
            return _context.SaveChanges();
        }

        public int Delete(string id)
        {
            var entity = GetById(id);
            _context.Set<Employee>().Remove(entity);
            return _context.SaveChanges();
        }*/
        public EmployeeRepository(MyContext context) : base(context)
        {
        }
    }
}
