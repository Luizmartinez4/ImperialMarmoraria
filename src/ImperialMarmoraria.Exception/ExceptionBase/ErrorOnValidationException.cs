namespace ImperialMarmoraria.Exception.ExceptionBase;
public class ErrorOnValidationException : ImperialMarmorariaException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
