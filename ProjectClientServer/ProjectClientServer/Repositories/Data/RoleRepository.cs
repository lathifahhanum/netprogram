using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories
{
    public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
    {
        
        public RoleRepository(MyContext context) : base(context)
        {
        }
    }
}
