namespace ImperialMarmoraria.Communication.Requests.Orcamento;
public class RequestUpdateOrcamentoJson
{
    public string Nome { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Valor { get; set; } = string.Empty;
    public DateOnly? DataFim { get; set; }
}
