using SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.WebUI.Code.Managers
{
    public class FormsSecurityManager : SqlTaskRepository, ISecurityManager
    {
        public FormsSecurityManager( )
        {

        }
        public bool Authenticate ( string user, string pass )
        {
            return  CheckUser( user, pass );
        }
    }
}