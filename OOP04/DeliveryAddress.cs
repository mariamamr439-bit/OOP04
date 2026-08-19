namespace OOP04
{
    public class DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }

        public DeliveryAddress(
            string city,
            string street,
            string building)
        {
            City = city;
            Street = street;
            Building = building;
        }

        public override string ToString()
        {
            return $"{Building}, {Street}, {City}";
        }
    }
}