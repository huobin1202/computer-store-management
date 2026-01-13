using System.Text.RegularExpressions;

namespace ComputerStoreManagement.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            var regex = new Regex(@"^0\d{9,10}$");
            return regex.IsMatch(phone);
        }

        public static bool IsRequired(string? value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsPositiveNumber(decimal value)
        {
            return value > 0;
        }

        public static bool IsPositiveInteger(int value)
        {
            return value > 0;
        }
    }
}
