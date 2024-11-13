using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using weekOneDayFour.services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;



var builder = WebApplication.CreateBuilder(args);

//adding student services
builder.Services.AddSingleton<IStudentServices,studentServices>();
builder.Services.AddSingleton<IStudentV2Services, studentV2Services>();
builder.Services.AddSingleton<IStudentV3Services, studentV3Services>();



builder.Services.AddControllers();


builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Use URL versioning
});

// Add versioned API explorer to generate Swagger docs for each API version
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // Format version as 'v1', 'v2', etc.
    options.SubstituteApiVersionInUrl = true;
});

// Add Swagger generation
builder.Services.AddSwaggerGen(options =>
{
    var provider = builder.Services.BuildServiceProvider()
                                   .GetRequiredService<IApiVersionDescriptionProvider>();

    // Create Swagger documents for each API version
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerDoc(description.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = $"API {description.ApiVersion}",
            Version = description.ApiVersion.ToString()
        });
    }
});





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        // Add Swagger UI for each version
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                    $"API {description.GroupName.ToUpperInvariant()}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
