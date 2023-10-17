using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3.Domain
{
    public record PayShoppingCartCommand
    {
        public IReadOnlyCollection<UnvalidatedProduct> InputProducts { get; }
        public PayShoppingCartCommand(IReadOnlyCollection<UnvalidatedProduct> products)
        {
            InputProducts = products;
        }

    }
}