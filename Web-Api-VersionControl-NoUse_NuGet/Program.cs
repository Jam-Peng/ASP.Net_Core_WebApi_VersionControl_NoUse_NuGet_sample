using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Web_Api_VersionControl_NoUse_NuGet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//版本控制套件
builder.Services.AddApiVersioning(options =>
{
    //使用這個寫法在Postman打API時莫認回傳V1版本，如果要使用V2版本要在URL後面加上 ?api-version=2.0
    options.AssumeDefaultVersionWhenUnspecified = true;

    //使用Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer (這個套件是為了讓Swagger可以使用版本控制)
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

//注入Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer套件
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; //格式
    options.SubstituteApiVersionInUrl = true;
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//匯入新增的 ConfigureSwaggerOptions 類別
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

//建立版本控制Swagger介面
var versionDescriptionProvider = 
    app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
