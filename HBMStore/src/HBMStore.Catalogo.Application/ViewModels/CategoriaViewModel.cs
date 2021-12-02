using System.ComponentModel.DataAnnotations;

namespace HBMStore.Catalogo.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo {0} é obrigatório")]
        public int Codigo { get; set; }
    }
}
