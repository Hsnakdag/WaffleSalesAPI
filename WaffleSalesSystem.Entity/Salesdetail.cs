using System;
using System.Collections.Generic;

namespace WaffleSalesSystem.Entity
{
    public partial class Salesdetail
    {
        public int Id { get; set; }
        public int? ProductQuantity { get; set; }
        public int? ProductId { get; set; }
        public int? SalesPrice { get; set; }
    }
}
