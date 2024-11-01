using Microsoft.AspNetCore.Mvc;
using ApiInterfaces.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiInterfaces.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertersController : ControllerBase
    {
        private readonly IConverters _converters;

        public ConvertersController(IConverters converters)
        {
            _converters = converters;
        }

        [HttpPost("convert-millimeters")]
        public IActionResult ConvertMillimeters([FromBody] ConvertRequest request)
        {
            var result = _converters.ConvertMilimeters(request.Milimeters, request.Unit.ToString().ToLower());
            return Ok(result);
        }
    }

    public class ConvertRequest
    {
        public double Milimeters { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UnitType Unit { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))] // Asegura que Swagger lo trate como string
    public enum UnitType
    {
        [Display(Name = "Meters (1 meter = 1000 millimeters)")]
        Meters,

        [Display(Name = "Centimeters (1 centimeter = 10 millimeters)")]
        Centimeters,

        [Display(Name = "Miles (1 mile = 1,609,344 millimeters)")]
        Miles
    }
}
