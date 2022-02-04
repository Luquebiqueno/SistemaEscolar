using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistemaEscolar.Application.ServiceApplications;
using SistemaEscolar.Domain.Acessor;
using SistemaEscolar.Domain.Helpers;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Domain.Interfaces.Application;
using SistemaEscolar.Domain.Interfaces.Repository;
using SistemaEscolar.Domain.Interfaces.Service;
using SistemaEscolar.Domain.Services;
using SistemaEscolar.Domain.Services.Utils;
using SistemaEscolar.Repository.Context;
using SistemaEscolar.Repository.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SistemaEscolarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableDetailedErrors());
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IUnitOfWork<SistemaEscolarContext>, SistemaEscolarContext>();
builder.Services.AddScoped<IUsuarioLogado, UsuarioLogado>();
builder.Services.AddScoped<IUser, User>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//Repository
builder.Services.AddTransient(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
builder.Services.AddScoped<IAutenticacaoRepository, AutenticacaoRepository>();
builder.Services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));
builder.Services.AddScoped(typeof(IAlunoRepository<>), typeof(AlunoRepository<>));

//Service
builder.Services.AddTransient(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();
builder.Services.AddScoped(typeof(IUsuarioService<>), typeof(UsuarioService<>));
builder.Services.AddScoped(typeof(IAlunoService<>), typeof(AlunoService<>));

//Application
builder.Services.AddTransient(typeof(IApplicationBase<,,>), typeof(ApplicationBase<,,>));
builder.Services.AddScoped<IAutenticacaoApplication, AutenticacaoApplication>();
builder.Services.AddScoped(typeof(IUsuarioApplication<>), typeof(UsuarioApplication<>));
builder.Services.AddScoped(typeof(IAlunoApplication<>), typeof(AlunoApplication<>));

//Inicio Autenticação
var tokenConfiguration = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
builder.Services.AddSingleton(tokenConfiguration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfiguration.Issuer,
        ValidAudience = tokenConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

//Fim Autenticação

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
