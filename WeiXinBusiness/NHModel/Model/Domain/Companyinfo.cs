using System;
using System.Text;
using System.Collections.Generic;


namespace NHModel.Model.Domain {
    
    public class Companyinfo {
        public Companyinfo() { }
        public virtual int Companyid { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Userinfo> Userinfo { get; set; }
    }
}
