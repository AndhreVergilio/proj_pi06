// Program.cs — Inicialização enxuta com criação automática do banco SQLite (clinica.db)
using ClinicaMvc.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Garante que o arquivo clinica.db e as tabelas Clientes e Procedimentos existam
using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clinica}/{action=Index}/{id?}"
);
app.Run();
