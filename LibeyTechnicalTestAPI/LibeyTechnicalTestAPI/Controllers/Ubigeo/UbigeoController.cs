using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [ApiController]
    [Route("[controller]")]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoAggregate _aggregate;
        public UbigeoController(IUbigeoAggregate aggregate) => _aggregate = aggregate;

        [HttpGet("regions")]
        public IActionResult GetRegions() => Ok(_aggregate.GetRegions());

        [HttpGet("provinces/{regionCode}")]
        public IActionResult GetProvinces(string regionCode) => Ok(_aggregate.GetProvinces(regionCode));

        [HttpGet("districts/{provinceCode}")]
        public IActionResult GetDistricts(string provinceCode) => Ok(_aggregate.GetDistricts(provinceCode));

        [HttpGet("document-types")]
        public IActionResult GetDocumentTypes() => Ok(_aggregate.GetDocumentTypes());
    }
}
