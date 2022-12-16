using APITargetMark.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//pegar a string de conexão do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//registrar seeding service
builder.Services.AddScoped<SeedingService>();
//registrar o identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();


SeedData(app);

void SeedData(IHost app)
{
    //pegar o serviço de seeding
    var seedingService = app.Services.GetService<IServiceScopeFactory>();
    
    using (var scope = seedingService.CreateScope())
    {
        var services = scope.ServiceProvider.GetService<SeedingService>();
        //popular o banco de dados
        services.Seed();
    }
}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
