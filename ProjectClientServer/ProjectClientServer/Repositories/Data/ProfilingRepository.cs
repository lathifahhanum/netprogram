using ProjectClientServer.Contexts;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
