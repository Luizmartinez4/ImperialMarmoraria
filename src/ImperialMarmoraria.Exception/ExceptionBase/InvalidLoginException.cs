
using System.Net;

namespace ImperialMarmoraria.Exception.ExceptionBase;
public class InvalidLoginException : ImperialMarmorariaException
{
    public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OU_SENHA_INVALIDOS)
    {        
    }

    public override int StatusCode => (int) HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
