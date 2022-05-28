using api.Database;
using api.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("https://*.lufs.se").SetIsOriginAllowedToAllowWildcardSubdomains();
                if(builder.Environment.IsDevelopment())
                    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            });
    });
builder.Services.AddControllers();
builder.Services.AddDbContext<LufsDbContext>(opt => 
    opt.UseMySql(config.GetConnectionString("LufsDatabase"), ServerVersion.AutoDetect(config.GetConnectionString("LufsDatabase"))));

builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<MemberService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
