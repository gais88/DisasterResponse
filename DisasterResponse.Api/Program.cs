using Microsoft.Extensions.Configuration;
using DisasterResponse.Application;
using DisasterResponse.Persistence;
using DisasterResponse.Api.Extensions;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DisasterResponse.Persistence.DateSeed.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{

    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    x.JsonSerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsePolicy", policy =>
    {
        policy.WithOrigins("*")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCustomExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsePolicy");
app.UseAuthorization();

app.MapControllers();
// Data Seed
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var dbContext = services.GetRequiredService<AppDbContext>();

try
{
    

    if (dbContext != null)
    {
        
        await dbContext.Database.MigrateAsync();

        //await SeedTaxes.SeedTaxAsync(context);
        await InventorySeed.SeedInventoryAsync(dbContext);
        await AffectedIndividualSeed.SeedAffectedIndividualAsync(dbContext);
        await DonorSeed.SeedDonorAsync(dbContext);
       
    }
    
}
catch (Exception ex)
{
    throw new Exception("Erro While Seeding Data" + ex.Message);
}

app.Run();
