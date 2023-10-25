using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Park4You.Models
{
        [Table("Endereco_Vaga")]

        public class Endereco_Vaga

        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [RegularExpression(@"[0-9]{8}$", ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [UIHint("_CepTemplate")]
            [MaxLength(8, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]

            public string CEP { get; set; }

            [Required(ErrorMessage = "O CEP informado não retornou um endereço válido!")]
            [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres." )]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [MaxLength(10, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]    
            [Display(Name = "Número")]
            public int Numero { get; set; }

             [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]     
            public string Complemento { get; set; }

            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
             public string Bairro { get; set; }

            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
            [MaxLength(2, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
            public string UF { get; set; }

            [Required(ErrorMessage = "Obrigatório informar a Data!")]
            public DateTime Data { get; set; }

            [Required(ErrorMessage = "Obrigatório informar a Quantidade de vagas!")]
            [Display(Name = "Quantidade de vagas")]
            public int QuantVagas { get; set; }

            //[Required(ErrorMessage = "Obrigatório informar o tamanho da vaga!")]
            //public float TamVagas { get; set; }
            [Required(ErrorMessage = "Obrigatório informar o valor da reserva!")]
            public decimal Valor { get; set; }

            [Display(Name = "Tamanho da Vaga")]
            public TamanhoVagas Tipo { get; set; }

            [Display(Name = "Usuário")]
            [Required(ErrorMessage = "Obrigatório informar o usuário")]
            public int UsuarioId { get; set; }

            [ForeignKey("UsuarioId")]
            public cadast_Usuario cadast_Usuario { get; set; }
        }

        public enum TamanhoVagas
        {
            PequenoPorte,
            MedioPorte,
            GrandePorte
        }
}
