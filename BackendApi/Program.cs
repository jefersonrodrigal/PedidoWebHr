using BackendApi.Cors;
using BackendApi.Database.Context;
using BackendApi.Interfaces;
using BackendApi.Routes;
using BackendApi.Services;
using BackendApi.Settings;
// using BackendApi.Database.Entityes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Para preservar a confidencialidade a connection strings não será versionada devido ao uso de user-secrets do .NET
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SeniorHomologServer"]));

// builder.Services.AddScoped<MigrationService>();

builder.Services.AddCustomCorsPolicy();

builder.Services.AddMemoryCache();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings:Gmail"));
builder.Services.AddScoped<ISendEmailService, SendMailService>();


builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    options.JsonSerializerOptions.WriteIndented = true;
})
    .AddRazorOptions(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/";
        // options.AccessDeniedPath = "/";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.Name = "AppCookie";
        options.Cookie.IsEssential = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;

    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs/geral.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Logger(lca => lca
        .Filter.ByIncludingOnly(Matching.FromSource("BackendApi.Controllers.AccountController"))
        .WriteTo.File("Logs/account.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(lcc => lcc
        .Filter.ByIncludingOnly(Matching.FromSource("BackendApi.Controllers.ClienteController"))
        .WriteTo.File("Logs/cliente.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(lcp => lcp
        .Filter.ByIncludingOnly(Matching.FromSource("BackendApi.Controllers.PedidoController"))
        .WriteTo.File("Logs/pedido.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(lcp => lcp
        .Filter.ByIncludingOnly(Matching.FromSource("BackendApi.Services.SendMailService"))
        .WriteTo.File("Logs/envioemail.txt", rollingInterval: RollingInterval.Day))
    .CreateLogger();
    

builder.Host.UseSerilog();

var app = builder.Build();

/*
// Aplica as migrações ao iniciar a aplicação
// Comentado para não quebrar o banco de dados do ERP 
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.Migrate();
}

using (var scope = app.Services.CreateScope())
{
    var migrationService = scope.ServiceProvider.GetRequiredService<MigrationService>();
    migrationService.ApplyMigrations();
}*/

app.UseStaticFiles(); 

app.UseRouting();     

app.UseCors("HomologPolicy"); 

app.UseAuthentication(); 

app.UseAuthorization();  

app.UseEndpoints(endpoints => endpoints.MapCustomRoutes()); 

app.Run();
