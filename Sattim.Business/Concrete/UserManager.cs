using Newtonsoft.Json.Linq;
using Sattim.Business.Abstract;
using Sattim.DataAccess.Abstract;
using Sattim.DataAccess.Concrete;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserById(int id)
        {
            if (id > 0)
            {
                return _userRepository.GetUserById(id);
            }
            throw new Exception("id can not be less than 1");
            
        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public void UpdateBank(JObject model)
        {
            _userRepository.UpdateBank(model);
        }

        public Boolean UserLogin(JObject model)
        {
            return _userRepository.UserLogin(model);
        }

        public Boolean ChangePassword(JObject model)
        {
             return _userRepository.ChangePassword(model);
        }
        public Boolean UpdateUserInfo(JObject model)
        {
            return _userRepository.UpdateUserInfo(model);
        }
    }
}
