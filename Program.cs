using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Repositorios;
using SaberKids.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Instanciando os Repositorios e Interfaces*/
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio> ();
builder.Services.AddScoped<IMateriaRepositorio, MateriaRepositorio>();
builder.Services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();
builder.Services.AddScoped<ITurmaMateriaRepositorio, TurmaMateriaRepositorio>();
builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
builder.Services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();
builder.Services.AddScoped<ICartaoPagamentoRepositorio, CartaoPagamentoRepositorio>();
builder.Services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();

/*Adicionando a nossa string de conexão*/
builder.Services.AddDbContext<SaberKidsDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("SaberKids"))
);

var app = builder.Build();

//Ativa o Swagger em qualquer ambiente (inclui produção como no Somee)
app.MapSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    c.RoutePrefix = "swagger"; // acessível em /swagger/index.html
});

// Habilita CORS para toda a aplicação
app.UseCors("AllowAll"); // Aplica a política de CORS

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
