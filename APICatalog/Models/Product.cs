using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalog.Models;
    
    [Table("Product")]
    public class Product
    {   
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(80)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(300)]
        public string? ProductDescription { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }
        [Required]
        [StringLength(300)]
        public string? UrlImagem { get; set; }
        
        public float Inventory { get; set; }

        public DateTime DateRegister { get; set; }

        public int? CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

    }

