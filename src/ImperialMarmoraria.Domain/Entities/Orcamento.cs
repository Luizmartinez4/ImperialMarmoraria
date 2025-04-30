namespace ImperialMarmoraria.Domain.Entities;
public class Orcamento
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}