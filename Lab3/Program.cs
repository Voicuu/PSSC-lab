using Lab3.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = ReadListOfProducts().ToArray();
            PayShoppingCartCommand command = new(products);
            PayShoppingCartWorkflow workflow = new();
            var result = workflow.Execute(command, (productName) => true);

            result.Match(
                whenShoppingCartPayFailedEvent: @event =>
                {
                    Console.WriteLine($"The payment failed: {@event.Reason}");
                    return @event;
                },
                whenShoppingCartPaySuccededEvent: @event =>
                {
                    Console.WriteLine($"The payment succeded: {@event.Total}");
                    return @event;
                }
                );

            Console.WriteLine("Done");
        }

        private static List<UnvalidatedProduct> ReadListOfProducts()
        {
            List<UnvalidatedProduct> listOfProducts = new();
            do
            {
                Console.Write("Product name: ");
                var productName = Console.ReadLine();
                if (string.IsNullOrEmpty(productName))
                {
                    break;
                }

                Console.Write("Price: ");
                var price = Console.ReadLine();
                if (string.IsNullOrEmpty(price))
                {
                    break;
                }

                listOfProducts.Add(new(productName, price));
            } while (true);
            return listOfProducts;
        }
    }
}