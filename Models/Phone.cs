namespace _14._10_ASP.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public Characteristics? Characteristics { get; set; }
        public Phone()
        {
            Id = 0;
            Model = string.Empty;
            Manufacturer = null;
            Characteristics = null;
        }

        public Phone(string model, Manufacturer manufacturer, Characteristics? characteristics)
        {
            Model = model;
            Manufacturer = manufacturer;
            Characteristics = characteristics;
        }
    }
}
