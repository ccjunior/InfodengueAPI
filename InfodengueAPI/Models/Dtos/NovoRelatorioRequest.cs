using System.ComponentModel.DataAnnotations;

namespace InfodengueAPI.Models.Dtos
{
    public class NovoRelatorioRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "A arbovirose é obrigatória")]
        [StringLength(50, ErrorMessage = "A arbovirose deve ter no máximo 50 caracteres")]
        public string Arbovirose { get; set; } = string.Empty;

        [Required(ErrorMessage = "A semana de início é obrigatória")]
        [Range(1, 53, ErrorMessage = "A semana de início deve estar entre 1 e 53")]
        public int SemanaInicio { get; set; }

        [Required(ErrorMessage = "A semana de término é obrigatória")]
        [Range(1, 53, ErrorMessage = "A semana de término deve estar entre 1 e 53")]
        public int SemanaFim { get; set; }

        [Required(ErrorMessage = "O código IBGE é obrigatório")]
        [StringLength(7, ErrorMessage = "O código IBGE deve ter no máximo 7 caracteres")]
        public string CodigoIBGE { get; set; } = string.Empty;
    }
}
