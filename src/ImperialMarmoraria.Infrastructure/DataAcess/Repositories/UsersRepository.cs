using ImperialMarmoraria.Domain.Entities;
using ImperialMarmoraria.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace ImperialMarmoraria.Infrastructure.DataAcess.Repositories;
internal class UsersRepository : IUsersReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly ImperialMarmorariaDbContext _context;

    public UsersRepository(ImperialMarmorariaDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _context.Users.AnyAsync(user => user.Email == email);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
}