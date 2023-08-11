using APICatalog.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalog.Models;
    
    [Table("Produto")]
    public class Produto
    {   
        public Produto()
        {
            Situacao = Situacao.Inativo;
            DataRegistro = DateTime.Now;
        }
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(80)]
        public string? ProdutoNome { get; set; }
        [Required]
        [StringLength(300)]
        public string? ProdutoDescricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ProdutoPreco { get; set; }
        [Required]
        [StringLength(300)]
        public string? UrlImagem { get; set; }
        
        public float Quantidade  { get; set; }

        public DateTime DataRegistro { get; set; }

        public int? CategoriaId { get; set; }

        public Situacao Situacao { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

    }

