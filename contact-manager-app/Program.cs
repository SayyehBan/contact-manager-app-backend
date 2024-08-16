using contact_manager_app.ConfigureService.Configure;
using contact_manager_app.ConfigureService.Extentions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .WithMethods("POST", "GET", "PUT", "DELETE")
            .WithOrigins("http://localhost:3000/", "http://192.168.1.13/", "http://192.168.1.13:6870/")
           ;
        //policy.AllowAnyHeader()
        //    .AllowAnyMethod()
        //    .AllowAnyOrigin();
    });
});
// Add services to the container.

builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
{
    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
    //By default the below will be set to whatever the server culture is. 
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
    options.RequestCultureProviders = new List<IRequestCultureProvider>();
});
//امکان آپلود فایل با حجم بالا
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
    x.MultipartHeadersLengthLimit = int.MaxValue;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOurSwagger();
///پیکربندی سرویس ها
var configureTransient = new ConfigureTransient();
configureTransient.ConfigureTransients(builder.Services);



var app = builder.Build();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.DocExpansion(DocExpansion.None);
});
//}
app.UseStaticFiles();
app.UseRouting();
app.UseCors("ClientPermission");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
