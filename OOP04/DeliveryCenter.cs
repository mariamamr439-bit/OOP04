namespace OOP04
{
    public class DeliveryCenter
    {
        private Shipment[] shipments;
        private int count;

        public Driver? Driver { get; set; }

        public DeliveryCenter(int size)
        {
            shipments = new Shipment[size];
            count = 0;
        }

        public void AddShipment(Shipment shipment)
        {
            if (count < shipments.Length)
            {
                shipments[count] = shipment;
                count++;
            }
        }

        public void RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }

                    shipments[count - 1] = null!;
                    count--;

                    Console.WriteLine(
                        "Shipment Removed Successfully.");

                    return;
                }
            }

            Console.WriteLine("Shipment Not Found.");
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return shipments[index];

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < count)
                    shipments[index] = value;
            }
        }

        public int Count
        {
            get { return count; }
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("=================================");

            if (Driver != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Driver : {Driver.FullName}");
            }

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("---------------------------------");
                shipments[i].PrintShipment();
                Console.WriteLine();
            }
        }

        public void PrintTrackingStatuses()
        {
            ITrackable[] trackableShipments =
                new ITrackable[count];

            for (int i = 0; i < count; i++)
            {
                trackableShipments[i] =
                    (ITrackable)shipments[i];
            }

            DeliveryReport.PrintTrackingReport(
                trackableShipments);
        }

        public void PrintInsuranceCosts()
        {
            IInsurable[] insurableShipments =
                new IInsurable[count];

            for (int i = 0; i < count; i++)
            {
                insurableShipments[i] =
                    (IInsurable)shipments[i];
            }

            DeliveryReport.PrintInsuranceReport(
                insurableShipments);
        }
    }
}