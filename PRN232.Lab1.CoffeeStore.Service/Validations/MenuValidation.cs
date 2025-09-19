using System.Text.RegularExpressions;

namespace PRN232.Lab1.CoffeeStore.Service.Validations
{
    public class MenuValidation
    {

        public static void NameValid(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("name is not null");
            }
            string? pattern = @"^[a-zA-Z0-9\s]*$";
            if (!Regex.IsMatch(name, pattern))
            {
                throw new Exception("name is allowed special character");
            }
            if (name.Length > 100)
            {
                throw new ArgumentException("name cannot exceed 100 characters.");
            }
        }

        public static DateTime DateCheck(string? input)
        {
            bool isValid = DateTime.TryParseExact(input, "dd-MM-yyyy",
                                                  System.Globalization.CultureInfo.InvariantCulture,
                                                  System.Globalization.DateTimeStyles.None,
                                                  out DateTime dateValue);

            if (!isValid)
            {
                throw new Exception("Invalid date format dd-MM-yyyy");
            }
            return dateValue;
        }
    }
}
