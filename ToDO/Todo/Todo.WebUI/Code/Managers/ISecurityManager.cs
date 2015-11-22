﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.WebUI.Code.Managers
{
    public interface ISecurityManager
    {
        bool Login(string User, string Pass);
        void Logout();
    }
}
