using Newtonsoft.Json.Linq;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.DataAccess.Abstract
{
    public interface IProductRepository
    {
        //satılmamış tüm ürünler listesi
        List<Product> GetAllProduct();

        //seçilen bir ürün 
        Product GetProductById(int id);
        //yeni ürün oluşturma
        Product CreateProduct(Product product);

        //ürünü güncelleme
        Product UpdateProduct(Product product);

        //ürünü silme  productId ve userId
        void DeleteProduct(JObject model);

        List<Product> GetMyProduct(int id);

        List<Product> GetByCategory(JObject model);
        //Kullanıcı ürünü sattığında hem banka hem urun hemde offers alanlari güncellenir {userId,productId,offerId}
        bool UpdateIsSell(JObject model);

        



    }
}
