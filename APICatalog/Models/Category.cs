using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalog.Models;

    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(80)]
        public string? CategoryName { get; set; }
        [Required]
        [StringLength(300)]
        public string? UrlImage { get; set; }
        
        public ICollection<Product>? Products { get; set; }
    }

