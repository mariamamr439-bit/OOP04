namespace OOP04
{
    public static class DeliveryReport
    {
        public static void PrintTrackingReport(
            ITrackable[] shipments)
        {
            Console.WriteLine("Tracking Report");

            foreach (ITrackable shipment in shipments)
            {
                Console.WriteLine(
                    shipment.GetTrackingStatus()
                );
            }
        }

        public static void PrintInsuranceReport(
            IInsurable[] shipments)
        {
            Console.WriteLine("Insurance Report");

            foreach (IInsurable shipment in shipments)
            {
                Console.WriteLine(
                    $"Insurance: {shipment.CalculateInsurance():0.00} EGP"
                );
            }
        }
    }
}