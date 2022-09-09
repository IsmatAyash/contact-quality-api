using Contact.Center.Api.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("MySqlConnStr");
MySqlConnectionStringBuilder conn = new MySqlConnectionStringBuilder(connString);
conn.Password = builder.Configuration["Password"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(conn.ConnectionString, ServerVersion.AutoDetect((conn.ConnectionString))));
builder.Services.AddScoped<IChannelRepo, ChannelRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
