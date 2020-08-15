using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sattim.Business.Abstract;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;

namespace Sattim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// Satılmamış ve 24 saati geçmemiş tüm ürünleri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {

            var products = _productService.GetAllProduct();
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }
    

        /// <summary>
        /// productId değerine göre ürünü döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = _productService.GetProductById(id);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();

        }

        /// <summary>
        /// Kullanıcıya ait ürünleri döndürür. {userId} parametresini alır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("My/{id}")]

        public IActionResult GetMyProduct(int id)
        {
            var products = _productService.GetMyProduct(id);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        /// <summary>
        /// Category değerine göre filtreleme yapar  {productCategory:"Elektronik"} parametresini alır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Category")]

        public IActionResult GetByCategory(JObject model)
        {
            if (model != null)
            {
                return Ok(_productService.GetByCategory(model));
            }
            return NotFound();

        }

        
        /// <summary>
        /// Yeni Ürün ekleme  productId değeri otomatik increase olduğundan eklemeye gerek yoktur.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        //Product Create
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                var createdProduct = _productService.CreateProduct(product);
                return Ok(createdProduct);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Mevcut ürünü siler parametre olarak {userId, productId} gönderilmesi gerekir.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]

        public IActionResult Delete(JObject model)
        {
            dynamic json = model;
            int id = Convert.ToInt32(json.productId);
            if (_productService.GetProductById(id) != null)
            {
                _productService.DeleteProduct(model);
                return Ok(); //200
            }
            return NotFound();

        }

        /// <summary>
        /// Mevcut ürünü güncelleme 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult Put([FromBody]Product product)
        {
            if (_productService.GetProductById(product.productId)!=null)
            {
                return Ok(_productService.UpdateProduct(product));
            }
            return NotFound();
        }

     
        /// <summary>
        /// Ürün satışını ürün sahibi onaylaması parametre olarak {userId,ProductId,offerId} alır  ve Product Offer tablolarını günceller.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("Sell")]


        //Kullanıcının Ürününün satışını onaylaması
        public IActionResult UpdateisSell (JObject model)
        {
            dynamic json = model;
            int proId = json.productId;
            if (_productService.GetProductById(proId) != null)
            {
                return Ok(_productService.UpdateIsSell(model));
            }

            return NotFound();
        }
       
    }
}
