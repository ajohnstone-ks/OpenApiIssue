using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace OpenApiIssue;
[DataContract(Name = "forecasts2")]
public sealed class WeatherForecasts2 {
	[DataMember(Name = "forecasts")]
	public Collection<WeatherForecast> Forecasts { get; set; }
}
