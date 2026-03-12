using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace OpenApiIssue;
[CollectionDataContract(Name = "forecasts"), DataContract(Name = "forecasts")]
public sealed class WeatherForecasts : Collection<WeatherForecast> {
	public WeatherForecasts(IList<WeatherForecast> list) : base(list) { }

	public WeatherForecasts() { }
}
