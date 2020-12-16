using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    [Serializable]
    public class UserLogin
    { 
        public int UserID { set; get; }
        public string UserName { set; get; }

        public string HoTen { set; get; }

        public  int? NhomID { set; get; }

   
    }
}