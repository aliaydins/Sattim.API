using Newtonsoft.Json.Linq;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUser();

        User GetUserById(int id);

        User CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUser(int id);

        void UpdateBank(JObject model);

        bool UserLogin(JObject model);

        bool ChangePassword(JObject model);

        bool UpdateUserInfo(JObject model);

        

        
    }
}
