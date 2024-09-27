using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Runtime;
using Transportes_API.Models;
using Transportes_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//añadimos la base de dats al contxto 
builder.Services.AddDbContext<TransportesContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("sql_connection"),
    sqlServerOptionsAction: sqloption =>
    {
        sqloption.EnableRetryOnFailure(
            maxRetryCount: 20,
            maxRetryDelay: TimeSpan.FromSeconds(15),
            errorNumbersToAdd: null
            );
    })
);

//inyeccion de dependencias 
//añadimos el scope para conextar la interfaz con el servicio (clase)
builder.Services.AddScoped<ICamiones, CamionesService>();

//CORS
//CORS o Cross Origin Resource Sharing (compartir recursos entre diferentes origenes), es un mecanismo de seuridad utilizando en navegadores web para permitir que las oslicitudes de recursos (como imágenes, scripts, estilos, etc.) se realicen desde un dominio (origen) diferente al dominio
//en el que se encuentra la página web actual . en otras palabras, CORS es un conunto de reglas y politicas que permiten o restringen las solicitudes HTTP entre diferentes dominios.

builder.Services.AddCors(option =>
    option.AddPolicy("AllowAnyOrigin", //Añadimos una politica
        builder => builder.AllowAnyOrigin() //añadimos la politica depermitir cualquier origen 
                          .AllowAnyMethod() // Añadims la plitica de permitir cualquier metodo
                          .AllowAnyHeader() // Añadimos la politica de permitir cualquier cabecera
                    )
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//indicamos que la aplicacion utilice nuestra politica de CORS
app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
