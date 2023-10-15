using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Choices;
using static Lab1.Product;

namespace Lab1
{
    public record Comanda
    {
        public Contact Contact { get; init; }
        public List<Product> Produse { get; init; }
    }

}
