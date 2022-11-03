using System;
using System.Collections.Generic;

namespace api
{
    public partial class Sale
    {
        public int Id { get; set; }
        public DateTime? SalesDate { get; set; }
        public string? SalesName { get; set; }
    }
}
