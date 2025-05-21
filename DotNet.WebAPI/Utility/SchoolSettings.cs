using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.WebAPI.Utility
{
    public class SchoolSettings
    {
        public string SchoolName { get; set; }
        public SchoolAddress SchoolAddress { get; set; }
    }
    public class SchoolAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
