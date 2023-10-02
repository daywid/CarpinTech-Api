using Microsoft.EntityFrameworkCore;
using MarcenariaApi.Models;
namespace MarcenariaApi.Data
{
    public class MarcenariaDbContext: DbContext
    {
        
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Agenda> Agendas { get; set; }
    public DbSet<Fornecedor> Fornecedores {get ;set;}
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Financeiro> Financeiros {get; set;}
    public DbSet<Relatorio> Relatorios {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlite("Data Source=marcenaria.db");   
    }

}

}
