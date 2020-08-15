using Newtonsoft.Json.Linq;
using Sattim.Business.Abstract;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(JObject model)
        {
            _productRepository.DeleteProduct(model);
        }

        public List<Product> GetAllProduct()
        { 
            return _productRepository.GetAllProduct();
        }

        public List<Product> GetMyProduct(int id)
        {
            return _productRepository.GetMyProduct(id);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public List<Product> GetByCategory(JObject model)
        {
            return _productRepository.GetByCategory(model);
        }
        public bool UpdateIsSell(JObject model)
        {
            return _productRepository.UpdateIsSell(model);
        }
       
    }
}
