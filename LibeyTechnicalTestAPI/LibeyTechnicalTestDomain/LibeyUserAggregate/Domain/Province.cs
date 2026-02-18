using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Province
    {
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public string ProvinceDescription { get; set; }
        public Province(string provinceCode, string regionCode, string provinceDescription)
        {
            ProvinceCode = provinceCode;
            RegionCode = regionCode;
            ProvinceDescription = provinceDescription;
        }
    }
}
