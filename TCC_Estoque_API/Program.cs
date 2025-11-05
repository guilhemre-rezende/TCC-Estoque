using Microsoft.EntityFrameworkCore; // Adicionado para fazer o Entity Framework Core funcionar
using TCC_Estoque_API.Data; // Adicionado para o seu ApplicationDbContext funcionar
using TCC_Estoque_API.Services; // Adicionado para o serviço de Autenticação/Hash funcionar

var builder = WebApplication.CreateBuilder(args);



//  Configurar a Conexão com o Banco de Dados SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registra o DbContext e usa a string de conexão definida no appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//  Registrar o Serviço de Autenticação/Hash
// Isso permite que o Controller (que ainda vamos criar) use este serviço
builder.Services.AddScoped<IAuthService, AuthService>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Adicionado: Redireciona para HTTPS

app.UseAuthorization();

app.MapControllers();

app.Run();
