using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {

        }

        public List<Product> GetProductsFilters(string ProductName , decimal? ProductPrice , int? ProductCount  ,decimal? ProductWeigth , string ProductWeigthType )
        {
            Context context = new Context();
            IQueryable<Product> query = context.Products;


            if (ProductName != null)
            {
                query = query.Where(x => x.ProductName.ToLower().Contains(ProductName.ToLower()));
            }

            if (ProductPrice != null)
            {
                query = query.Where(x => x.ProductPrice >= ProductPrice);

            }

            if (ProductCount != null)
            {
                query = query.Where(x => x.ProductCount >= ProductCount);
            }

            if (ProductWeigth != null)
            {
                query = query.Where(x => x.ProductWeigth >= ProductWeigth);
            }

            if (ProductWeigthType != null)
            {
                query = query.Where(x => x.ProductWeigthType == ProductWeigthType);
            }

            return query.ToList();
        }

        public int ProductCount(int id)
        {
            Context context = new Context();
            int count = context.Products.Where(x=>x.CompanyID == id).Count();

            return count; 
        }

        public decimal ProductPriceTotal(int id)
        {
            Context context = new Context();
            decimal total = context.Products.Where(x => x.CompanyID == id).Sum(y => y.ProductPrice);

            return total;
        }
    }
}
