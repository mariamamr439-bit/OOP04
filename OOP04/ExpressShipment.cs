namespace OOP04
{
    public class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        public decimal ExtraFee { get; set; }

        public ExpressShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            decimal extraFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            if (extraFee < 0)
                throw new ArgumentException(
                    "Extra fee cannot be negative.");

            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
            }
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Out for Delivery.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine();
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public string GetTrackingCode()
        {
            throw new NotImplementedException();
        }
    }
}