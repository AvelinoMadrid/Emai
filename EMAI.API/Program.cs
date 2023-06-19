using EMAI.API.MappingProfiles;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using System.Text;
using EMAI.Servicios;
using EMAI.Comun;
using EMAI.LND;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(

        CorsPolicyBuilder =>
        {
            CorsPolicyBuilder.SetIsOriginAllowed(hostName => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});


ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment enviroment = builder.Environment;


//// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwaggerGen();


// aca van las operaciones
builder.Services.AddScoped(typeof(IAlumnosOperaciones), f => OperationsFactory.ObtenerAlumnosOperaciones());
builder.Services.AddScoped(typeof(IClasesOperaciones), f => OperationsFactory.ObtenerClasesOperaciones());
builder.Services.AddScoped(typeof(IAsistenciaOperaciones),f=> OperationsFactory.ObtenerAsistenciaOperaciones());
builder.Services.AddScoped(typeof(IMaestrosOperaciones), f => OperationsFactory.ObtenerMaestrosOperaciones());
builder.Services.AddScoped(typeof(IHorariosOperaciones), f => OperationsFactory.ObtenerHorariosOperaciones());





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger(c =>
{
    //c.SerializeAsV2 = true;

});
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});



app.UseCors(options => options.SetIsOriginAllowed(hostName => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());


app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();


});
app.MapControllers();

app.Run();
