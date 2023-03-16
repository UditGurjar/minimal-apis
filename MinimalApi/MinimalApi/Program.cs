    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using MinimalApi.Controllers;
    using MinimalApi.Models;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

//Connection string
string cS = builder.Configuration.GetConnectionString("minimalCon");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cS));




var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseHttpsRedirection();


// app.MapGet("/", () => "Hello World");



app.UseEndpoints(EmployeeController.ConfigureEndpoints);

app.Run();
