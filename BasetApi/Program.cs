using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using BasetApi.Service;
using DotNetEnv;
using BasetApi.Extansions;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureControllersBased();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.AddAuthentication();
builder.Services.ConfigureSwaggerBased();
builder.Services.ConfigureCorsBased();
builder.Services.AddScoped<JwtService>();

var app = builder.Build();

app.UseSwagger();
app.ConfigureSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowNext");
app.UseAuthentication();
await app.ConfigureAdminUser();
app.UseAuthorization();
app.MapControllers();
app.Run();
