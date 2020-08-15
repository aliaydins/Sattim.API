using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sattim.Business.Abstract;
using Sattim.DataAccess;
using Sattim.Entities;

namespace Sattim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        
        private IPictureService _pictureService;
        UserDbContext userDb = new UserDbContext();
        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        /// <summary>
        /// Tüm resim bilgilerini döndürür.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pictureService.GetAllPicture());
        }

        /// <summary>
        /// pictureId parametresine göre resimi döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var picture = _pictureService.GetPictureById(id);
            if(picture != null)
            {
                return Ok(picture);
            }
            return BadRequest();
        }

        /// <summary>
        /// ProductId ye göre tüm resimleri listeler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Product/{id}")]

        public IActionResult GetByProductId(int id)
        {
            var pictures = _pictureService.GetPictureByProductId(id);
            if (pictures != null)
            {
                return Ok(pictures);
            }
            return BadRequest();
        }

        /// <summary>
        /// Mevcut resim bilgisini güncelleme
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        [HttpPut]

        public  IActionResult Put([FromBody]Picture picture)
        {

            if (ModelState.IsValid)
            {
                var updatedPicture = _pictureService.UpdatePicture(picture);
                return Ok(picture);
            }

            return BadRequest(picture);
        }
        /// <summary>
        /// Mevcut bir resimi  pictureId değerine göre silinmesi.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        
        public IActionResult Delete (int id)
        {
            if (_pictureService.GetPictureById(id) != null)
            {
                _pictureService.DeletePicture(id);
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// ProductId ye göre tüm resimleri siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Product/{id}")]

        public IActionResult DeleteByProductId(int id)
        {
            _pictureService.DeletePictureByProId(id);
            return Ok();
    
        }
        /// <summary>
        /// Yeniden bir ürün eklerken kullanılacak url
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>

        [HttpPost]

        public async Task<IActionResult> Image (List<Microsoft.AspNetCore.Http.IFormFile>  files)
        {
            var findProId = userDb.Products.OrderByDescending(x => x.productId).First().productId;

            if ( findProId!= null)
            {
                var size = files.Sum(f => f.Length);
                var filePaths = new List<string>();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(),  "wwwroot/Images/" + Guid.NewGuid()+findProId+formFile.FileName);
                        filePaths.Add(filePath);
                        _pictureService.CreatePicture(new Picture { pictureData = filePath, productId = findProId });

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                return Ok(new { files.Count, size, filePaths});

            }
            return BadRequest("Product Not Found");
           
        }
        /// <summary>
        /// productId ye gore resım ekleme 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>

        [HttpPost("{id}")]

        public async Task<IActionResult> Image(List<Microsoft.AspNetCore.Http.IFormFile> files,int id)
        {
            var findProId = userDb.Products.Find(id).productId;
            
            if (findProId != null)
            {
                var size = files.Sum(f => f.Length);
                var filePaths = new List<string>();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/" + Guid.NewGuid() + findProId + formFile.FileName);
                        filePaths.Add(filePath);
                        _pictureService.CreatePicture(new Picture { pictureData = filePath, productId = id });

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                return Ok(new { files.Count, size, filePaths });

            }
            return BadRequest("Product Not Found");

        }


        /// <summary>
        /// denemelik resim ekleme 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("test/id")]

        public async Task<IActionResult> testImage(List<Microsoft.AspNetCore.Http.IFormFile> files,int id)
        {
           
                var size = files.Sum(f => f.Length);
                var filePaths = new List<string>();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/" + Guid.NewGuid()  + formFile.FileName);
                        filePaths.Add(filePath);
                        _pictureService.CreatePicture(new Picture { pictureData = filePath, productId = id });

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                return Ok(new { files.Count, size, filePaths });

        }
    }
}
