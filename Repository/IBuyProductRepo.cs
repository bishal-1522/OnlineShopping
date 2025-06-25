using MVCEcommerce.Models.DTO;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Repository
{
    public interface IBuyProductRepo
    {
        
        //public ProductDetail  Availability (AvailabilityDto availabilityDto);
        ProductDetail MakePurchase(AvailabilityDto availabilityDto);
    }
}
