namespace ImperialMarmoraria.Domain.Security.Tokens
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
