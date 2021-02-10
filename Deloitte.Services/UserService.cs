using Deloitte.Domain;
using Deloitte.Services.Interfaces;
using System;
using System.Data.SqlClient;

namespace Deloitte.Services
{
    public class UserService : IUsers
    {
        //private readonly string _Conexion;

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        //public UserService(string Conexion)
        //{
        //    this._Conexion = Conexion;
        //}
        public User Login(string login, string password)
        {
            return _userRepository.Login(login, password);

        }
    }
}
