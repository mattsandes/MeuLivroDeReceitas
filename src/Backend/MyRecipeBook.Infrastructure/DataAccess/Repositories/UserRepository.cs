using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly MyRecipeBookDBContext _context;

    public UserRepository(MyRecipeBookDBContext context)
    {
        _context = context;
    }

    public async Task Add(User user) => await _context.Users.AddAsync(user);
    
    public async Task<bool> ExistActiveUserWithEmail(string email) => await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
}