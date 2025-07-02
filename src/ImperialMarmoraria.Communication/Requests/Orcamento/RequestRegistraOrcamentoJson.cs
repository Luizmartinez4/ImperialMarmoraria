using System.Globalization;

namespace ImperialMarmoraria.Communication.Requests.Orcamento;
public class RequestRegistraOrcamentoJson
{
    public string Nome { get; set; } = string.Empty;
    public string Celular {  get; set; } = string.Empty;
    public string Email {  get; set; } = string.Empty;
    public string Descricao {  get; set; } = string.Empty;
    public int Status { get; set; }
    public string Valor { get; set; } = string.Empty;
    public DateOnly DataInicio { get; private set; }
    public DateOnly? DataFim { get; private set; }

    public RequestRegistraOrcamentoJson()
    {
        Status = 0;
        Valor = "R$ 0,00";
        DataInicio = DateOnly.FromDateTime(DateTime.UtcNow);
        DataFim = null;
    }
}