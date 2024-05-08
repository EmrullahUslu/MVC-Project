using EPayCar.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPayCar.Core.Service
{
    public interface IDbService<T> where T : CoreEntity
    {
        bool Add(T item);

        bool Update(T item);

        bool Delete(T item);

        List<T> GetAll();

        T GetById(int id);

        bool Save();
    }
}
