using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionDescription { get; set; }
        public Region(string regionCode, string regionDescription)
        {
            RegionCode = regionCode;
            RegionDescription = regionDescription;
        }
    }
}
