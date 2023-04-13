namespace AirportAPI.Models
{
    public class Logger
    {
        public int Id { get; set; }
        public Terminal? Terminal { get; set; }
        public Flight? Flight { get; set; }
        public DateTime In { get; set; }
        public DateTime Out { get; set; }
    }
}
