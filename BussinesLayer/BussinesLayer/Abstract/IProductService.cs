using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IProductService :  IGenericService<Product>
    {

        List<Product> TGetProductsFilters(string ProductName, decimal? ProductPrice, int? ProductCount, decimal? ProductWeigth, string ProductWeigthType);
        int TProductCount(int id);
        decimal TProductPriceTotal(int id);
    }
}
