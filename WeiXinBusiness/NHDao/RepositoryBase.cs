using NHDao.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHDao
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        
        public virtual object Save(T entity)
        {
            return NHDaoHelper.Instance.Add(entity);
        }

        public virtual T Get(object id)
        {
            return NHDaoHelper.Instance.GetEntity<T>(id);
        }

        //public virtual T Load(object id)
        //{
        //    return NHDaoHelper.Instance.GetSession().Load<T>(id);
        //}

        public virtual void Update(T entity)
        {
            NHDaoHelper.Instance.Edit(entity);
        }

        public  void Delete(T entity)
        {
            NHDaoHelper.Instance.Delete<T>(entity);
        }

        //public virtual IQueryable<T> LoadAllWithPage(out long count, int pageIndex, int pageSize)
        //{
        //    //var result = NHDaoHelper.Instance.GetSession().Load(;
        //    //count = result.LongCount();

        //    //return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //}


        public virtual void Delete(IList<long> idList)
        {
            foreach(var item in idList)
            {
                 NHDaoHelper.Instance.Delete<T>(item);
            }
          
        }

        public virtual void SaveOrUpdate(T entity)
        {
            NHDaoHelper.Instance.GetSession().SaveOrUpdate(entity);
        }
    }
}
