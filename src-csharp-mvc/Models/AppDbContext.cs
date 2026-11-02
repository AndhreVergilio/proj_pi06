// Models/AppDbContext.cs — Entidades + Contexto SQLite
using Microsoft.EntityFrameworkCore;

namespace ClinicaMvc.Models;

public class Cliente {
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Telefone { get; set; } = "";
    public string Cpf { get; set; } = "";
    public string CriadoEm { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
}

public class Procedimento {
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public string Tipo { get; set; } = "";
    public string DataProcedimento { get; set; } = "";
    public string DataRetorno { get; set; } = "";
    public string Observacoes { get; set; } = "";
    public string FotoBase64 { get; set; } = ""; // Armazena a foto diretamente no SQLite
    public bool RetornoConcluido { get; set; }
}

public class AppDbContext : DbContext {
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Procedimento> Procedimentos => Set<Procedimento>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=clinica.db");
}
