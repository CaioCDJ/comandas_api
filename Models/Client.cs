namespace comandas_api.Models;

    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? Cpf { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
