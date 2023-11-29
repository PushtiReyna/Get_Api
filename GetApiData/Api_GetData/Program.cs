using Api_GetData;
using Data_layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For the Console
builder.Services.AddHttpLogging(o => o = new HttpLoggingOptions());

builder.Services.DIScope();
builder.Services.AddDbContext<ApiGetDataDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DBConnectionString")
    ));

//Log.Logger = new LoggerConfiguration().WriteTo.File("D:\\project\\Get_Api\\Get_Api\\Logs\\ApiLog-.log", rollingInterval: RollingInterval.Day).CreateLogger();
//builder.Logging.AddSerilog();

var app = builder.Build();

//For the Console
app.UseHttpLogging();

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
