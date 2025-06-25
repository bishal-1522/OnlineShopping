namespace MVCEcommerce.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public enum PaymentMethod
        {
            CashOnDelivery,
            DebitCard,
            Esewa,
            Fonepay
        }

    }
}
