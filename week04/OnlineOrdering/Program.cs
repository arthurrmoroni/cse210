using System;
using System.Collections.Generic;

// Design note: a customer is considered to live in the USA when the country
// of their address is "USA" (ignoring upper/lower case).

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - customer in the USA
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1001", 19.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "UC-2040", 9.50, 3));
        order1.AddProduct(new Product("Laptop Stand", "LS-3300", 34.00, 1));

        // Order 2 - customer outside the USA
        Address address2 = new Address("Avenida da Boavista 1200", "Porto", "Porto", "Portugal");
        Customer customer2 = new Customer("Maria Santos", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-4501", 79.90, 1));
        order2.AddProduct(new Product("Mouse Pad", "MP-0105", 12.00, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"===== Order {orderNumber} =====");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine();
            orderNumber++;
        }
    }
}