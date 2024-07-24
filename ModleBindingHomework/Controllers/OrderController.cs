using Microsoft.AspNetCore.Mvc;


namespace ModleBindingHomework.Controllers
{
    public class OrderController : Controller
    {
        [Route("order")]
        public IActionResult Order(Order order)
        {
            if (!ModelState.IsValid)
            {
                
                Double? total = PriceSum(order);
                string error = "";
          
                if (total.HasValue && total != order.InovicePrice)
                {
                    error += $"Inovice Price should be equal to the total cost of all products (i.e. {total}) in the order." + "\n";
                }

                if ( order?.OrderDate != null && order.OrderDate < DateTime.Parse("2000-01-01"))
                {
                    error += "Order date should be greater than or equal to 2000-01-01" + "\n";
                }

                error += string.Join("\n" ,ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                var contentResult = new ContentResult
                {
                    StatusCode = 400, 
                    Content = error,
                    ContentType = "text/plain" 
                };
                return contentResult;


            }
            else
            {
                Double? total = PriceSum(order);
                string error = "";

                if (total.HasValue && total != order.InovicePrice)
                {
                    error += $"Inovice Price should be equal to the total cost of all products (i.e. {total}) in the order.";
                    
                }

                if (order.InovicePrice <= 0)
                {
                    if (error != "") error += "\n";
                    error += "Inovice Price should be should be between a valid number.";
                }

                if (order.OrderDate < DateTime.Parse("2000-01-01"))
                {
                    if (error != "") error += "\n";
                    error += "Order date should be greater than or equal to 2000-01-01";
                }
               
                if (error != "")
                {
                    var contentResult = new ContentResult
                    {
                        StatusCode = 400,
                        Content = error,
                        ContentType = "text/plain"
                    };
                    return contentResult;
                }

                Random random = new Random();
                OrderNo orderNo = new OrderNo();
                orderNo.orderNumber = random.Next(1, 99999);
                return Json(orderNo);
            }

        }

        private double? PriceSum(Order order)
        {
            double total = 0;
            if (order != null && order.Products != null && order.InovicePrice.HasValue)
            {
                foreach (var product in order.Products)
                {
                    if (product.Price.HasValue && product.Quantity.HasValue)
                    {
                        total += product.Price.Value * product.Quantity.Value;
                    }
                    else
                    {
                        return null;
                    }
                }

                return total;
            } else {
                return null;
             }         
        }
    }
}
