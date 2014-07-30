using NHService.Interface;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            var obj = applicationContext.GetObject("NHService.Implement.UserInfoMgrImpl") as IUserInfoMgr;
            //var user = new NHModel.Model.Domain.Userinfo
            //{
            //    Username = "lu",
            //    Userage = 12,
            //    Usersex = true,

            //};
            //user.Companyinfo = new NHModel.Model.Domain.Companyinfo()
            //{
            //    Companyid = 1,
            //    Name = "lxd"
            //};
            //obj.Save(user);
            var entity=obj.Get(1);
            var a = entity.Companyinfo.Companyid;
            var b = entity.Companyinfo.Name;
            var c = entity.Companyinfo.Userinfo;
        }
    }
}
