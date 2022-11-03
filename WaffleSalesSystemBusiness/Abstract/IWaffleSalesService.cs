using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaffleSalesSystem.Entity;

namespace WaffleSalesSystem.Business.Abstract
{
    public interface IWaffleSalesService
    {
        List<Stock> GetAllProducts(Stock stock);

        Stock GetStockById(int id);

        Stock GetStockByName(string name);

        Stock CreateStockById(Stock stock);

        Stock UpdateStockById(Stock stock);

        void DeleteStockById(int id);
        List<Stock> GetAllProducts();
    }
}
