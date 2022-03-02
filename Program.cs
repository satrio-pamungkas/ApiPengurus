using Microsoft.EntityFrameworkCore;  
using ApiPengurus.Data;
using ApiPengurus.Repositories;

// Variable initialize
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// IHost Builder
builder.Host.ConfigureAppConfiguration((hostingContext, config) => 
{
    var env = hostingContext.HostingEnvironment;
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
});

// ConfigureServices
var DbString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                        builder =>
                        {
                            builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                        });
});
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(DbString));
builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
builder.Services.AddScoped<IPengurusRepository, PengurusRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();

