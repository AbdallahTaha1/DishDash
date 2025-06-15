using DishDash.API.Middlewares;
using DishDash.Application;
using DishDash.Domain.Entities;
using DishDash.Infrastructure;
using DishDash.Infrastructure.Authentication.Configurations;
using DishDash.Infrastructure.Data;
using DishDash.Infrastructure.Seeding;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();


    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));

    builder.Services.AddInfrastructure(builder.Configuration)
                    .AddApplication();
}

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        await DbInitializer.SeedAsync(serviceProvider);
    }

    if (app.Environment.IsDevelopment())
        app.UseSwagger()
           .UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
