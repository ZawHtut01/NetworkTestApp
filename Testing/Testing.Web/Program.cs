using Microsoft.EntityFrameworkCore;
using Orders.Application.Features;
using Orders.Domain.Repositories;
using Orders.Infrastructure;
using Orders.Infrastructure.Data;
using Orders.Infrastructure.Repositories;
using Products.Application.Features;
using Products.Domain.Repositories;
using Products.Infrastructure;
using Products.Infrastructure.Data;
using Products.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//// Register MediaR from modules assemblies
//builder.Services.AddMediatR(cfg =>
//{
//    cfg.RegisterServicesFromAssembly(typeof(GetProductsQuery).Assembly);
//    cfg.RegisterServicesFromAssembly(typeof(GetOrdersQuery).Assembly);
//});

//// Register EF Core DbContexts
//builder.Services.AddDbContext<ProductDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<OrderDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//// Register Repositories (DI)
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddProductsModule(builder.Configuration);
builder.Services.AddOrdersModule(builder.Configuration);


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
