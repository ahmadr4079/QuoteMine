using Presentation.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureEnvironment();

var app = builder.Build();
app.UseHttpsRedirection();
app.Run();