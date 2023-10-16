using Lab2.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain
{
    public record ProductPrice
    {
        public decimal Price { get; }

        public ProductPrice(decimal price)
        {
            if (price > 0)
            {
                Price = price;
            }
            else
            {
                throw new ExceptionProductPrice("Price must be higher than 0");
            }
        }
    }
}