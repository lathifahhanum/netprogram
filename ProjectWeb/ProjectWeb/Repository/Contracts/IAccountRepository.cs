using ProjectWeb.Models;
using ProjectWeb.ViewModels;

namespace ProjectWeb.Repository.Contracts
{
    public interface IAccountRepository: IGeneralRepository<Account, string>
    {
        RegisterVM? Register(RegisterVM registerVM);
        bool Login(LoginVM loginVM);

        /*IEnumerable<Account> GetAll();
        Account? GetById(string nik);
        IEnumerable<Account> Search(string nik);
        int Insert(Account account);
        int Update(Account account);
        int Delete(string nik);*/
    }
}
