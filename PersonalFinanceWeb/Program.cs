using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Identity;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.Extenstions;
using PersonalFinance.Service.Extenstions;
using PersonalFinance.Service.Implementation;
using PersonalFinance.Service.Interface;
using Shared.Configuration.Options;
using Shared.Configuration.Setup.Security;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "db";
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "PersinalFinanceDb_part2";
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
var dbPass = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? throw new Exception("SA_PASSWORD not set");

var connectionString = $"Server={dbHost};Database={dbName};User ID={dbUser};Password={dbPass};TrustServerCertificate=True";


//var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new Exception("JWT_SECRET_KEY not set");
//builder.Services.Configure<JwtOptions>(options =>
//{
//    options.SecretKey = jwtSecret;
//    options.Issuer = builder.Configuration["Jwt:Issuer"];
//    options.Audience = builder.Configuration["Jwt:Audience"];
//});
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    //options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;

});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd",
        policy => 
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
          
        
        });   

});

builder.Services.AddHealthChecks();





//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//           .UseLazyLoadingProxies());  // Enable lazy loading
builder.Services.RegisterApplicationDbContext(builder.Configuration, connectionString);

//builder.Services.AddIdentity<AccountUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

//builder.Services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
builder.Services.RegisterRepository();

//builder.Services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
builder.Services.RegisterServices();

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.AddTransient<JWTProvider>();




//builder.Services.ConfigureOptions<JwtOptionsSetup>();//added for Jwt
//builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();//adde for Jwt

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontEnd");

app.UseRouting();

//app.MapHealthChecks("/health");
app.MapGet("/health", () => Results.Ok("Healthy"));


app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();

app.MapControllers();


app.Run();
