using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Choices;
using static Lab1.Quantity;

namespace Lab1
{
    public record Product
    {
        public int CodProdus { get; set; }
        public IQuantity Cantitate { get; set; }

    }

}
