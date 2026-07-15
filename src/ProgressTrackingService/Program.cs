using ProgressTrackingService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgressTrackingDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();