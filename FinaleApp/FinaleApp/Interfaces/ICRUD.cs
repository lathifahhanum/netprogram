using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinaleApp.Models;

namespace FinaleApp.Interfaces
{
    public interface ICRUD<in T> where T : class
    {
        public void read();
        public void create(T obj);
        public void update(T obj, string id);
        public void delete(string id);
        public void readById(string id);

    }
}
