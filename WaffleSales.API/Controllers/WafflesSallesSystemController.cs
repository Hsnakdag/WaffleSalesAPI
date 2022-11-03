using Microsoft.AspNetCore.Mvc;
using WaffleSalesSystem.Business.Abstract;
using WaffleSalesSystem.Entity;

namespace WaffleSalesSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WafflesSallesSystemController : ControllerBase
    {
        
        private readonly IWaffleSalesService _waffleSalesservice;

        public WafflesSallesSystemController(IWaffleSalesService waffleSalesService)
        {
            _waffleSalesservice =  waffleSalesService;
        }
        
        
        /// <summary>
        /// GetAllPRoduct
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProducts")]
       
        public List<Stock> Get()
        {
            return _waffleSalesservice.GetAllProducts();
        }
        [HttpGet("{id}")]
       
        public Stock Get(int id)
        {
            return _waffleSalesservice.GetStockById(id);
        }
        [HttpPost("CreateStockById")]
       
        public Stock Post([FromBody]Stock stock)
        {
            return _waffleSalesservice.CreateStockById(stock);
         }
        [HttpPut("UpdateStockById")]
    
        public Stock Put([FromBody]Stock stock)
        {
            return _waffleSalesservice.UpdateStockById(stock);

        }
        [HttpDelete("{id}")]
       
        public void Delete(int id)
        {
            _waffleSalesservice.DeleteStockById(id);
        }


    }
}
