using Lab3.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab3.Domain.ShoppingCart;

namespace Lab3.Domain
{
    public static class ShoppingCartStateOperations
    {
        public static IShoppingCartState ValidateShoppingCart(Func<ProductName, bool> checkProductExists, EmptyShoppingCart shoppingCart)
        {
            List<ValidatedProduct> validatedProducts = new();
            bool isValidList = true;
            string invalidReson = string.Empty;
            foreach (var product in shoppingCart.Products)
            {
                if (!ProductName.TryParseProductName(product.productName, out ProductName productName))
                {
                    invalidReson = $"Invalid product name: {product.productName}";
                    isValidList = false;
                    break;
                }
                if (!ProductPrice.TryParseProductPrice(product.price, out ProductPrice productPrice))
                {
                    invalidReson = $"Invalid product price: {product.price}";
                    isValidList = false;
                    break;
                }
                ValidatedProduct validatedShoppingCartProduct = new(productName, productPrice);
                validatedProducts.Add(validatedShoppingCartProduct);
            }

            if (isValidList)
            {
                return new ValidatedShoppingCart(validatedProducts);
            }
            else
            {
                return new UnvalidatedShoppingCart(shoppingCart.Products, invalidReson);
            }
        }

        public static IShoppingCartState CalculatePrice(IShoppingCartState shoppingCart) =>
            shoppingCart.Match(
                whenEmptyShoppingCart: emptyShoppingCart => emptyShoppingCart,
                whenUnvalidatedShoppingCart: unvalidatedShoppingCart => unvalidatedShoppingCart,
                whenCalculatedShoppingCart: calculatedShoppingCart => calculatedShoppingCart,
                whenPayedShoppingCart: payedShoppingCart => payedShoppingCart,
                whenValidatedShoppingCart: validatedShoppingCart =>
                {
                    var calculatedPrice = validatedShoppingCart.ShoppingCartProducts.Select(validProduct =>
                        new CalculatedProduct(validProduct.productName, validProduct.price)
                    );
                    return new CalculatedShoppingCart(calculatedPrice.ToList().AsReadOnly());
                }
                );

        public static IShoppingCartState PayShoppingCart(IShoppingCartState shoppingCart) =>
            shoppingCart.Match(
                whenEmptyShoppingCart: emptyShoppingCart => emptyShoppingCart,
                whenUnvalidatedShoppingCart: unvalidatedShoppingCart => unvalidatedShoppingCart,
                whenPayedShoppingCart: payedShoppingCart => payedShoppingCart,
                whenValidatedShoppingCart: validatedShoppingCart => validatedShoppingCart,
                whenCalculatedShoppingCart: calculatedShoppingCart =>
                {
                    decimal total = 0;
                    foreach (var product in calculatedShoppingCart.ShoppingCartProducts)
                    {
                        total += product.price.Price;
                    }

                    PayedShoppingCart payedShoppingCart = new(calculatedShoppingCart.ShoppingCartProducts, total);
                    return payedShoppingCart;
                }
                );
    }
}