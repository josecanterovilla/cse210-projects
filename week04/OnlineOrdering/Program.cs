using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Emily Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1001", 19.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "UC-2040", 8.50, 3));
        order1.AddProduct(new Product("Laptop Stand", "LS-3305", 34.00, 1));

        Address address2 = new Address("Av. Providencia 1234", "Santiago", "RM", "Chile");
        Customer customer2 = new Customer("Jose Cantero", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-4521", 79.90, 1));
        order2.AddProduct(new Product("Webcam HD", "WC-5090", 45.25, 2));

        DisplayOrder(1, order1);
        DisplayOrder(2, order2);
    }

    static void DisplayOrder(int orderNumber, Order order)
    {
        Console.WriteLine($"===== ORDER {orderNumber} =====");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        string total = order.GetTotalCost().ToString("F2", CultureInfo.InvariantCulture);
        Console.WriteLine($"Total Price: ${total}");
        Console.WriteLine();
    }
}
