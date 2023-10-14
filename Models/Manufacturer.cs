namespace _14._10_ASP.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer()
        {
            Id = 0;
            Name = string.Empty;
        }

        public Manufacturer(string name)
        {
            Name = name;
        }
    }
}
