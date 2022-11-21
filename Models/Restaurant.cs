
namespace comandas_api.Models;
    public partial class Restaurant
    {
        public Restaurant()
        {
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public long? Cnpj { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UrlImg { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
  }

