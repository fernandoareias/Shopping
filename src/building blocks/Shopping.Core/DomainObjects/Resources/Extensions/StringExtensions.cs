using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Core.DomainObjects.Resources.Extensions
{
    public static class StringExtensions
    {
        public static string ApenasNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
