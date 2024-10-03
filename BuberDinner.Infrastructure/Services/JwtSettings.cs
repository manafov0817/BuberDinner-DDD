using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Services
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Audience { get; init; }
        public int ExpiryInMinutes { get; init; }
        public string Issuer { get; init; }
        public string Secret { get; init; }
    }

}
