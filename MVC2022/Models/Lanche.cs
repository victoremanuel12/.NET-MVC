using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2022.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }


        [StringLength(80,MinimumLength =10, ErrorMessage = "O Nome do lanche deve conter no mínimo 10 caracteres e  máximo de 80 caracteres")]
        [Display(Name = "Nome do Lanche")]
        [Required(ErrorMessage = "Informe o nome do Lanche")]
        public string LancheNome { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "O Nome do lanche deve conter no mínimo 20 caracteres e  máximo de 200 caracteres")]
        [Display(Name = "Descrição curta do Lanche")]
        [Required(ErrorMessage = "Descrição curta  do Lanche deve ser informada")]
        public string LancheDescricaoCurta { get; set; }


        [StringLength(200, MinimumLength = 20, ErrorMessage = "O Nome do lanche deve conter no mínimo 20 caracteres e  máximo de 200 caracteres")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [Required(ErrorMessage = "Descrição detalhada  do Lanche deve ser informada")]
        public string LancheDescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O preço  do Lanche deve ser informado")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99,ErrorMessage = "O preço deve ser entre 1 e 999.99 ")]
        public decimal LanchePreco { get; set; }
        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Informe o caminho da Imagem")]
        public string LancheImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem em  Miniatura")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Informe o caminho da Imagem")]
        public string LancheImagemThumbnailUrl { get; set; }


        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Em estoque?")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; } // Chave estrangeira da tabela que gera a conexão lanche com categoria
        public virtual Categoria Categoria { get; set; } // nem a linha 18 nem a 19 será criado na tabela, só sera criado uma relação entre o lanche e a categoria especifica

    }
}
