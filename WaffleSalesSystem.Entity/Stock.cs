using System;
using System.Collections.Generic;

namespace WaffleSalesSystem.Entity
{
    public partial class Stock
    {
        public int Id { get; set; }
        public string StockName { get; set; } = null!;
        public int StockPrice { get; set; }
        public int? StockQuantity { get; set; }
    }
}
