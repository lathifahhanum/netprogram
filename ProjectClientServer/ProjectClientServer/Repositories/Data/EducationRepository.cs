using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories
{
    public class EducationRepository : GeneralRepository<Education, int, MyContext>
    {
        /*private readonly MyContext _context;
        public EducationRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Education> GetAll()
        {
            return _context.Set<Education>().ToList();
        }

        public Education? GetById(int id)
        {
            return _context.Set<Education>().Find(id);
            
        }

        public int Insert(Education education)
        {
            _context.Set<Education>().Add(education);
            return _context.SaveChanges();
        }

        public IEnumerable<Education> Search(string major)
        {
            return GetAll().Where(x => x.Major.Contains(major));
        }

        public int Update(Education education)
        {
            _context.Set<Education>().Update(education);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<Education>().Remove(entity);
            return _context.SaveChanges();
        }*/
        public EducationRepository(MyContext context) : base(context)
        {
        }
    }
}
