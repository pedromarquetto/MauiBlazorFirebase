using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorFirebase.Models
{
    public class AppUserModel
    {
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? Uid { get; set; }
    }
}
