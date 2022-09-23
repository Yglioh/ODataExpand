using Microsoft.AspNetCore.OData;
using SandBoxOData;
using SandBoxOData.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDriverService, DriverService>();

builder.Services.AddControllers()
    .AddJsonOptions(jsonOptions => jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddOData(odataOptions =>
    {
        odataOptions.AddDataApiRoutingComponents();
        odataOptions.Filter().OrderBy().Expand().Select().Count().SetMaxTop(null);
    });
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseODataRouteDebug();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/healthcheck");
});

app.Run();
