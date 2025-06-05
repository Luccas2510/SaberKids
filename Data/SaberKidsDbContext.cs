using Microsoft.EntityFrameworkCore;
using SaberKids.Data.Map;
using SaberKids.Models;

namespace SaberKids.Data
{
    public class SaberKidsDbContext : DbContext
    {
        public SaberKidsDbContext(DbContextOptions<SaberKidsDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<MateriaModel> Materias { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }
        public DbSet<TurmaMateriaModel> TurmasMaterias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaMateriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
