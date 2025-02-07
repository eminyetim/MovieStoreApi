using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Dtos.CustomerDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCustomerDto> AddCustomerAsync(CreateCustomerDto customer)
        {
            var person = new Person
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                Phone = customer.Phone
            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            var newcustomer = new Customer
            {
                PersonId = person.Id
            };
            await _context.Customers.AddAsync(newcustomer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CreateCustomerDto>(person);
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectCustomerDto>> GetAllCustomersAsync()
        {
            var result = await _context.Customers
                        .Include(a => a.Person).ToListAsync();
            return _mapper.Map<IEnumerable<SelectCustomerDto>>(result);
        }

        public async Task<SelectCustomerDto?> GetCustomerByIdAsync(int id)
        {
            var result = await _context.Customers.Include(a => a.Person).FirstOrDefaultAsync(src => src.Id == id);
            if(result is null)
                throw new Exception("Customer is could not be find!");
            return _mapper.Map<SelectCustomerDto>(result);
        }

        public Task<bool> UpdateCustomerAsync(UpdateCustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}