using Microsoft.EntityFrameworkCore;
using Twit.DataAccess.Context;
using Twit.WebApi.Settings;
using Twit.WebApi.IoC;

var builder = WebApplication.CreateBuilder(args);

// Настройки
var twitSettings = TwitSettingsReader.Read(builder.Configuration);
builder.Services.AddSingleton(twitSettings);

// IoC конфигурации
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSwagger();

// Контроллеры
builder.Services.AddControllers();


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