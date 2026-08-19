using System;

namespace OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===============================
            // Driver
            // ===============================

            Driver driver = new Driver(
                1,
                "Ahmed Mohamed",
                "01000000000"
            );

            // ===============================
            // Delivery Center
            // ===============================

            DeliveryCenter deliveryCenter =
                new DeliveryCenter(3);

            deliveryCenter.Driver = driver;

            // ===============================
            // Delivery Addresses
            // ===============================

            DeliveryAddress cairoAddress =
                new DeliveryAddress(
                    "Cairo",
                    "Main Street",
                    "10"
                );

            DeliveryAddress germanyAddress =
                new DeliveryAddress(
                    "Berlin",
                    "Berlin Street",
                    "20"
                );

            // ===============================
            // Create Standard Shipment
            // ===============================

            StandardShipment standardShipment =
                new StandardShipment(
                    "SH001",
                    "Laptop",
                    3,
                    80,
                    cairoAddress
                );

            // ===============================
            // Create Express Shipment
            // ===============================

            ExpressShipment expressShipment =
                new ExpressShipment(
                    "SH002",
                    "Mobile Phone",
                    2,
                    60,
                    cairoAddress,
                    30
                );

            // ===============================
            // Create International Shipment
            // ===============================

            InternationalShipment internationalShipment =
                new InternationalShipment(
                    "SH003",
                    "Television",
                    8,
                    120,
                    germanyAddress,
                    "Germany",
                    100
                );

            // ===============================
            // Add Shipments
            // ===============================

            deliveryCenter.AddShipment(
                standardShipment
            );

            deliveryCenter.AddShipment(
                expressShipment
            );

            deliveryCenter.AddShipment(
                internationalShipment
            );

            // ===============================
            // Print All Shipments
            // ===============================

            deliveryCenter.PrintAllShipments();

            // ===============================
            // ITrackable Polymorphism
            // ===============================

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Tracking Status");
            Console.WriteLine("==========================================");

            ITrackable[] trackableShipments =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            foreach (ITrackable shipment in trackableShipments)
            {
                Console.WriteLine(
                    shipment.GetTrackingStatus()
                );
            }

            // ===============================
            // IInsurable Polymorphism
            // ===============================

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Insurance");
            Console.WriteLine("==========================================");

            IInsurable[] insurableShipments =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            foreach (IInsurable shipment in insurableShipments)
            {
                Console.WriteLine(
                    $"Insurance: {shipment.CalculateInsurance():0.00} EGP"
                );
            }

            // ===============================
            // Delivery Report
            // ===============================

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Reports");
            Console.WriteLine("==========================================");

            DeliveryReport.PrintTrackingReport(
                trackableShipments
            );

            Console.WriteLine();

            DeliveryReport.PrintInsuranceReport(
                insurableShipments
            );

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Program Finished");
            Console.WriteLine("==========================================");
        }
    }
}