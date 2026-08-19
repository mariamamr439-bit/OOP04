namespace OOP04
{
    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        public string DestinationCountry { get; set; }
        public decimal CustomsFee { get; set; }

        public InternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            if (string.IsNullOrWhiteSpace(destinationCountry))
                throw new ArgumentException(
                    "Destination country cannot be empty.");

            if (customsFee < 0)
                throw new ArgumentException(
                    "Customs fee cannot be negative.");

            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code      : {TrackingCode}");
            Console.WriteLine($"Description        : {Description}");
            Console.WriteLine($"Weight             : {Weight} KG");
            Console.WriteLine($"Delivery Fee       : {DeliveryFee} EGP");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee        : {CustomsFee} EGP");
            Console.WriteLine($"Estimated Cost     : {EstimatedCost} EGP");
        }

        public string GetTrackingCode()
        {
            throw new NotImplementedException();
        }
    }
}