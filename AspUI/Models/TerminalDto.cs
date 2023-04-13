namespace AspUI.Models
{
    public class TerminalDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int WaitTime { get; set; }
        public int FlightId { get; set; }
        public TerminalNum CurrentTerm { get; set; }
        public TerminalNum NextTerm { get; set; }
    }

    [Flags]
    public enum TerminalNum
    {
        One = 0b000000001,
        Two = 0b000000010,
        Thr = 0b000000100,
        Fou = 0b000001000,
        Fiv = 0b000010000,
        Six = 0b000100000,
        Sev = 0b001000000,
        Eig = 0b010000000,
        Dep = 0b100000000,
    }
}
