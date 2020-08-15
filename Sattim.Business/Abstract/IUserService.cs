using Newtonsoft.Json.Linq;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sattim.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUser();

        User GetUserById(int id);

        User CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUser(int id);

        void UpdateBank(JObject model);

        Boolean UserLogin(JObject model);

        Boolean ChangePassword(JObject model);

        Boolean UpdateUserInfo(JObject model);

    }
}
