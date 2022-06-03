using System.ComponentModel.DataAnnotations;

namespace CRUDForProducts.Model
{
    public class ProductCollections
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Please enter product name")]
        [StringLength(60,MinimumLength = 3,ErrorMessage = "Please enter Product name min 3 characters and max 60 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter category of product")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Please enter quantity of product")]
        public int Quantity { get; set; }
        [Display(Name = "Price($)")]
        public decimal Price { get; set; }


        [Display(Name = "AddedTime")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}
