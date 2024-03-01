using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class JwtOptions
    {
        public string? Security { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
