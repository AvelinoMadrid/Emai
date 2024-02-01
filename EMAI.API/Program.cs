using EMAI.API.MappingProfiles;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using System.Text;
using EMAI.Servicios;
using EMAI.Comun;
using EMAI.LND;
using Microsoft.OpenApi.Models;

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "/swagger/v1/swagger.json", Version = "v1" });
});


// aca van las operaciones
builder.Services.AddScoped(typeof(IAlumnosOperaciones), f => OperationsFactory.ObtenerAlumnosOperaciones());
builder.Services.AddScoped(typeof(IClasesOperaciones), f => OperationsFactory.ObtenerClasesOperaciones());
builder.Services.AddScoped(typeof(IAsistenciaOperaciones),f=> OperationsFactory.ObtenerAsistenciaOperaciones());
builder.Services.AddScoped(typeof(IMaestrosOperaciones), f => OperationsFactory.ObtenerMaestrosOperaciones());
builder.Services.AddScoped(typeof(IHorariosOperaciones), f => OperationsFactory.ObtenerHorariosOperaciones());
builder.Services.AddScoped(typeof(INominaOperaciones), f => OperationsFactory.ObtenerNominaOperaciones());
builder.Services.AddScoped(typeof(ICooperacionesOperaciones), f => OperationsFactory.ObtenerCooperacionesOperaciones());
builder.Services.AddScoped(typeof(IDotacionDiaOperaciones), f => OperationsFactory.ObtenerDotacionDiaOperaciones());
builder.Services.AddScoped(typeof(IUsuariosOperaciones), f => OperationsFactory.ObtenerUsuariosOperaciones());
builder.Services.AddScoped(typeof(IPromosionesOperaciones), f => OperationsFactory.ObtenerPromocionesOperaciones());
builder.Services.AddScoped(typeof(IPagosOperaciones), f => OperationsFactory.ObtenerPagosOperaciones());
builder.Services.AddScoped(typeof(IGastosOperaciones), f => OperationsFactory.ObtenerGastosOperaciones());
builder.Services.AddScoped(typeof(IGastosDiaOperaciones), f => OperationsFactory.ObtenerGastosDiaOperaciones());
builder.Services.AddScoped(typeof(IColegiaturaOperaciones), f => OperationsFactory.ObtenerColegiaturaOperaciones());
builder.Services.AddScoped(typeof(IAdicionalesOperaciones), f => OperationsFactory.ObtenerAdicionalesOperaciones());
builder.Services.AddScoped(typeof(ILibrosOperaciones), f => OperationsFactory.ObtenerLibrosOperaciones());
builder.Services.AddScoped(typeof(IHorariosVeranoOperaciones), f => OperationsFactory.ObtenerHorariosVeranoOperaciones());
builder.Services.AddScoped(typeof(IEventosOperaciones), f => OperationsFactory.ObtenerEventosOperaciones());
builder.Services.AddScoped(typeof(IAsignacionClaseOperaciones), f => OperationsFactory.ObtenerAsignacionClaseOperaciones());
builder.Services.AddScoped(typeof(IPrograma5sOperaciones), f => OperationsFactory.ObtenerPrograma5sOperaciones());
builder.Services.AddScoped(typeof(IHorasOperaciones), f => OperationsFactory.ObtenerHorasOperaciones());



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

app.UseDeveloperExceptionPage();

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


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
app.UseStaticFiles();

app.Run();
