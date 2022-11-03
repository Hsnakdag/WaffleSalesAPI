using System;
using System.Collections.Generic;

namespace WaffleSalesSystem.Entity
{
    public partial class Sale
    {
        public int Id { get; set; }
        public DateTime? SalesDate { get; set; }
        public string? SalesName { get; set; }
    }
}
