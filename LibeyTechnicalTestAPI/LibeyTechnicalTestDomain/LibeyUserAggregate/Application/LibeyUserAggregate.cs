using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly Context _context;
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository, Context context)
        {
            _repository = repository;
            _context = context;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            var libeyUser = new LibeyUser
            (command.DocumentNumber,
             command.DocumentTypeId,
             command.Name,
             command.FathersLastName,
             command.MothersLastName,
             command.Address,
             command.UbigeoCode,
             command.Phone,
             command.Email,
             command.Password
            );

            _repository.Create(libeyUser);
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public List<LibeyUserResponse> GetAll(string filter = "")
        {
            var query = _context.LibeyUsers.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.DocumentNumber.Contains(filter) || x.Name.Contains(filter));
            }

            return query.Select(x => new LibeyUserResponse
            {
                DocumentNumber = x.DocumentNumber,
                Name = x.Name,
                FathersLastName = x.FathersLastName,
                MothersLastName = x.MothersLastName,
                Email = x.Email
            }).ToList();
        }

        public void Delete(string documentNumber)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (user != null)
            {
                _context.LibeyUsers.Remove(user);
                _context.SaveChanges();
            }
        }

        public void Update(UserUpdateorCreateCommand command)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == command.DocumentNumber);

            if (user != null)
            {
                user.Update(documentTypeId: command.DocumentTypeId,
                            name: command.Name,
                            fathersLastName: command.FathersLastName,
                            mothersLastName: command.MothersLastName,
                            address: command.Address,
                            ubigeoCode: command.UbigeoCode,
                            phone: command.Phone,
                            email: command.Email,
                            password: command.Password);

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }
    }
}