using Lab2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2.Domain.ShoppingCart;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = ReadListOfProducts().ToArray();
            UnvalidatedShoppingCart unvalidatedShoppingCart = new(products, "");
            IShoppingCartState result = ValidateShoppingCart(unvalidatedShoppingCart);
            result.Match(
                whenEmptyShoppingCart: emptyShoppingCart => emptyShoppingCart,
                whenUnvalidatedShoppingCart: unvalidatedShoppingCart => unvalidatedShoppingCart,
                whenValidatedShoppingCart: validatedShoppingCart => validatedShoppingCart,
                whenPayedShoppingCart: payedShoppingCart => PayShoppingCart(payedShoppingCart)
                );

            Console.WriteLine("===Done===");
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

        private static IShoppingCartState ValidateShoppingCart(UnvalidatedShoppingCart unvalidatedShoppingCart) =>
            unvalidatedShoppingCart.shoppingCartList.Count == 0 ? new EmptyShoppingCart(new List<UnvalidatedProduct>()) :
            unvalidatedShoppingCart.shoppingCartList.Count <= 1 ?
            new UnvalidatedShoppingCart(new List<UnvalidatedProduct>(), "Error") :
            new ValidatedShoppingCart(new List<ValidatedProduct>());

        private static IShoppingCartState PayShoppingCart(PayedShoppingCart payedShoppingCart) =>
            new PayedShoppingCart(new List<ValidatedProduct>());
    }
}