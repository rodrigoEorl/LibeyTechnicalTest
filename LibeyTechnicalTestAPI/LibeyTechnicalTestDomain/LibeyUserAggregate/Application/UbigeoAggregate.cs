using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly Context _context;
        public UbigeoAggregate(Context context) => _context = context;

        public List<Region> GetRegions() =>
            _context.Regions.ToList();

        public List<Province> GetProvinces(string regionCode) =>
            _context.Provinces.Where(x => x.RegionCode == regionCode).ToList();

        public List<Ubigeo> GetDistricts(string provinceCode) =>
            _context.Ubigeos.Where(x => x.ProvinceCode == provinceCode).ToList();

        public List<DocumentType> GetDocumentTypes() =>
            _context.DocumentTypes.ToList();
    }
}
