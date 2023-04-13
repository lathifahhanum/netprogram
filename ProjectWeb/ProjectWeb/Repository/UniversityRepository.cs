using ProjectWeb.Contexts;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Repository
{
    public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
    {
        /*private readonly MyContext _context;
        public UniversityRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<University> GetAll()
        {
            return _context.Set<University>().ToList();
        }

        public University? GetById(int id)
        {
            return _context.Set<University>().Find(id);
        }

        public IEnumerable<University> Search(string name)
        {
            return GetAll().Where(u => u.Name.Contains(name));
        }

        public int Insert(University university)
        {
            _context.Set<University>().Add(university);
            return _context.SaveChanges() ;
        }

        public int Update(University university)
        {
            _context.Set<University>().Update(university);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            
            if(entity == null)
            {
                return 0;
            }

            _context.Set<University>().Remove(entity);
            return _context.SaveChanges();
        }*/
        public UniversityRepository(MyContext context) : base(context)
        {
        }
    }
}
