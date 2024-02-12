using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UI_SchoolUpdate.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UI_SchoolUpdateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UI_SchoolUpdateContext") ?? throw new InvalidOperationException("Connection string 'UI_SchoolUpdateContext' not found.")));

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
