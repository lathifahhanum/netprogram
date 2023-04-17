using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories
{
    public class RoleRepository : GeneralRepository<Role, int, MyContext>
    {
        /*private readonly MyContext _context;
        public RoleRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Set<Role>().ToList();
        }

        public Role? GetById(int id)
        {
            return _context.Set<Role>().Find(id);
        }

        public int Insert(Role role)
        {
            _context.Set<Role>().Add(role);
            return _context.SaveChanges();
        }

        public IEnumerable<Role> Search(string name)
        {
            return GetAll().Where(x => x.Name.Contains(name));
        }

        public int Update(Role role)
        {
            _context.Set<Role>().Update(role);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<Role>().Remove(entity); 
            return _context.SaveChanges();
        }*/
        public RoleRepository(MyContext context) : base(context)
        {
        }
    }
}
