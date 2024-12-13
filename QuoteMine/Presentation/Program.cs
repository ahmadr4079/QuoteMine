using Presentation.Configurations;
using Presentation.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureEnvironment();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddControllers(configure => { configure.Filters.Add(typeof(ValidationAttribute)); })
    .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureMapster();
builder.Services.ConfigureApiVersion();

var app = builder.Build();
app.UseExceptionHandler(_ => { });
app.UseSwaggerAndUi();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.MapSwagger();
app.Run();