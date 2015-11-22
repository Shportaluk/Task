using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeRepository
{
    public interface IUserRepository
    {
        bool IsUser( string user, string pass );
    }
}
