namespace vesselDataService.Models
{
    public class Vessel
    {
        public int Id { get;set; }
        public string ImoNumber { get;set; } = string.Empty;
        public string VesselName { get;set; } = string.Empty;
        public string Member { get;set; } = string.Empty;
        public string RegisteredOwner { get;set; } = string.Empty;
        public int GrossTonnage { get;set; } = 0;
        public string Flag { get;set; } = string.Empty;
        public int Year { get;set; } = 0;
        public string ShipType { get;set; } = string.Empty;
        public string Insurer { get;set; } = string.Empty;
        public string Status { get;set; } = "On Risk";
        public List<BlueCard> BlueCards { get;set; } = new List<BlueCard>();
    }
}