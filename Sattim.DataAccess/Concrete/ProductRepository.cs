using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json.Linq;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;

namespace Sattim.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {

        UserDbContext productDbContext = new UserDbContext();
        public Product CreateProduct(Product product)
        {
            using (var productDbContext = new UserDbContext())
            {
                
                productDbContext.Products.Add(product);
                productDbContext.SaveChanges();
                return product;
            }
        }

        //{
        //"userId": 15,
        //"productId":23
        //}
    public void DeleteProduct(JObject model)
        {
            dynamic json = model;
            int userId = json.userId;
            int proId = json.productId;

            using (var productDbContext = new UserDbContext())
            {
                var findUser = productDbContext.Users.Where(x => x.userId == userId).FirstOrDefault();

                if (findUser != null)
                {
                    var deletedProduct = GetProductById(proId);
                    productDbContext.Products.Remove(deletedProduct);
                    productDbContext.SaveChanges();


                }
            }
        }

        public List<Product> GetAllProduct()
        {
            using (var productDbContext = new UserDbContext())
            {
                // var users = productDbContext.Products.Where(x => SqlFunctions.DateDiff("hour", x.productFirstDate, x.productLastDate) <= 24).ToList();
                return productDbContext.Products.Where(x => x.isSell == false && x.productLasttDate.Day - x.productFirstDate.Day == 1 && x.productLasttDate.Hour - x.productFirstDate.Hour <= 1).ToList();

                //var query = (from c in productdbcontext.pictures
                //             from v in productdbcontext.products.where(x => x.issell == false && x.productlasttdate.day - x.productfirstdate.day == 1
                //             && x.productlasttdate.hour - x.productfirstdate.hour <= 1 && c.productid == x.productid)
                //             select new propicture
                //             {
                //                 productid =v.productid,
                //                 picture = new picture 
                //                 { 
                //                     pictureid=c.pictureid,
                //                     picturedata=c.picturedata,
                //                     productid=c.productid
                //                 },
                //                 producttitle=v.producttitle,
                //                 productexplain=v.productexplain,
                //                 productcategory=v.productcategory,
                //                 productprice=v.productprice,
                //                 productfirstdate =v.productfirstdate,
                //                 productlasttdate =v.productlasttdate,
                //                 issell=v.issell,
                //                 userid=v.userid
                                
                //             }).tolist();
                //return query;
            }
    
        }

       
        
        //User product
        public List<Product> GetMyProduct(int id)
        {
            using (var productDbContext = new UserDbContext())
            {
                return productDbContext.Products.Where(x => x.userId == id).ToList();
            }
        }

        public Product GetProductById(int id)

        {
            using (var productDbContext = new UserDbContext())
            {
                return productDbContext.Products.Find(id);
            }
        }

        public Product UpdateProduct(Product product)
        {
            using (var productDbContext = new UserDbContext())
            {
                productDbContext.Products.Update(product);
                productDbContext.SaveChanges();
                return product;
            }
            
        }
        public List<Product> GetByCategory(JObject model)
        {
            using (var productDbContext = new UserDbContext())
            {
                dynamic json = model;
                string category = Convert.ToString(json.productCategory);

                return productDbContext.Products.Where(x => x.productCategory == category).ToList();
            }
        }
        
        public bool UpdateIsSell(JObject model)
        {
            using (var productDbContext = new UserDbContext())
            {
                dynamic json = model;
                int proId = json.productId;
                int offerId = json.offerId;
                int userId = json.userId;

                var findProduct = productDbContext.Products.Where(x => x.productId == proId).FirstOrDefault();
                var findOffer = productDbContext.Offers.Where(x => x.offerId == offerId).FirstOrDefault();
                var findUser = productDbContext.Users.Where(x => x.userId==userId).FirstOrDefault();
                if (findProduct != null && findOffer != null)
                {
                    findProduct.isSell = true;
                    findOffer.isDone = true;
                    findUser.userBank = findUser.userBank - findOffer.offer;
                    productDbContext.Offers.Update(findOffer);
                    productDbContext.Products.Update(findProduct);
                    productDbContext.Users.Update(findUser);
                    productDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }



    }
}
