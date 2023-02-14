using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Repositories;
using Backend.Services;
using Backend.UnitOfWork;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
     
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerDBContext>(ServiceLifetime.Transient);


// Repositories
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


// Services
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerAddressService, CustomerAddressService>();
builder.Services.AddTransient<IServiceWrapper, ServiceWrapper>();


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
