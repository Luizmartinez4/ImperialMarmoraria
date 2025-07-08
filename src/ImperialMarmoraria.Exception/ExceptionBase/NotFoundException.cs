using System.Net;

namespace ImperialMarmoraria.Exception.ExceptionBase;
public class NotFoundException : ImperialMarmorariaException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int) HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
