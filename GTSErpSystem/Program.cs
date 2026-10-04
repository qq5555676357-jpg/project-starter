using GTSErpSystem.Data;
using GTSErpSystem.BLL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder.Services.AddDbContext<GTSdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    $"Data Source={GTSErpSystem.Helper.LoginDetails.nameServer};Initial Catalog={GTSErpSystem.Helper.LoginDetails.databaseServer};Persist Security Info=True;User ID={GTSErpSystem.Helper.LoginDetails.userNameServer};Password={GTSErpSystem.Helper.LoginDetails.passServer};"));

builder.Services.AddScoped<Class_Orders>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed sample data / ensure DB
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<GTSdbContext>();
    SeedData.Initialize(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
