using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class MallUser 
    {
        public MallUser()
        { }

        public string UserID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
        public string UserTel
        {
            get;
            set;
        }
        public string RealName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }
    }
}