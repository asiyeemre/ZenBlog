using Scalar.AspNetCore;
using ZenBlog.API.CustomMiddlewares;
using ZenBlog.API.EndpointRegistration;
using ZenBlog.Application.Extensions;
using ZenBlog.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication(builder.Configuration); //builder configuration ý buraya ekledik çünkü jwt token options ý application katmanýnda kullanýyoruz.builder configuration þu anlama gelir : "Uygulama yapýlandýrma ayarlarýný al ve bu ayarlarý uygulamanýn servis koleksiyonuna ekle."
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(cfg =>
    {
        cfg.WithOrigins("http://localhost:4200") //Ýzin verilen originleri belirtiyoruz.
           .AllowAnyHeader() //Herhangi bir headera izin ver
           .AllowAnyMethod() //Herhangi bir metoda izin ver
           .AllowCredentials(); //Kimlik bilgilerine izin ver
    });
  
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<CustomExceptionHandlingMiddleWare>();
app.UseHttpsRedirection();
app.UseCors(); //CORS politikalarýný etkinleþtirir.

app.UseAuthentication(); //Kimlik doðrulama iþlemlerini etkinleþtirir.
app.UseAuthorization(); //Yetkilendirme iþlemlerini etkinleþtirir.

app.MapControllers();
app.MapGroup("/api").
    RegisterEndpoints();

app.Run();
