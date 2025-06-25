namespace MVCEcommerce.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string refreshToken { get; set; } = string.Empty;
        public DateTime refreshTokenExpiryTime { get; set; }
    }
}
