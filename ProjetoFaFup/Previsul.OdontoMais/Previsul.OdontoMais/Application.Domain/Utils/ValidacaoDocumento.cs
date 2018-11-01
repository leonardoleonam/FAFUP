using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Domain.Utils
{
    public static class ValidacaoDocumento
    {
        public static bool IsCnpj(string cnpj)
        {
            var multiplicator1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicator2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var blacklist = new[]
                                     {
                                         "00000000000000", "11111111111111", "22222222222222", "33333333333333",
                                         "44444444444444", "55555555555555", "66666666666666", "77777777777777",
                                         "88888888888888", "99999999999999"
                                     };
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            if (blacklist.Count(c => c == cnpj) > 0)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);
            var sum = 0;

            for (var i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplicator1[i];

            var rest = (sum % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            var digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (var i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplicator2[i];

            rest = (sum % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest;

            return cnpj.EndsWith(digit);
        }
    }
}

