
using Data;
using KYCService;
using MemberService;
using Microsoft.EntityFrameworkCore;
using OrchestrationService;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

// DI
builder.Services.AddScoped<IOrchestrator, Orchestrator>();

// Member Service
builder.Services.AddScoped<IMemberService, MemberService.MemberService>();
builder.Services.AddScoped<IMemberRepo, MemberRepo>();

// KYC Service
builder.Services.AddScoped<IKYCService, MockKYCService>();


var app = builder.Build();

// Run DB migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SampleDbContext>();
    context.Database.Migrate();
}

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

public partial class Program { }
