using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using PruebaTecnica.Data;
using PruebaTecnica.Services;
using PruebaTecnica.Repositories;
using PruebaTecnica.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la Base de Datos (Lee la cadena de conexi�n del appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuraci�n de Dependencias (Inyecci�n de Dependencias)
builder.Services.AddScoped<IPersonasService, PersonasService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPersonasRepository, PersonasRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

// Configuraci�n de CORS (Permite solicitudes desde el frontend Angular en http://localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy => policy.WithOrigins("http://localhost:4200") // Especifica la URL del frontend Angular
                        .AllowAnyMethod()   // Permite cualquier m�todo HTTP (GET, POST, PUT, DELETE, etc.)
                        .AllowAnyHeader()   // Permite cualquier encabezado
                        .AllowCredentials()); // Permite el env�o de cookies o credenciales si es necesario
});

// Configuraci�n de Autenticaci�n y JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Puedes cambiar a true en producci�n
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

// Configuraci�n de Swagger con Autenticaci�n JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaTecnica API", Version = "v1" });

    // Agrega configuraci�n para JWT en Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Ingrese el token en el formato 'Bearer {token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] {} }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configuraci�n del Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy"); // Habilita CORS
app.UseAuthentication();   // Habilita la Autenticaci�n JWT
app.UseAuthorization();    // Habilita la Autorizaci�n

app.MapControllers();
app.Run();
