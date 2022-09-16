using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Business.Mapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(RentalProfile));
builder.Services.AddAutoMapper(typeof(Customer));
builder.Services.AddAutoMapper(typeof(Car));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarRentalDbContext>
(optionsBuilder => 
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("CarRental")));

// builder.Services.AddScoped<ICarService, CarManager>();
// builder.Services.AddScoped<ICarDal, EfCarDal>();
// builder.Services.AddScoped<IUserService, UserManager>();
// builder.Services.AddScoped<IUserDal, EfUserDal>();

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