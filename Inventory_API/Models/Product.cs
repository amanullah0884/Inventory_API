using System.ComponentModel.DataAnnotations;

namespace Inventory_API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Image { get; set; }

        //public int? ParentThesisId { get; set; }
        //public virtual Product ParentThesis { get; set; }

     
    }
}