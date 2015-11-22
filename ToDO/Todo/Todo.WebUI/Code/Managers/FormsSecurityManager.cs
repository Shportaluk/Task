using FakeRepository;
using SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Todo.WebUI.Code.Managers
{
    public class FormsSecurityManager : ISecurityManager
    {
        public IUserRepository _UserRepository { get; set; }
        public FormsSecurityManager( IUserRepository repository )
        {
            _UserRepository = repository;
        }
        public bool Login ( string user, string pass )
        {
            if (_UserRepository.IsUser(user, pass))
            {
                FormsAuthentication.SetAuthCookie( user, false );
                return true;
            }
            return false;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}