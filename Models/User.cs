using System;
using System.Collections.Generic;

namespace Menswear_App.Models
{
    public partial class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int UserId { get; set; }
        public string UserUsername { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPhone { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
