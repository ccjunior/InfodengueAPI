namespace InfodengueAPI.Domain.Dtos
{
    public class RelatorioResponseDto
    {
        public int Id { get; set; }
        public string NomeSolicitante { get; set; } = string.Empty;
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; } = string.Empty;
        public DateTime SemanaInicio { get; set; }
        public DateTime SemanaFim { get; set; }
        public string CodigoIBGE { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public dynamic Dados { get; set; } = string.Empty;
    }
}
