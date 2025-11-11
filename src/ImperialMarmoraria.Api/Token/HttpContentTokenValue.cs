using ImperialMarmoraria.Domain.Security.Tokens;

namespace ImperialMarmoraria.Api.Token
{
    public class HttpContentTokenValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContentTokenValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string TokenOnRequest()
        {
            var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization["Bearer ".Length..].Trim();
        }
    }
}
