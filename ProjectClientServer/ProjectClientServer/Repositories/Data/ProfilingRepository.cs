using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>
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
