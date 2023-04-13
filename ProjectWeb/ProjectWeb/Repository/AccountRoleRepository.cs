using MessagePack;
using ProjectWeb.Contexts;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Repository
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRoleRepository
    {
        /*private readonly MyContext _context;
        public AccountRoleRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<AccountRole> GetAll()
        {
            return _context.Set<AccountRole>().ToList();
        }

        public AccountRole? GetById(int id)
        {
            return _context.Set<AccountRole>().Find(id);
        }

        public int Insert(AccountRole accountRole)
        {
            _context.Set<AccountRole>().Add(accountRole);
            return _context.SaveChanges();
        }

        public IEnumerable<AccountRole> Search(string nik)
        {
            return GetAll().Where(ar => ar.AccountNik.Contains(nik));
        }

        public int Update(AccountRole accountRole)
        {
            _context.Set<AccountRole>().Update(accountRole);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = GetById(id);

            _context.Set<AccountRole>().Remove(entity);
            return _context.SaveChanges();
        }*/
        public AccountRoleRepository(MyContext context) : base(context)
        {
        }
    }
}
