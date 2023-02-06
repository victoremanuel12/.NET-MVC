using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2022.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        [Required(ErrorMessage ="Campo nome deve ser preenchido")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo sobrenome deve ser preenchido")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo endereço deve ser preenchido")]
        [StringLength(100)]
        [Display(Name ="Endereço")]
        public string Endereco1 { get; set; }
        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2{ get; set; }
        [Required(ErrorMessage = "Campo CEP deve ser preenchido")]
        [Display(Name = "CEP")]
        [StringLength(10,MinimumLength = 8)]
        public string Cep { get; set; }
        [StringLength(10)]
        public string Estado { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe seu telefone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe seu Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O email não possui um formato correto")]
        public string Email { get; set; }

        //Scaffold faz com que a coluna nao apareça na view
        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do Pedido")]
        public decimal PedidoTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Itens no Pedido")]
        public int TotalItensPedido { get; set; }

        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data Envio Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregueEm { get; set; }
        public List<PedidoDetalhe> Pedidoltens { get; set; }
    }
}
