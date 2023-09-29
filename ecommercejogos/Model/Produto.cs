using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ecommercejogos.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Console { get; set; } = string.Empty;
      

        [Column(TypeName = "date")]
        public DateOnly DataLancamento { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }
    }
}
