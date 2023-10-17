using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Domain
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
                throw new ExceptionProductName($"{name} must have more than 1 charachter");
            }
        }

        public static bool TryParseProductName(string nameString, out ProductName name)
        {
            bool isValid = false;
            name = null;

            if (!string.IsNullOrEmpty(nameString))
            {
                isValid = true;
                name = new ProductName(nameString);
            }

            return isValid;
        }
    }
}