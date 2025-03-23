﻿namespace InfodengueAPI.Domain.Dtos
{
    public class RelatorioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string CodigoIBGE { get; set; } = string.Empty;
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
        public int AnoInicio { get; set; }
        public int AnoFim { get; set; }
        public string Arbovirose { get; set; } = string.Empty;
    }
}
