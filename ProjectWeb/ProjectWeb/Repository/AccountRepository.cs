using ProjectWeb.Contexts;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;
using ProjectWeb.ViewModels;

namespace ProjectWeb.Repository
{
    public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
    {

        public AccountRepository(MyContext context) : base(context)
        {
        }

        public RegisterVM? Register(RegisterVM registerVM) 
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                
                var university = new University
                {
                    Name = registerVM.UniversityName,
                };
                if (_context.Universities.Any(u => u.Name == university.Name)) {
                    university.Id = _context.Universities
                        .FirstOrDefault(u => u.Name == university.Name)!
                        .Id;
                }
                else
                {
                    _context.Universities.Add(university);
                    _context.SaveChanges();
                }
                

                var education = new Education
                {
                    Major = registerVM.Major,
                    Degree = registerVM.Degree,
                    Gpa = registerVM.Gpa,
                    UniversityId = university.Id,
                };
                _context.Educations.Add(education);
                _context.SaveChanges();

                var employee = new Employee
                {
                    Nik = registerVM.Nik,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    BirthDate = registerVM.BirthDate,
                    Gender = registerVM.Gender,
                    PhoneNumber = registerVM.PhoneNumber,
                    Email = registerVM.Email,
                    HiringDate = DateTime.Now,
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                var account = new Account
                {
                    EmployeeNik = registerVM.Nik,
                    Password = registerVM.Password,
                };
                _context.Accounts.Add(account);
                _context.SaveChanges();

                var profiling = new Profiling
                {
                    EmployeeNik = registerVM.Nik,
                    EducationId = education.Id,
                };
                _context.Profilings.Add(profiling);
                _context.SaveChanges();

                transaction.Commit();
            } catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            return registerVM;
        }

        public bool Login(LoginVM loginVM)
        {
            
            var login = (from e in _context.Employees
                        join a in _context.Accounts
                        on e.Nik equals a.EmployeeNik
                        select new
                        {
                            Email = e.Email,
                            Password = a.Password,
                        }).FirstOrDefault(e => e.Email == loginVM.Email && e.Password == loginVM.Password);
            return true;
            
        }
    }
}
