using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaffleSalesSystem.Entity;
using WaffleSalesSystemDataAccess.Abstract;

namespace WaffleSalesSystemDataAccess.Concrete
{

    public class BaseRepository : IBaseRepository
    {
        public Stock CreateStockById(Stock stock)
        {
            using (var waffleSalesDbContext = new WaffleSalesDbContext())
            {
                waffleSalesDbContext.Stocks.Add(stock);
                waffleSalesDbContext.SaveChanges();
                return stock;
            }
        }

        public void DeleteStockById(int id)
        {
            using (var waffleSalesDbContext = new WaffleSalesDbContext())
            {
                var deleteStockById = GetStockById(id);
                waffleSalesDbContext.Stocks.Remove(deleteStockById);
                waffleSalesDbContext.SaveChanges();
            }
        }

        public List<Stock> GetAllProducts()
        {
            using(var waffleSalesDbContext = new WaffleSalesDbContext())
            {
                return waffleSalesDbContext.Stocks.ToList();
            }
       }

        public Stock GetStockById(int id)
        {
            using (var waffleSalesDbContext = new WaffleSalesDbContext())
            {
                return waffleSalesDbContext.Stocks.Find(id);
            }
        }

        public Stock GetStockByName(string name)
        {
            using (var waffleSalesDbContext = new WaffleSalesDbContext())
            {
                return waffleSalesDbContext.Stocks.Find(name);
            }
        }

        public Stock UpdateStockById(Stock stock)
        {
            using (var waffleSalesDbContext = new WaffleSalesDbContext())
            {
              waffleSalesDbContext.Stocks.Update(stock);
                waffleSalesDbContext.SaveChanges();
                return stock;
                
            }
        }
    }
}
