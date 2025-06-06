using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using HotChocolate.Types;
using HotChocolate.Utilities;
using HotChocolate.Types.Descriptors;
using ZXYZ.SharedCore.Middleware.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://accounts.google.com";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://accounts.google.com",
            
            ValidateAudience = true,
            ValidAudience = "407408718192.apps.googleusercontent.com", // 👈 must match frontend client ID
            ValidateLifetime = true
        };
    });
builder.Services.AddAuthorization(); 
builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddMutationType()
    .AddGraphQLTypes()
    .AddAuthorization();
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.SetMinimumLevel(LogLevel.Debug);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();

app.Run();
 
