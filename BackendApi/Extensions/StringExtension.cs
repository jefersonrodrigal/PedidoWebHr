using System.Text.RegularExpressions;

namespace BackendApi.Extensions
{
    public static class StringExtension
    {
        public static bool IsCpf(this string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2) resto = 0; else resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2) resto = 0; else resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(this string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return false;

            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            if (cnpj.Length != 14 || new string(cnpj[0], 14) == cnpj)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2) resto = 0; else resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2) resto = 0; else resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static string FormatData(this string input)
        {
            return input.Length switch
            {
                11 => Regex.Replace(input, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4"),
                14 => Regex.Replace(input, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5"),
                _ => input 
            };
        }

    }
}

