using Microsoft.EntityFrameworkCore;
using TicketService.ApiClient.IOC;
using TicketService.BL.IOC;
using TicketService.DAL.IOC;
using TicketService.Extensions;
using TicketService.Models.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGeneration();

builder.Services.AddDatabaseConnection(builder.Configuration);

string? aux = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(aux);

SecretManagerExtension.InjectJsonSecretAsConfigSection(builder, "JwtSetiings", "JwtSettings");
builder.Services.Configure<JwtSettingsModel>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<GoogleBucketConfigurationModel>(builder.Configuration.GetSection("GoogleCloud"));

builder.Services.AddAuthentificationForWebApp(builder.Configuration);
builder.Services.AddClientGoogle(builder.Configuration);
builder.Services.AddApiClient();
builder.Services.AddClientPayPal(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddDbContext<TicketDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddServices();

WebApplication app = builder.Build();


_ = app.UseSwagger();
_ = app.UseSwaggerUI();

app.UserMiddleware();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(
    options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
);
app.MapControllers();

app.Run();
