using System.Text.RegularExpressions;

namespace PRN232.Lab1.CoffeeStore.Service.Validations
{
    public class ProductValidation
    {
        public static void ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("name is not null");
            }
            if (name.Length > 100)
            {
                throw new Exception("Product name cannot exceed 100 characters.");
            }
            string? pattern = @"^[a-zA-Z0-9\s]*$";
            if (!Regex.IsMatch(name, pattern))
            {
                throw new Exception("name is allowed special character");
            }
        }

        public static void ValidateDescription(string? descrip)
        {
            if (!string.IsNullOrWhiteSpace(descrip) && descrip.Length > 100)
            {
                throw new Exception("Description cannot exceed 100 characters.");
            }
        }
        public static void ValidatPrice(decimal? price)
        {
            if (price < 0)
            {
                throw new Exception("Price can not less than 0");
            }
        }
    }
}
