namespace ImperialMarmoraria.Communication.Responses.Orcamento;
public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; }

    public ResponseErrorJson(string message)
    {
        ErrorMessages = [message];
    }

    public ResponseErrorJson(List<string> message)
    {
        ErrorMessages = message;
    }
}