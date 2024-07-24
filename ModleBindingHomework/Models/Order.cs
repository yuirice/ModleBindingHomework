using System.ComponentModel.DataAnnotations;

public class Order
{
   public int? OrderNo { get; set; }
    [Display(Name = "Order Date")]
    [Required(ErrorMessage = "{0} can't be empty or null")]
    public DateTime? OrderDate { get; set; }

    [Display(Name = "Inovice Price")]
    [Required(ErrorMessage = "{0} can't be empty or null")]
   [Range(0.01, double.MaxValue, ErrorMessage = "Inovice Price must be greater than 0.")]
   public double? InovicePrice { get; set; }

    [Display(Name = "Products")]
    [Required(ErrorMessage = "{0} can't be empty or null")]
    public List<Product>? Products { get; set; }
}

