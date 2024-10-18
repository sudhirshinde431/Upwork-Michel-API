using NLog.Extensions.Logging;
using NLog;
using Serilog.Events;
using Serilog;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using InfrastructureLayer.Data;
using InfrastructureLayer.Handlers.EmployeeHandler;
using Microsoft.EntityFrameworkCore;
using WebAPI_2;
using WebAPI.Fillters;

var builder = WebApplication.CreateBuilder(args);



var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var ApplicationLogType = MyConfig.GetValue<string>("ApplicationLogType");


if (ApplicationLogType == "1")//n LOg
{
    #region Nlog Configuration

    LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
    var config = new ConfigurationBuilder()
       .SetBasePath(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName))
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .Build();
    LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));


    #endregion



}
else if (ApplicationLogType == "2")// seril log with SQL table
{
    #region Serilog
    Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
    builder.Host.UseSerilog(((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)));
    #endregion
}
else if (ApplicationLogType == "3")// seril log with SQL table
{
    #region Azure blob


    Log.Logger = new LoggerConfiguration()
        .WriteTo.AzureBlobStorage(
            connectionString: "DefaultEndpointsProtocol=https;AccountName=sandbox2024new;AccountKey=9i95sh+HViufRBepbDUe3ubSjMzhermHAX5A4L6vrjHEEocyobelEdFGsLKwpEkbP8xficmSUf0b+ASt1wKQ5g==;EndpointSuffix=core.windows.net",
            storageContainerName: "blobtest",
            storageFileName: "logs/{yyyy}_{MM}_{dd}_log.txt",
            restrictedToMinimumLevel: LogEventLevel.Error)
        .CreateLogger();

    builder.Host.UseSerilog(Log.Logger);

    #endregion
}
else if (ApplicationLogType == "4")//Azure blob with NLog
{
    #region Azure blob with NLog
    var test = Directory.GetCurrentDirectory();
    LogManager.LoadConfiguration(string.Concat(test, "/nlog.config"));

    #endregion



}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
          builder =>
          {
              builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                     
          });
});


// Add services to the container.
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<AwsTokenAuthorizationFilter>();
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Authority = "https://sts.windows.net/6668e656-39be-40ba-8dcd-dfcde2cf7d0c"; // Replace with your Azure AD tenant ID
        options.Audience = "api://10db189e-8288-4ef1-875e-8a6fab5f82dd"; // Replace with your application's client ID
        options.RequireHttpsMetadata = true; // Ensure you're using HTTPS in production

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                // Log the error or handle it as needed
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                // Optional: Log successful validation
                Console.WriteLine("Token validated successfully.");
                return Task.CompletedTask;
            }
        };
    });

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)      
//     .AddJwtBearer(options =>
//     {
//         options.Authority = "https://login.microsoftonline.com/6668e656-39be-40ba-8dcd-dfcde2cf7d0c/v2.0";
//         options.Audience = "api://10db189e-8288-4ef1-875e-8a6fab5f82dd"; // The App ID of your API

//     });
//.AddJwtBearer(opt =>
//{


//    opt.Audience = builder.Configuration.GetSection("AzureAd:ClientId").Value;
//    opt.Authority = "https://login.microsoftonline.com/" + builder.Configuration.GetSection("AzureAd:TenantId").Value;
//    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        //ValidateIssuer = true,
//        //ValidIssuer = "https://sts.windows.net/6668e656-39be-40ba-8dcd-dfcde2cf7d0c/",
//        //ValidateAudience = true,
//        //ValidAudience = "10db189e-8288-4ef1-875e-8a6fab5f82dd",
//        //ValidateLifetime = true
//    };

//});


builder.Services.AddDbContext<DomainLayer.Entities.ApertureSilverDevContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(GetEmployeeListHandler).Assembly));
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(GetDeviceListHandler).Assembly));

builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(GetOrganizationalChartListHandler).Assembly));




builder.Services.AddSingleton<ILoggerManager, LoggerManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();
