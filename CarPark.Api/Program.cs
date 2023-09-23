using CarPark.Copy.Api.Filters;
using CarPark.Copy.Api.MiddleWares;
using CarPark.Copy2.Api.Filters;
using CarPark.Core.Repositories;
using CarPark.Core.Services;
using CarPark.Core.UnitOfWorks;
using CarPark.CoreCopy.Repositories;
using CarPark.CoreCopy.Services;
using CarPark.Repository;
using CarPark.Repository.Repositories;
using CarPark.Repository.UnitOfWork;
using CarPark.RepositoryCopy.Repositories;
using CarPark.Service.Mapping;
using CarPark.Service.Services;
using CarPark.ServiceCopy.Services;
using CarPark.ServiceCopy.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//FluentValidator Tanýmlanýyor
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblies(new[]
{
    typeof(FirstClassVehicleDtoValidator).Assembly,
    typeof(SecondClassVehicleDtoValidator).Assembly,
    typeof(VehicleDtoValidator).Assembly
})
);


//kendi filtremiz olduðu için default gelen filtreyi pasif hae getirdik
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
}
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(MapProfile));
//Sql Baðlantýsý

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<IParkingFeeRepository,ParkingFeeRepository>();
builder.Services.AddScoped<IParkingFeeService,ParkingFeeService>();

builder.Services.AddScoped<IUtilitiesRepository, UtilitiesRepository>();
builder.Services.AddScoped<IUtilitiesService, UtilitiesService>();
builder.Services.AddScoped<IHorsePowerRepository, HorsePowerRepository>();
builder.Services.AddScoped<IHorsePowerService, HorsePowerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();


//{
//    x.RegisterValidatorsFromAssemblyContaining<FirstClassVehicleDtoValidator>();
//    x.RegisterValidatorsFromAssemblyContaining<SecondClassVehicleDtoValidator>();
//    x.RegisterValidatorsFromAssemblyContaining<VehicleDtoValidator>();
//}