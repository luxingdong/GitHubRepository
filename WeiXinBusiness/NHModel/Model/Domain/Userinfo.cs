using System;
using System.Text;
using System.Collections.Generic;


namespace NHModel.Model.Domain {
    
    public class Userinfo {
        public virtual int Userid { get; set; }
        public virtual Companyinfo Companyinfo { get; set; }
        public virtual string Username { get; set; }
        public virtual int? Userage { get; set; }
        public virtual bool? Usersex { get; set; }
    }
}
