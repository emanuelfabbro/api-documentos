using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ApiDocumentos.Services;
using ApiDocumentos.Utils;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<HostOptions>(options => options.ShutdownTimeout = System.TimeSpan.FromSeconds(10));


var configuracion = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IOcrService, OcrService>();
builder.Services.AddValidatorsFromAssemblyContaining<FileValidator>();

var app = builder.Build();

var httpsPort = configuracion.GetValue<int?>("HttpsPort") ?? 5001;
app.Urls.Add($"http://0.0.0.0:{httpsPort}");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();