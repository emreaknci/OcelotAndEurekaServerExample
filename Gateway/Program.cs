using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;
using System.Text;
using Shared;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

JwtOptions? jwtOptions = builder.Configuration.GetSection("JWT").Get<JwtOptions>();

SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Security));
string authenticationProviderKey = "TestKey";
builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme = authenticationProviderKey)
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signInKey,
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true
        };
    });


builder.Configuration.AddJsonFile($"Ocelot.json");


builder.Services.AddOcelot()
    .AddEureka()
    .AddCacheManager(x=>x.WithDictionaryHandle());


builder.WebHost.UseUrls("http://localhost:5000");
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();
await app.UseOcelot();

app.Run();
