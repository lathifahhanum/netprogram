using ProjectWeb.Contexts;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Repository
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        /*private readonly MyContext _context;
        public ProfilingRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Profiling> GetAll()
        {
            return _context.Set<Profiling>().ToList();
        }

        public Profiling? GetById(string nik)
        {
            return _context.Set<Profiling>().Find(nik);
        }

        public int Insert(Profiling profiling)
        {
            _context.Set<Profiling>().Add(profiling);
            return _context.SaveChanges();
        }

        public IEnumerable<Profiling> Search(string nik)
        {
            return GetAll().Where(x => x.EmployeeNik.Contains(nik));
        }

        public int Update(Profiling profiling)
        {
            _context.Set<Profiling>().Update(profiling);
            return _context.SaveChanges();
        }

        public int Delete(string nik)
        {
            var entity = GetById(nik);
            _context.Set<Profiling>().Remove(entity);
            return _context.SaveChanges();
        }*/
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
