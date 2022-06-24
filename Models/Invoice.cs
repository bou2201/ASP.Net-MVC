using System;
using System.Collections.Generic;

namespace Menswear_App.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Invoicedetails = new HashSet<Invoicedetail>();
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceStatus { get; set; } = null!;
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Invoicedetail> Invoicedetails { get; set; }
    }
}
