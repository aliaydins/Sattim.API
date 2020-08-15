using Newtonsoft.Json.Linq;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Sattim.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        UserDbContext userDbContext = new UserDbContext();
        public User CreateUser(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
              
                userDbContext.Users.Add(user);
                userDbContext.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var userDbContext = new UserDbContext())
            {
                var deletedUser = GetUserById(id);
                userDbContext.Users.Remove(deletedUser);
                userDbContext.SaveChanges();

                //Teklifleride silmen gerek ürüne ait
            }
        }

        public List<User> GetAllUser()
        {
            
                return userDbContext.Users.ToList();
            
        }

        public User GetUserById(int id)
        {
                return userDbContext.Users.Find(id);
            
        }

        public User UpdateUser(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
                userDbContext.Users.Update(user);
                userDbContext.SaveChanges();
                return user;
            }
        }


        public void UpdateBank(JObject model)
        {
            using (var userDbContext = new UserDbContext())
            {
                dynamic json = model;
                int id = json.userId;
                int cash = json.userBank;

                var findUser = userDbContext.Users.Where(x => x.userId == id).FirstOrDefault();

                if(findUser != null)
                {
                    findUser.userBank = findUser.userBank + cash;
                    userDbContext.Users.Update(findUser);
                    userDbContext.SaveChanges();
                }

            }
        }

        //UserLogin
        public bool UserLogin(JObject model)
        {
            using (var userDbContext = new UserDbContext())
            {
                dynamic json = model;
                string userEmail = Convert.ToString(json.userEmail);
                string userPass = Convert.ToString(json.userPassword);

                var findUser = userDbContext.Users.Where(x => x.userEmail == userEmail && x.userPassword == userPass).FirstOrDefault();

                if (findUser != null)
                {
                    return true;
                   
                }
                return false;

            }
        }

        public bool ChangePassword(JObject model)
        {
            using (var userDbContext =new UserDbContext())
            {
                dynamic json = model;
                string userEmail = Convert.ToString(json.userEmail);
                string newPass = Convert.ToString(json.userPassword);

                var findUser = userDbContext.Users.Where(x=>x.userEmail == userEmail).FirstOrDefault();

                if (findUser != null)
                {
                    findUser.userPassword = newPass;
                    userDbContext.Users.Update(findUser);
                    userDbContext.SaveChanges();
                    return true;
                }
                return false;
                
            }
        }

        public bool UpdateUserInfo(JObject model)
        {
            using (var userDbContext = new UserDbContext())
            {
                dynamic json = model;
                int id = json.userId;
                string userName = Convert.ToString(json.userName);
                string userSurname = Convert.ToString(json.userSurname);

                var findUser = userDbContext.Users.Where(x => x.userId == id).FirstOrDefault();

                if(findUser !=null)
                {
                    findUser.userName = userName;
                    findUser.userSurname = userSurname;
                    userDbContext.Users.Update(findUser);    
                    userDbContext.SaveChanges();
                    return true;
                }

                return false;
                
            }
        }
        
    }
}
