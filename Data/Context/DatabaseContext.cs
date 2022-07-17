using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace data.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AP_Alvarez_Ricardo_Alumno> AP_Alvarez_Ricardo_Alumno { get; set; }
        public virtual DbSet<AP_Alvarez_Ricardo_Curso> AP_Alvarez_Ricardo_Curso { get; set; }
        public virtual DbSet<AP_Alvarez_Ricardo_Nota> AP_Alvarez_Ricardo_Nota { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AP_Alvarez_Ricardo_Alumno>(entity =>
            {
                entity.Property(e => e.apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.fecha_nacimiento).HasColumnType("datetime");

                entity.Property(e => e.nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AP_Alvarez_Ricardo_Curso>(entity =>
            {
                entity.Property(e => e.descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AP_Alvarez_Ricardo_Nota>(entity =>
            {
                entity.Property(e => e.estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.final).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.parcial).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.practica1).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.practica2).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.practica3).HasColumnType("numeric(3, 1)");

                entity.HasOne(d => d.idalumnoNavigation)
                    .WithMany(p => p.AP_Alvarez_Ricardo_Nota)
                    .HasForeignKey(d => d.idalumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nota_alumno");

                entity.HasOne(d => d.idcursoNavigation)
                    .WithMany(p => p.AP_Alvarez_Ricardo_Nota)
                    .HasForeignKey(d => d.idcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nota_curso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
