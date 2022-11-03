using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaffleSalesSystem.Business.Abstract;
using WaffleSalesSystem.Entity;
using WaffleSalesSystemDataAccess;
using WaffleSalesSystemDataAccess.Abstract;
using WaffleSalesSystemDataAccess.Concrete;

namespace WaffleSalesSystem.Business.Concrete
{
    public class WaffleSalesManager : IWaffleSalesService
    {
        private readonly IBaseRepository _baseRepository;
       
       
       
        public WaffleSalesManager(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Stock CreateStockById(Stock stock)
        {
           return _baseRepository.CreateStockById(stock);

        }

        public void DeleteStockById(int id)
        {
           _baseRepository.DeleteStockById(id);
        }

        public List<Stock> GetAllProducts()
        {
            return _baseRepository.GetAllProducts();
        }

        public List<Stock> GetAllProducts(Stock stock)//Empty
        {
            return null;
        }

        public Stock GetStockById(int id)
        {
           return _baseRepository.GetStockById(id); 

        }

        public Stock GetStockByName(string name)
        {
          return _baseRepository.GetStockByName(name);
        }

        public Stock UpdateStockById(Stock stock)
        {
           return _baseRepository.UpdateStockById(stock);
        }

       
    }
}
