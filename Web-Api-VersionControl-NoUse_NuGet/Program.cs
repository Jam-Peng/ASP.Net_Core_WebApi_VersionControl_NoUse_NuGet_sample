using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Web_Api_VersionControl_NoUse_NuGet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//��������M��
builder.Services.AddApiVersioning(options =>
{
    //�ϥγo�Ӽg�k�bPostman��API�ɲ��{�^��V1�����A�p�G�n�ϥ�V2�����n�bURL�᭱�[�W ?api-version=2.0
    options.AssumeDefaultVersionWhenUnspecified = true;

    //�ϥ�Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer (�o�ӮM��O���F��Swagger�i�H�ϥΪ�������)
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

//�`�JMicrosoft.AspNetCore.Mvc.Versioning.ApiExplorer�M��
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; //�榡
    options.SubstituteApiVersionInUrl = true;
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//�פJ�s�W�� ConfigureSwaggerOptions ���O
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

//�إߪ�������Swagger����
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
