using Microsoft.Extensions.Configuration;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddOcelot(configuration)
    .AddPolly()
    .AddConsul()
    .AddCacheManager(o=>o.WithDictionaryHandle());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseOcelot().Wait();






app.UseAuthorization();

app.MapControllers();

app.Run();
