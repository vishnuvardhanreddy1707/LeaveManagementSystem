using LeaveManagementSystem.DATA;
using LeaveManagementSystem.Interfaces;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LeaveDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LeaveManagementSystemConnectionString")));

builder.Services.AddTransient<IEmployee, EmployeeRepo>();
builder.Services.AddTransient<EmployeeS, EmployeeS>();
builder.Services.AddTransient<ILeave, LeaveRepo>();
builder.Services.AddTransient<LeaveS, LeaveS>();
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
