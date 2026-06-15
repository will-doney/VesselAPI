// BlueCard model class representing the variables within the blue card data service

namespace vesselDataService.Models
{
    public class BlueCard
    {
        public int Id { get; set; }
        public int VesselImo { get; set; }
        public string CardType { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}