namespace _14._10_ASP.Models
{
    public class Characteristics
    {
        public int Id { get; set; }
        public string Memory { get; set; }
        public string Battery { get; set; }
        public string Screen { get; set; }
        public string Camera { get; set; }
        public Characteristics()
        {
            Id = 0;
            Memory = string.Empty;
            Battery = string.Empty;
            Screen = string.Empty;
            Camera = string.Empty;
        }

        public Characteristics(string memory, string battery, string screen, string camera)
        {
            Memory = memory;
            Battery = battery;
            Screen = screen;
            Camera = camera;
        }
    }
}
