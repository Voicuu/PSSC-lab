using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    [AsChoice]
    public static class Quantity
    {
        public interface IQuantity { }

        public record Number(string quantity) : IQuantity;
    }

}
