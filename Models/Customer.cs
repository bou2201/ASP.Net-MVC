using System;
using System.Collections.Generic;

namespace Menswear_App.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
