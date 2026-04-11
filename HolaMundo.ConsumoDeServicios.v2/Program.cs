using HolaMundo.ConsumoDeServicios.v1.Services;
using HolaMundo.ConsumoDeServicios.v2.Loggers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<HttpLogger>();

builder.Services.AddHttpClient(string.Empty).RemoveAllLoggers().AddLogger<HttpLogger>();

//builder.Services.AddHttpClient("CodigoPostal", options =>
//{
//    options.BaseAddress = new Uri("https://utilidades.vmartinez84.xyz/api/");
//});

//builder.Services.AddHttpClient("CodigoPostal2", options =>
//{
//    options.BaseAddress = new Uri("https://utilidades.vmartinez84.xyz/api/");
//});

builder.Services.AddScoped<CodigoPostalService>();
builder.Services.AddScoped<RenapoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
