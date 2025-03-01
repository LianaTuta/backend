using TicketService.BL.IOC;
using TicketService.DAL.IOC;
using TicketService.Extensions;
using TicketService.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGeneration();

builder.Services.AddDatabaseConnection(builder.Configuration);
builder.Services.Configure<JwtSettingsModel>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddAuthentificationForWebApp(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
