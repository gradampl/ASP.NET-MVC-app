using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(int id);
        IEnumerable<T> GetAllActive();
        void Add(T model);
        void Delete(T model);
        void SaveChanges();
    }
}
