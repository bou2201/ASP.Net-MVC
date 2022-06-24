using System;
using System.Collections.Generic;

namespace Menswear_App.Models
{
    public partial class Invoicedetail
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalDue { get; set; }
        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
