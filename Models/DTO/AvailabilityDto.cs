using System.ComponentModel.DataAnnotations.Schema;
using static MVCEcommerce.Models.Entities.Payment;

namespace MVCEcommerce.Models.DTO
{
    public class AvailabilityDto
    {
      
        public string ProductName { get; set; }
        public int requestedQty { get; set; }
        public PaymentMethod paymentMethod { get; set; }
       
    }
}
