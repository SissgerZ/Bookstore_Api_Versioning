using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Register controllers

// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

// Add versioned API Explorer manually
builder.Services.AddTransient<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();
builder.Services.AddSwaggerGen(options =>
{
    // Generate Swagger documentation for each version manually
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bookstore API - Version 1",
        Version = "v1",
        Description = "A sample API for version 1",
    });

    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Bookstore API - Version 2",
        Version = "v2",
        Description = "A sample API for version 2",
    });

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        // Filter endpoints for specific API versions
        var versionAttribute = apiDesc.CustomAttributes()
            .OfType<ApiVersionAttribute>()
            .FirstOrDefault();

        return versionAttribute != null && docName.Equals($"v{versionAttribute.Versions.First().MajorVersion}");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Configure Swagger UI endpoints for each version
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookstore API - Version 1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Bookstore API - Version 2");
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
