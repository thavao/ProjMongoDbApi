using Microsoft.Extensions.Options;
using ProjMongoDbApi.Services;
using ProjMongoDbApi.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//####

builder.Services.Configure<ProjMongoDbApiDataBaseSettings>(
               builder.Configuration.GetSection(nameof(ProjMongoDbApiDataBaseSettings)));


builder.Services.AddSingleton<IProjMongoDbApiDataBaseSettings>(sp => sp.GetRequiredService<IOptions<ProjMongoDbApiDataBaseSettings>>().Value);

builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();

//####

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
