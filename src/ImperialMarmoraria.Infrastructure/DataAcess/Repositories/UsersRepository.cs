using ImperialMarmoraria.Domain.Entities;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace ImperialMarmoraria.Infrastructure.DataAcess.Repositories;
internal class UsersRepository : IUsersReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
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

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetById(long id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public async Task<bool> Remove(long id)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (result is null)
        {
            return false;
        }

        _context.Users.Remove(result);

        return true;
    }
}