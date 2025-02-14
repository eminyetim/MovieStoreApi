using System.IO.Compression;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Protocols;
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

        public async Task<bool> AddToGenreFavoriteForCustomerAsync(int customerId, Guid genreId)
        {
            var customerExists = await _context.Customers.AnyAsync(c => c.Id == customerId);

            if (!customerExists)
                throw new Exception("Customer Not Found!");

            var genreExists = await _context.Genres.AnyAsync(g => g.Id == genreId);

            if (!genreExists)
                throw new Exception("Genre Not Found!");

            // Daha önceden favori eklenmi mi?
            var result = await _context.CustomerFavoriteGenres.FirstOrDefaultAsync(cfg => cfg.CustomerId == customerId && cfg.GenreId == genreId);
            if (result != null)
                throw new Exception("Customer already has this genre as favorite!");

            var newFavorite = new CustomerFavoriteGenre
            {
                CustomerId = customerId,
                GenreId = genreId
            };
            _context.CustomerFavoriteGenres.Add(newFavorite);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var result = await _context.Customers.Include(p => p.Person).FirstOrDefaultAsync(a => a.Id == id);
            if (result == null)
            {
                return false;
            }
            _context.Persons.Remove(result.Person);
            _context.Customers.Remove(result);
            _context.SaveChanges();
            return true;

        }

        public async Task<IEnumerable<SelectCustomerDto>> GetAllCustomersAsync()
        {
            var result = await _context.Customers
                        .Include(a => a.Person)
                        .Include(c => c.FavoriteGenres)
                            .ThenInclude(fg => fg.Genre)
                        .Include(cstm => cstm.Purchases)
                            .ThenInclude(prchs => prchs.Movie)
                        .ToListAsync();
            return _mapper.Map<IEnumerable<SelectCustomerDto>>(result);
        }

        public async Task<SelectCustomerDto?> GetCustomerByIdAsync(int id)
        {
            var result = await _context.Customers.Include(a => a.Person).FirstOrDefaultAsync(src => src.Id == id);
            if (result is null)
                throw new Exception("Customer is could not be find!");
            return _mapper.Map<SelectCustomerDto>(result);
        }

        public async Task<bool> PurchaseMovieAsync(int customerId, int MovieId)
        {
            var customerExists = await _context.Customers.AnyAsync(cst => cst.Id == customerId);
            if (!customerExists)
                throw new Exception("Customer Not Found!");

            var movieExists = await _context.Movies.FindAsync(MovieId);
            if (movieExists == null)
                throw new Exception("Movie Not Found!");

            var result = _context.Purchases.FirstOrDefault(purch => purch.CustomerId == customerId && purch.MovieId == MovieId);
            if (result != null)
                throw new Exception("Customer has already purchased this movie!");

            var newPurchase = new Purchase
            {
                CustomerId = customerId,
                MovieId = MovieId,
                PurchaseDate = DateTime.UtcNow,
                PurchasePrice = movieExists.Price
            };
            _context.Purchases.Add(newPurchase);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromGenreForCustomerAsync(int customerId, Guid genreGuid)
        {
            var result = await _context.CustomerFavoriteGenres.FirstOrDefaultAsync(cfg => cfg.CustomerId == customerId && cfg.GenreId == genreGuid);
            if (result == null)
                throw new Exception("This genre is not the customer's favorites!");
            _context.CustomerFavoriteGenres.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerAsync(UpdateCustomerDto customer)
        {
            var result = await _context.Customers.Include(p => p.Person).FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (result == null)
                return false;

            result.Person.Name = customer.Name;
            result.Person.BirthDate = customer.BirthDate;
            result.Person.Phone = customer.Phone;
            _context.Customers.Update(result);
            _context.SaveChanges();
            return true;
        }
    }
}