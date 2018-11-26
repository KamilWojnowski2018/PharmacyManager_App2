using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            do
            {
                Console.WriteLine("Podaj komendę: [Product] [Customer] [Manager] [Prescription] [Exit] ");
                command = Console.ReadLine().ToLower();
                if (command == "product")
                {
                    Console.WriteLine("[Product] Podaj komendę: [Add] [Update] [Save] [Reload] [Remove] [Exit]");
                    command = Console.ReadLine().ToLower();
                    if (command == "add")
                    {
                        Product product = new Product();
                        product.AddProduct();
                        Console.WriteLine();
                    }
                    if (command == "update")
                    {
                        Product product = new Product();
                        product.Update();
                        Console.WriteLine();
                    }
                    if (command == "save")
                    {
                        Console.WriteLine("Podaj numer ID Produktu");
                        Product product = new Product();
                        product.ID = int.Parse(Console.ReadLine());
                        product.Save(product.ID);
                    }
                    if (command == "reload")
                    {
                        Console.WriteLine("Podaj numer ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Product product = new Product();
                        product.Reload(id);
                        Console.WriteLine();
                    }
                    if (command == "remove")
                    {
                        Product product = new Product();
                        product.Remove();
                        Console.WriteLine();
                    }
                }
                if (command == "customer")
                {
                    Console.WriteLine("[Customer] Podaj komendę: [Add] [Update] [Save] [Reload] [Remove] [Exit]");
                    command = Console.ReadLine().ToLower();
                    if (command == "add")
                    {
                        Customer customer = new Customer();
                        customer.AddCustomer();
                        Console.WriteLine();
                    }
                    if (command == "update")
                    {
                        Customer customer = new Customer();
                        customer.UpdateCustomer();
                        Console.WriteLine();
                    }
                    if (command == "save")
                    {
                        Console.WriteLine("Podaj numer ID Klienta");
                        Customer customer = new Customer();
                        customer.ID = int.Parse(Console.ReadLine());
                        customer.Save(customer.ID);
                    }
                    if (command == "reload")
                    {
                        Console.WriteLine("Podaj numer ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Customer customer = new Customer();
                        customer.Reload(id);
                        Console.WriteLine();
                    }
                    if (command == "remove")
                    {
                        Customer customer = new Customer();
                        customer.Remove();
                        Console.WriteLine();
                    }
                }
                if (command == "prescription")
                {
                    Console.WriteLine("[Prescription] Podaj komendę: [Remove]");
                    command = Console.ReadLine().ToLower();
                    if (command == "remove")
                    {
                        Prescription prescription = new Prescription();
                        prescription.Remove();
                        Console.WriteLine();
                    }
                }
                if (command == "Manager")
                {
                    Console.WriteLine("[Manager] Podaj komendę: [Show All Product] [Show All Orders] [Exit]");
                    command = Console.ReadLine().ToLower();
                    if (command == "show all product")
                    {
                        Manager manager = new Manager();
                        manager.ShowAll();
                        Console.WriteLine();
                    }
                    if (command == "show all orders")
                    {
                        Manager manager = new Manager();
                        manager.ShowAllOrders();
                        Console.WriteLine();
                    }
                }
            } while (command != "exit");
        }
    }
}
