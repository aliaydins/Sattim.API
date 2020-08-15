using Newtonsoft.Json.Linq;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Abstract
{
    public interface IProductService
    {
        //satılmamış tüm ürünler listesi
         List<Product> GetAllProduct();

        //seçilen bir ürün ve ona ait Offer detayları
        Product GetProductById(int id);
        //yeni ürün oluşturma
        Product CreateProduct(Product product);

        //ürünü güncelleme
        Product UpdateProduct(Product product);

        //ürünü silme  productId ve userId
        void DeleteProduct(JObject model);

        List<Product> GetMyProduct(int id);

        List<Product> GetByCategory(JObject data);

        bool UpdateIsSell(JObject model);
    }
}
