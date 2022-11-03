using System;
using System.Collections.Generic;

namespace api
{
    public partial class Categorydetail
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? CategoryQuantity { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
