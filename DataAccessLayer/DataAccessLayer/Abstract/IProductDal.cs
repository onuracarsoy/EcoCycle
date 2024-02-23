using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsFilters(string ProductName, decimal? ProductPrice, int? ProductCount, decimal? ProductWeigth, string ProductWeigthType);
        int ProductCount(int id);
        decimal ProductPriceTotal(int id);
    }
}
