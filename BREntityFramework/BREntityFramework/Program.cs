using BREntityFramework;
using BREntityFramework.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ShopDBContext())
        {
            // EMPLOYEES||||||||||||||||||||||
            context.Employees.Add(new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Ivan",
                LastName = "Kasir"
            });
            context.Employees.Add(new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Anna",
                LastName = "Kazbekova"
            });

            // PRODUCTS|||||||||||||||||||||
            context.Products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = 5,
            });
            context.Products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = 5,
            });

            // CUSTOMERS||||||||||||||||||||||
            context.Customers.Add(new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Valera",
                LastName = "Pokupets",
                Phone = "+380939299472"
            });
            context.Customers.Add(new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Phone = "+380973999570"
            });

            context.SaveChanges();
            var customers = context.Customers.ToList();
            var employees = context.Employees.ToList();
            var products = context.Products.ToList();

            // ORDERS|||||||||||||||||||
            context.Orders.Add(new Order
            {
                Id = Guid.NewGuid(),
                Address = "Chernihiv, Hlibopekarska",
                CustomerId = customers[0].Id,
                EmployeeId = employees[0].Id,
                ProductId = products[0].Id
            });
            context.Orders.Add(new Order
            {
                Id = Guid.NewGuid(),
                Address = "Chernihiv, Hlibopekarska",
                CustomerId = customers[1].Id,
                EmployeeId = employees[1].Id,
                ProductId = products[1].Id
            });

            context.SaveChanges();

            var orders = context.Orders.ToList();

            // DELETE ALL||||||||||||||||||||||||||||
            context.Customers.RemoveRange(customers);
            context.Employees.RemoveRange(employees);
            context.Products.RemoveRange(products);
            context.Orders.RemoveRange(orders);

            context.SaveChanges();

        }

        Console.ReadLine();
    }
}