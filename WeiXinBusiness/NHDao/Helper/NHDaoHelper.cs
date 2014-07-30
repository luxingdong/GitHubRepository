using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHDao.Helper
{
    public class NHDaoHelper
    {
        static NHDaoHelper instance = null;
        public static NHDaoHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new NHDaoHelper();
                return instance;
            }
        }
       
        private ISessionFactory buildSessionFactory()
        {
            Configuration cfg = new Configuration();
            cfg.Configure("ConfigTemplete/MSSQL.cfg.xml");
            return cfg.BuildSessionFactory();
        }
        private ISessionFactory _iSessionFactory = null;
        public ISession GetSession()
        {
            if (_iSessionFactory == null)
                _iSessionFactory = buildSessionFactory();
           return _iSessionFactory.OpenSession();
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public int Add<T>(T entity) where T : class
        {
            using (var sess = GetSession())
            {
                sess.Save(entity);
                sess.Flush();
                return 1;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public int Edit<T>(T entity) where T : class
        {
            using (var sess = GetSession())
            {
                sess.Merge(entity);
                sess.Flush();
                return 1;
            }
        }
        /// <summary>
        /// 由自身ID获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public T GetEntity<T>(object id) where T : class
        {
            var sess = GetSession();
            //using ()
            //{
                return sess.Get(typeof(T).Name, id) as T;
            //}
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public int Delete<T>(T entity) where T : class
        {
            using (var sess = GetSession())
            {
                sess.Delete(entity);
                sess.Flush();
                return 1;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public int Delete<T>(long id) where T : class
        {
            using (var sess = GetSession())
            {
                sess.Delete(GetEntity<T>(id));
                sess.Flush();
                return 1;
            }
        }
    }
}
