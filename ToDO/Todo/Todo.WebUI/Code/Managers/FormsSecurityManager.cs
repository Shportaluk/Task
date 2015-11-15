using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.WebUI.Code.Managers
{
    public class FormsSecurityManager : ISecurityManager
    {
        public FormsSecurityManager()
        {

        }
        public bool Authenticate ( string user, string pass )
        {
            if (user == "1111" && pass == "132") { return true; }
            return false;
        }
    }
}