using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        List<Region> GetRegions();
        List<Province> GetProvinces(string regionCode);
        List<Ubigeo> GetDistricts(string provinceCode);
        List<DocumentType> GetDocumentTypes();
    }
}
