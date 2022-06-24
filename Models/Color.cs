using System;
using System.Collections.Generic;

namespace Menswear_App.Models
{
    public partial class Color
    {
        public Color()
        {
            Productdetails = new HashSet<Productdetail>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;

        public virtual ICollection<Productdetail> Productdetails { get; set; }
    }
}
