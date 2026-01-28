using System;

class Program
{
    static void Main()
    {
        Address usaAddress = new Address(
            "123 Main Street",
            "Dallas",
            "TX",
            "USA"
        );

        Customer usaCustomer = new Customer("John Smith", usaAddress);

        Order order1 = new Order(usaCustomer);
        order1.AddProduct(new Product("Laptop", "P1001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 25, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost()}\n");

        Address internationalAddress = new Address(
            "45 King Road",
            "London",
            "N/A",
            "UK"
        );

        Customer internationalCustomer = new Customer("Emma Brown", internationalAddress);

        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(new Product("Phone", "P2001", 600, 1));
        order2.AddProduct(new Product("Headphones", "P2002", 100, 1));
        order2.AddProduct(new Product("Charger", "P2003", 30, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost()}");
    }
}
