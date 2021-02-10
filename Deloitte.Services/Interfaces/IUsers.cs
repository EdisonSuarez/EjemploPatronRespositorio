using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.Services.Interfaces
{
    public interface IUsers
    {
        Deloitte.Domain.User Login(string login, string password);
    }
}
