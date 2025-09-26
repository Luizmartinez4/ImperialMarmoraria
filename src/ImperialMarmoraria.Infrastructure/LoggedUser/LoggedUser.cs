using ImperialMarmoraria.Domain.Entities;
using ImperialMarmoraria.Domain.Security.Tokens;
using ImperialMarmoraria.Domain.Services.LoggedUser;
using ImperialMarmoraria.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ImperialMarmoraria.Infrastructure.LoggedUser
{
    internal class LoggedUser : ILoggedUser
    {
        private readonly ImperialMarmorariaDbContext _context;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(ImperialMarmorariaDbContext context, ITokenProvider tokenProvider)
        {
            _context = context;
            _tokenProvider = tokenProvider;
        }

        public async Task<User> Get()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _context
                .Users
                .AsNoTracking()
                .FirstAsync(u => u.UserId == Guid.Parse(identifier));
        }
    }
}
