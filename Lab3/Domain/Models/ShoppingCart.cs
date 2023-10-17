using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Domain
{
    [AsChoice]
    public static partial class ShoppingCart
    {
        public interface IShoppingCartState { }

        public record EmptyShoppingCart : IShoppingCartState
        {
            public EmptyShoppingCart(IReadOnlyCollection<UnvalidatedProduct> products)
            {
                Products = products;
            }

            public IReadOnlyCollection<UnvalidatedProduct> Products { get; }
        }

        public record UnvalidatedShoppingCart : IShoppingCartState
        {
            public UnvalidatedShoppingCart(IReadOnlyCollection<UnvalidatedProduct> shoppingCartList, string reason)
            {
                ShoppingCartList = shoppingCartList;
                Reason = reason;
            }

            public IReadOnlyCollection<UnvalidatedProduct> ShoppingCartList { get; }
            public string Reason { get; }
        }

        public record ValidatedShoppingCart : IShoppingCartState
        {
            public ValidatedShoppingCart(IReadOnlyCollection<ValidatedProduct> shoppingCartList)
            {
                ShoppingCartProducts = shoppingCartList;
            }

            public IReadOnlyCollection<ValidatedProduct> ShoppingCartProducts { get; }
        }

        public record CalculatedShoppingCart : IShoppingCartState
        {
            public CalculatedShoppingCart(IReadOnlyCollection<CalculatedProduct> shoppingCartList)
            {
                ShoppingCartProducts = shoppingCartList;
            }

            public IReadOnlyCollection<CalculatedProduct> ShoppingCartProducts { get; }
        }

        public record PayedShoppingCart : IShoppingCartState
        {
            public PayedShoppingCart(IReadOnlyCollection<CalculatedProduct> shoppingCartList, decimal total)
            {
                ShoppingCartList = shoppingCartList;
                Total = total;
            }

            public IReadOnlyCollection<CalculatedProduct> ShoppingCartList { get; }
            public decimal Total { get; }
        }
    }
}