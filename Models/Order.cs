
namespace comandas_api.Models;
    public partial class Order
    {
        public string Id { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public string ClientId { get; set; } = null!;
        public string RestaurantId { get; set; } = null!;
        public string? Description { get; set; }
        public string? Code { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Restaurant Restaurant { get; set; } = null!;
    }
