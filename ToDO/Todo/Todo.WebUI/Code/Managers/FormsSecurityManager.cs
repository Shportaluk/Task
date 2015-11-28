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
        public string Login ( string user, string pass )
        {
            string id = _UserRepository.IsUser(user, pass);
            if ( id != null )
            {
                FormsAuthentication.SetAuthCookie( user, false );
                return id;
            }
            return null;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}