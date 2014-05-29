using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeggFallLevelDesigner
{
    class cUAC
    {
        private string _username,_password;
        private List<string> username_list, password_list;
        public cUAC()
        {
            _username = "admin";
            _password = "admin";
        }
        public string username
        {
            get { return this._username; }
        }

        public string password
        { 
            get { return this._password; }
        }
    }
}
