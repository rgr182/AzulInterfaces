namespace ApiInterfaces.Utils
{
    public interface IConverters
    {
        string ConvertMilimeters(double milimeters, string unit);
    }

    public class Converters : IConverters
    {
        public string ConvertMilimeters(double milimeters, string unit)
        {
            try
            {
                // Realizar conversiones según la unidad especificada
                switch (unit.ToLower())
                {
                    case "meters":
                        return $"{milimeters / 1000.0} meters";
                    case "centimeters":
                        return $"{milimeters / 10.0} centimeters";
                    case "miles":
                        return $"{milimeters / 1609344.0} miles";
                    default:
                        return "Invalid unit. Please specify 'meters', 'centimeters', or 'miles'.";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}
