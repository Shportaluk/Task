using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeRepository
{
    public interface IUserRepository
    {
        string IsUser( string user, string pass );
    }
}
