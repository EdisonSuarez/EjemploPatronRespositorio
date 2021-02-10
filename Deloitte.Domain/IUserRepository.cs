using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.Domain
{
    public interface IUserRepository
    {
        User Login(string Id, string Password);

    }
}
