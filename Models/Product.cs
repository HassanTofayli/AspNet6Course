using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet6Course.Models

{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal price { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public Category Category { get; set; }
        public long CategoryId { get; set; }

    }
}
