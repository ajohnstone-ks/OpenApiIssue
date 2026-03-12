using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
	x =>
{
	var xmlOutput = new XmlDataContractSerializerOutputFormatter();
	xmlOutput.SupportedMediaTypes.Clear();
	xmlOutput.SupportedMediaTypes.Add("application/vnd.example.forecasts+xml");
	xmlOutput.SupportedMediaTypes.Add("application/vnd.example.forecasts2+xml");
	x.OutputFormatters.Insert(0, xmlOutput);

	var jsonInput = (SystemTextJsonInputFormatter)x.InputFormatters.Single(y => y is SystemTextJsonInputFormatter);
	jsonInput.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.example.forecasts+json"));
	jsonInput.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.example.forecasts2+json"));

	var xmlInput = new XmlDataContractSerializerInputFormatter(x);
	xmlInput.SupportedMediaTypes.Clear();
	xmlInput.SupportedMediaTypes.Add("application/vnd.example.forecasts+xml");
	xmlInput.SupportedMediaTypes.Add("application/vnd.example.forecasts2+xml");
	x.InputFormatters.Insert(0, xmlInput);
}
	);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("v1");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerUI(x =>x.SwaggerEndpoint("/openapi/v1.json", "v1"));

app.Run();
