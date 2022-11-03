using System;
using System.Collections.Generic;

namespace WaffleSalesSystem.Entity
{
    public partial class Category
    {
        public Category()
        {
            Categorydetails = new HashSet<Categorydetail>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedDatetime { get; set; }
        public sbyte IsActive { get; set; }

        public virtual ICollection<Categorydetail> Categorydetails { get; set; }
    }
}
