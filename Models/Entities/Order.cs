using System.ComponentModel.DataAnnotations;
using static MVCEcommerce.Models.Entities.Payment;

namespace MVCEcommerce.Models.Entities
{
    public class Order
    {
        
        
            [Key]
            public int OrderId { get; set; }

            public int ProductId { get; set; }
            public string ProductName { get; set; }
           // public int requesstedQty { get; set; }
            public float TotalPrice { get; set; }
        public int Quantity { get; set; }

        //public PaymentMethod paymentMethod { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        
    }
}
