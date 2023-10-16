using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Domain.Exceptions
{
    internal class ExceptionProductName : Exception
    {
        public ExceptionProductName(string message) : base(message) { }
    }
}