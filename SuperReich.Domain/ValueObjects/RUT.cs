using System;
using System.Text.RegularExpressions;

namespace SuperReich.Domain.ValueObjects
{
    public class RUT
    {
        public string Value { get; private set; }

        public RUT(string value)
        {
            // Validación adicional para nulos o vacíos
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El RUT no puede estar vacío.");
            }

            // Validar el RUT
            if (!ValidateRut(value))
            {
                throw new ArgumentException("El RUT no es válido.");
            }

            // Asignar el valor validado
            Value = value;
        }

        private bool ValidateRut(string rut)
        {
            // Eliminar puntos, guiones y espacios
            rut = rut.Replace(".", "").Replace("-", "").Trim();

            // Validar formato (debe ser numérico seguido de un dígito verificador)
            if (!Regex.IsMatch(rut, @"^\d{1,8}[0-9kK]$"))
            {
                return false;
            }

            // Separar número base y dígito verificador
            string numero = rut.Substring(0, rut.Length - 1);
            char dv = rut[rut.Length - 1];

            // Calcular el dígito verificador
            char dvCalculado = CalculateCheckDigit(numero);

            // Comparar el dígito verificador calculado con el proporcionado
            return dvCalculado == char.ToUpper(dv);
        }

        private char CalculateCheckDigit(string number)
        {
            int sum = 0;
            int multiplier = 2;

            // Sumar cada dígito multiplicado por el factor correspondiente
            for (int i = number.Length - 1; i >= 0; i--)
            {
                sum += (number[i] - '0') * multiplier;
                multiplier = multiplier == 7 ? 2 : multiplier + 1;
            }

            int rest = sum % 11;
            int dv = 11 - rest;

            // Convertir el resultado a dígito verificador
            if (dv == 11)
                return '0';
            if (dv == 10)
                return 'K';

            return (char)(dv + '0');
        }
    }
}
