using APICatalog.Enum;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APICatalog.Models;

    [Table("Categoria")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
            Situacao = Situacao.Ativo;
        }
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(80)]
        public string? CategoriaNome { get; set; }
        [Required]
        [StringLength(300)]
        public string? UrlImagem { get; set; }

        public Situacao Situacao { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }

