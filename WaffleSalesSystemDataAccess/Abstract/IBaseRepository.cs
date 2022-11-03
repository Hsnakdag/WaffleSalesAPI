using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaffleSalesSystem.Entity;

namespace WaffleSalesSystemDataAccess.Abstract
{
    public interface IBaseRepository
    {
        

        List<Stock> GetAllProducts();

        Stock GetStockById(int id);

        Stock GetStockByName(string name);

        Stock CreateStockById(Stock stock);

        Stock UpdateStockById(Stock stock);

        void DeleteStockById(int id);



    }
}
