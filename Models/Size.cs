using System;
using System.Collections.Generic;

namespace Menswear_App.Models
{
    public partial class Size
    {
        public Size()
        {
            Productdetails = new HashSet<Productdetail>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; } = null!;

        public virtual ICollection<Productdetail> Productdetails { get; set; }
    }
}
