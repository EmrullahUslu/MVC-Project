using EPayCar.Core.Entity;
using EPayCar.Core.Service;
using EPayCar.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPayCar.Service.DbService
{
    public class CoreDbService<T> : IDbService<T> where T : CoreEntity
    {
        private readonly EPayCarContext _db;
        public CoreDbService(EPayCarContext db)
        {
            _db = db;
        }
        public bool Add(T item)
        {
            
                try
                {
                    _db.Set<T>().Add(item);
                    return Save();
                }
                catch (Exception)
                {
                    return false;
                }
           
        }

        public bool Delete(T item)
        {
            try
            {
                _db.Set<T>().Remove(item);
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T> GetAll() => _db.Set<T>().ToList();

        public T GetById(int id) => _db.Set<T>().Find(id);

        public bool Save() => _db.SaveChanges() > 0 ? true : false;
       
        public bool Update(T item)
        {
            try
            {
                _db.Set<T>().Update(item);
                return Save();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
