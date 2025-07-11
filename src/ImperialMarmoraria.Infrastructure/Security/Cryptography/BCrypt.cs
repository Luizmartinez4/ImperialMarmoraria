using ImperialMarmoraria.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace ImperialMarmoraria.Infrastructure.Security.Cryptography;
internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordhash) => BC.Verify(password, passwordhash);
}
