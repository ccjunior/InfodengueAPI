namespace InfodengueAPI.Models
{
    public class Relatorio : Entity
    {
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; } = string.Empty;
        public int SolicitanteId { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
        public string CodigoIBGE { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string DadosConsulta { get; set; } = string.Empty; // JSON dos dados retornados pela API

        public Solicitante? Solicitante { get; set; }
    }
}
