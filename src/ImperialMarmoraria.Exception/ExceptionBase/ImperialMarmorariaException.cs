namespace ImperialMarmoraria.Exception.ExceptionBase;
public abstract class ImperialMarmorariaException : SystemException
{
    protected ImperialMarmorariaException(string message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
