namespace InfodengueAPI.Domain.Models
{
    public class Relatorio : Entity
    {
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; } = string.Empty;
        public int SolicitanteId { get; set; }
        public DateTime SemanaInicio { get; set; }
        public DateTime SemanaFim { get; set; }
        public string CodigoIBGE { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string DadosConsulta { get; set; } = string.Empty;

        public Solicitante? Solicitante { get; set; }
    }
}
