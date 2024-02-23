using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
           return _productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
           return  _productDal.GetList();
        }

        //değişiklik
        public List<Product> TGetProductsFilters(string ProductName, decimal? ProductPrice, int? ProductCount, decimal? ProductWeigth, string ProductWeigthType)
        {
            return _productDal.GetProductsFilters(ProductName, ProductPrice, ProductCount, ProductWeigth, ProductWeigthType);
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }

        public int TProductCount(int id)
        {
           return _productDal.ProductCount(id);
        }

        public decimal TProductPriceTotal(int id)
        {
            return _productDal.ProductPriceTotal(id);
        }

        public void TUpdate(Product t)
        {
           _productDal.Update(t);
        }
    }
}
