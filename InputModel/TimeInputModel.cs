using System.ComponentModel.DataAnnotations;

namespace ExemploApiCatalogoTimes.InputModel
{
    public class TimeInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do Time deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do Estado deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(500000, 500000000, ErrorMessage = "O preço deve ser de no mínimo 500.000 real e no máximo 500.000.000 reais")]
        public double Preco { get; set; }
    }
}
