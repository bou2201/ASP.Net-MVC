using System;
using System.Collections.Generic;
// using System.Web;

namespace Menswear_App.Models
{
    public partial class Product
    {
        public Product()
        {
            Invoicedetails = new HashSet<Invoicedetail>();
            Productdetails = new HashSet<Productdetail>();
            // ProductImage = "~/wwwroot/images/product/pics2.jpg";
            // ProductPrice.ToString("{N:0}");
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductBrand { get; set; } = null!;
        public string ProductMaterial { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; } = null!;
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Invoicedetail> Invoicedetails { get; set; }
        public virtual ICollection<Productdetail> Productdetails { get; set; }

        // public IFormFile ImageUpload { get; set; }
    }
}
