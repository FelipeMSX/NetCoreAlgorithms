using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Helpers
{
    /// <summary>
    /// Objeto da classe é realizar validações na camada de exibição.
    /// </summary>
    /// <author>Felipe Morais</author>
    /// <email>felipemsx18@gmail.com</email>
    /// <typeparam name="E"></typeparam>
    public static class RegexPattern
	{
        public const String AddressIp = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
        public const String Cpf = @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$";
        public const String Cnpj = @"^\d{2}\.\d{3}\.\d{3}\W\d{4}\-\d{2}$";
    }
}
