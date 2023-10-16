using Lab2.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain
{
    public record ProductName
    {
        public string Name { get; }

        public ProductName(string name)
        {
            if (name.Length > 1)
            {
                Name = name;
            }
            else
            {
                throw new ExceptionProductName("Length must be greater than 1");
            }
        }
    }
}