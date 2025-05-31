using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TicketService.ApiClient.IOC;
using TicketService.BL.Implementation.Template.IOC;
using TicketService.BL.IOC;
using TicketService.DAL.IOC;
using TicketService.Extensions;
using TicketService.Models.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGeneration();


Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "bold-oasis-458708-t3");


builder.Services.AddDatabaseConnection(builder.Configuration);
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

SecretManagerExtension.InjectJsonSecretAsConfigSection(builder, "JwtSetiings", "JwtSettings");
SecretManagerExtension.InjectJsonSecretAsConfigSection(builder, "StripeCredentials", "StripeCredentials");
Extensions.AddStripe(builder.Configuration);
builder.Services.Configure<JwtSettingsModel>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<StripeCredentials>(builder.Configuration.GetSection("StripeCredentials"));
builder.Services.Configure<GoogleBucketConfigurationModel>(builder.Configuration.GetSection("GoogleCloud"));

builder.Services.AddAuthentificationForWebApp(builder.Configuration);
builder.Services.AddClientGoogle(builder.Configuration);
builder.Services.AddTemplate();
builder.Services.AddApiClient();
builder.Services.AddRepositories();
builder.Services.AddDbContext<TicketDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddServices();
builder.Services.AddScoped<IClaimsTransformation, SecureRoleClaimsTransformer>();
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
