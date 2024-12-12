using Flurl.Http;
using Presentation.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureEnvironment();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureServices(configuration: builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureMapster();
builder.Services.ConfigureApiVersion();

var app = builder.Build();
app.UseSwaggerAndUi();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.MapSwagger();
app.Run();