using System.ComponentModel.DataAnnotations;
public class Product
{
    [Display(Name ="Product Code")]
    [Required(ErrorMessage = ("{0} should be between a valid number."))]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be greater than 0.")]
    public int? ProductCode { get; set; }

    [Display(Name = "Product Price")]
    [Required(ErrorMessage = ("{0} should be between a valid number."))]
    [Range(0.01, double.MaxValue, ErrorMessage = "{0} must be greater than 0.")]
    public double? Price { get; set; }

    [Display(Name = "Product Quantity")]
    [Required(ErrorMessage = ("{0} should be between a valid number."))]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be greater than 0.")]
    public int? Quantity {  get; set; } 
}

