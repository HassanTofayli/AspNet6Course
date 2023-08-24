using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet6Course.Models

{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal price { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }

    }
}
