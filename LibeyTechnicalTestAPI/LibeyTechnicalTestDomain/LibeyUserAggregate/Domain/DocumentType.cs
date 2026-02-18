using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDescription { get; set; }
        public DocumentType(int documentTypeId, string documentTypeDescription)
        {
            DocumentTypeId = documentTypeId;
            DocumentTypeDescription = documentTypeDescription;
        }
    }
}
