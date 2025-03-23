using InfodengueAPI.Domain.Validator;
using System.ComponentModel.DataAnnotations;

namespace InfodengueAPI.Domain.Dtos
{
    public class RelatorioRequestDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "A arbovirose é obrigatória")]
        [StringLength(30, ErrorMessage = "A arbovirose deve ter no máximo 50 caracteres")]
        [ArboviroseValidation]
        public string Arbovirose { get; set; } = string.Empty;

        [Required(ErrorMessage = "A semana de início é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SemanaInicio { get; set; }

        [Required(ErrorMessage = "A semana de término é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SemanaFim { get; set; }

        [Required(ErrorMessage = "O código IBGE é obrigatório")]
        [StringLength(7, ErrorMessage = "O código IBGE deve ter no máximo 7 caracteres")]
        public string CodigoIBGE { get; set; } = string.Empty;
    }
}
