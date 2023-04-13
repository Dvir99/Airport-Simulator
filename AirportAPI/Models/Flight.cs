namespace AirportAPI.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public bool IsDeparture { get; set; }
        public string? Status { get; set; }
    }

}
