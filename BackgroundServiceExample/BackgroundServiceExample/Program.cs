using BackgroundServiceExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registration of my custome service
builder.Services.AddSingleton<IMyExecutionService, MyExecutionService>();

//background service registration
builder.Services.AddSingleton<MyCustomBackgroundService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<MyCustomBackgroundService>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
