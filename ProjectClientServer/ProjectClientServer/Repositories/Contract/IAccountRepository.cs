using ProjectClientServer.Models;
using ProjectClientServer.Repositories.Contract;

namespace ProjectClientServer.Repositories.Contract
{
    public interface IAccountRepository: IGeneralRepository<Account, string>
    {
        

        /*IEnumerable<Account> GetAll();
        Account? GetById(string nik);
        IEnumerable<Account> Search(string nik);
        int Insert(Account account);
        int Update(Account account);
        int Delete(string nik);*/
    }
}
