using ProjectWeb.Models;

namespace ProjectWeb.Repository.Contracts
{
    public interface IUniversityRepository:IGeneralRepository<University, int>
    {
        /*IEnumerable<University> GetAll();//kbthannya hy utk read saja, IEnum lebih ringan
        University? GetById(int id);
        IEnumerable<University> Search(string name);
        int Insert(University university);
        int Update(University university);
        int Delete(int id);*/
    }
}
