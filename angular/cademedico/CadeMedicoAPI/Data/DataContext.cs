using System.Collections.Generic;
using CadeMedicoAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CadeMedicoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<MedicoModel> Medicos{get; set;}
        public DbSet<CidadeModel> Cidades{get; set;}
        public DbSet<EspecialidadeModel> Especialidades{get; set;}
        public DbSet<UsuarioModel> Usuarios{get; set;}
        public DbSet<PrivilegioModel> Privilegios{get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<MedicoModel>().HasData(new List<MedicoModel>(){
                new MedicoModel(1,"Marcos","3645655","909090"),
                new MedicoModel(2,"Luiz","123456","404050"),
                new MedicoModel(3,"Joao","098764","201050"),
                new MedicoModel(4,"Guilherme","501854","778899"),
                new MedicoModel(5,"Joares","439800","1155335")
            });
             builder.Entity<CidadeModel>().HasData(new List<CidadeModel>(){
                new CidadeModel(1,"Londrina","PR"),
                new CidadeModel(2,"Maringa","PR"),
                new CidadeModel(3,"Apucarana","PR"),
                new CidadeModel(4,"Assai","SP"),
                new CidadeModel(5,"São Paulo","SP"),
            });
            builder.Entity<EspecialidadeModel>().HasData(new List<EspecialidadeModel>(){
                new EspecialidadeModel(1,"Ortopedista"),
                new EspecialidadeModel(2,"Otorrinolaringologista"),
                new EspecialidadeModel(3,"Ginecologita"),
                new EspecialidadeModel(4,"Cardiologista"),
                new EspecialidadeModel(5,"Oftalmologista"),
                new EspecialidadeModel(6,"Clínico Geral"),
            });
            
            builder.Entity<PrivilegioModel>().HasData(new List<PrivilegioModel>(){
                new PrivilegioModel(1,"Master"),
                new PrivilegioModel(2,"ADM"),
                new PrivilegioModel(3,"USER"),
            });
            builder.Entity<UsuarioModel>().HasData(new List<UsuarioModel>(){
                new UsuarioModel(1,"Marcos","marc","1234",1),
                new UsuarioModel(2,"Carlos","carl","1234",2),
                new UsuarioModel(3,"fernando","fern","1234",3),
                new UsuarioModel(4,"joao","joao","1234",3),
                new UsuarioModel(5,"Jonathan","jona","1234",2),
            });
            builder.Entity<MedicoCidade>().HasKey(MC => new {MC.MedicoId,MC.CidadeId});
            builder.Entity<MedicoCidade>().HasData(new List<MedicoCidade>(){
                new MedicoCidade() {MedicoId = 1, CidadeId = 1},
                new MedicoCidade() {MedicoId = 2, CidadeId = 2},
                new MedicoCidade() {MedicoId = 3, CidadeId = 3},
                new MedicoCidade() {MedicoId = 4, CidadeId = 4},
                new MedicoCidade() {MedicoId = 5, CidadeId = 5},
            });
                builder.Entity<MedicoEspecialidade>().HasKey(MC => new {MC.MedicoId,MC.EspecialidadeId});
                builder.Entity<MedicoEspecialidade>().HasData(new List<MedicoEspecialidade>(){
                new MedicoEspecialidade() {MedicoId = 1, EspecialidadeId = 1},
                new MedicoEspecialidade() {MedicoId = 2, EspecialidadeId = 2},
                new MedicoEspecialidade() {MedicoId = 3, EspecialidadeId = 3},
                new MedicoEspecialidade() {MedicoId = 4, EspecialidadeId = 4},
                new MedicoEspecialidade() {MedicoId = 5, EspecialidadeId = 5},
            });

        }
    }
}
