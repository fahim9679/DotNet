using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string Pincode { get; set; } 
    }
}
