using System;
using System.Collections.Generic;
using System.Text;

namespace DITest
{
    public class UserService : IUserService
    {
        private IConfigReader _configReader;

        public UserService(IConfigReader configReader)
        {
            _configReader = configReader;
        }

        public string GetName()
        {
            return "UserName";
        }
    }
}