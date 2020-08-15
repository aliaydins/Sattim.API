using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sattim.Business.Abstract;
using Sattim.Business.Concrete;
using Sattim.DataAccess;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;

namespace Sattim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        UserDbContext userDb = new UserDbContext();

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Tüm kullanıcıları döndürür.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAllUser();
            return Ok(users);

        }
        /// <summary>
        /// userId değerine göre kullanıcı mevcut ise döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        /// <summary>
        /// userEmail ve userPassword parametrelerini database'de kontrol eder mevcut ise //200 döndürür.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Login")]
        public IActionResult Login(JObject model)
        {
            if (_userService.UserLogin(model) != false)
            {
                return Ok();
            }
            return NotFound();

        }

        /// <summary>
        /// Yeni kullanıcı oluşturur. userId değeri otomatik increase olduğu için eklemeye gerek yok.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = _userService.CreateUser(user);
                return Ok(createdUser);
            }

            return BadRequest(ModelState);


        }

        /// <summary>
        /// Kullanıcı bilgileri update
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (_userService.GetUserById(user.userId) != null)
            {
                return Ok(_userService.UpdateUser(user));//200+user
            }

            return NotFound();//404
        }

        /// <summary>
        /// userId değerine göre kullanıcı mevcut ise silinir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userService.GetUserById(id) != null)
            {
                _userService.DeleteUser(id);
                return Ok(); //200
            }
            return NotFound();

        }

       
        
        /// <summary>
        /// userId değerine göre kullanıcıya bakiye eklemesi yapılır {userId, userBank} parametreleri alır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBank(JObject model)
        {
            dynamic json = model;
            int id = json.userId;
            if (_userService.GetUserById(id) != null)
            {
                _userService.UpdateBank(model);
                return Ok(); //200
            }
            return NotFound();

        }
        /// <summary>
        /// Kullanıcı şifresinin güncellenmesi. {userEmail, userPassword} parametrelerini alır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ChangePassword")]

        public IActionResult ChangePass(JObject model)
        {
            
            if (_userService.ChangePassword(model) != false)
            {
                return Ok();
            }
            return NotFound();
        }
        /// <summary>
        /// Kullanıcı bilgilerinin güncellenmesi {userName, userSurname } parametrelerini alır. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]

        public IActionResult UpdateUserInfo(JObject model)
        {

            if (_userService.UpdateUserInfo(model) != false)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("Image/{id}")]

        public async Task<IActionResult> Image (List<Microsoft.AspNetCore.Http.IFormFile>  files, int id)
        {
            var findUser = userDb.Users.Find(id);
            if ( findUser!= null)
            {
                var size = files.Sum(f => f.Length);
                var filePaths = new List<string>();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(),  "wwwroot/proImg/" + Guid.NewGuid() + id +formFile.FileName);
                        filePaths.Add(filePath);
                        findUser.userImg = filePath;    
                        userDb.Update(findUser);
                        userDb.SaveChanges();

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                return Ok(new { files.Count, size, filePaths});

            }
            return BadRequest("User Not Found");
           
        }
    }
}
