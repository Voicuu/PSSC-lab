using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain
{
    [AsChoice]
    public static partial class ShoppingCart
    {
        public interface IShoppingCartState { }

        public record EmptyShoppingCart(IReadOnlyCollection<UnvalidatedProduct> shoppingCartList) : IShoppingCartState;

        public record UnvalidatedShoppingCart(IReadOnlyCollection<UnvalidatedProduct> shoppingCartList, string reason) : IShoppingCartState;

        public record ValidatedShoppingCart(IReadOnlyCollection<ValidatedProduct> shoppingCartList) : IShoppingCartState;

        public record PayedShoppingCart(IReadOnlyCollection<ValidatedProduct> shoppingCartList) : IShoppingCartState;
    }
}
