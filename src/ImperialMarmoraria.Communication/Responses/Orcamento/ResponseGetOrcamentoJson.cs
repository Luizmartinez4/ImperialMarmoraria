namespace ImperialMarmoraria.Communication.Responses.Orcamento;
public class ResponseGetOrcamentoJson
{
    public string Nome { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Valor { get; set; } = string.Empty;
    public DateOnly DataInicio { get; set; }
    public DateOnly? DataFim { get; set; }
}