using emai.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServicio_Api, Servicio_Api>();
builder.Services.AddScoped<IServicioClase_Api, ClaseServicio_Api>();
builder.Services.AddScoped<IServicioMaestro_Api, MaestroServicio_Api>();
builder.Services.AddScoped<IServicioColegiatura_Api, ColegiaturaServicio_Api>();
builder.Services.AddScoped<IServicioDotacionDia_Api, DotacionDiaServicio_Api>();
builder.Services.AddScoped<IServicioGastosDia_Api, GastosDiaServicio_Api>();
builder.Services.AddScoped<IServicioNomina_Api, NominaServicio_Api>();
builder.Services.AddScoped<IServicioPago_Api, PagoServicio_Api>();
builder.Services.AddScoped<IServicioHorario_Api, HorarioServicio_Api>();
builder.Services.AddScoped<IServicioLibro_Api, LibroServicio_Api>();
builder.Services.AddScoped<IServicioHorarioVerano_Api, HorarioVeranoServicio_Api>();
builder.Services.AddScoped<IServicioEvento_Api, EventoServicio_Api>();
builder.Services.AddScoped<IServicioAsigClase_Api, AsigClaseServicio_Api>();
builder.Services.AddScoped<IServicioCooperaciones_Api, CooperacionesServicio_Api>();
builder.Services.AddScoped<IServicioPlanEstudios_Api, PlanEstudiosServicio_Api>();
builder.Services.AddScoped<IServicioAlumnos_Api, AlumnosServicio_Api>();




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
