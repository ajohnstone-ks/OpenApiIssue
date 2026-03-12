using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OpenApiIssue
{
    [DataContract(Name = "forecast")]
    public class WeatherForecast {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int TemperatureC { get; set; }

		[DataMember]
        public string? Summary { get; set; }
    }
}
