namespace InfodengueAPI.Models
{
    public class Solicitante : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
