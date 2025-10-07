using Microsoft.EntityFrameworkCore;
using ProjectApiBasics.DBContext;
using ProjectApiBasics.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("mssql")));

// Register MongoDB dependcies
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddSingleton<IGamesRepo, GamesRepo>();
builder.Services.AddScoped<IApplicationRepo, ApplicationRepo>();

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