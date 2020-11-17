using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LMS.Core.Entities;

namespace LMS.Infrastructure.Data
{
    public partial class LMS2Context : DbContext
    {
        public LMS2Context()
        {
        }

        public LMS2Context(DbContextOptions<LMS2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Controlasistencia> Controlasistencia { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Inscripcion> Inscripcion { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=LMS2;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasIndex(e => e.IdTema)
                    .HasName("fkIdx_actividad_tema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.IdTema).HasColumnName("id_tema");

                entity.Property(e => e.Ponderacion)
                    .HasColumnName("ponderacion")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_actividad_curso");
            });

            modelBuilder.Entity<Adjunto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.Property(e => e.Nombrearchivo)
                    .IsRequired()
                    .HasColumnName("nombrearchivo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasColumnName("ubicacion")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasIndex(e => e.IdActividad)
                    .HasName("fkIdx_controlasistencia_actividad");

                entity.HasIndex(e => e.IdInscripcion)
                    .HasName("fkIdx_controlasistencia_inscripcion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCalificacion)
                    .HasColumnName("fecha_calificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdActividad).HasColumnName("id_actividad");

                entity.Property(e => e.IdInscripcion).HasColumnName("id_inscripcion");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_calificacion_actividad");

                entity.HasOne(d => d.IdInscripcionNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdInscripcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_calificacion_incripcion");
            });

            modelBuilder.Entity<Controlasistencia>(entity =>
            {
                entity.HasIndex(e => e.IdInscripcion)
                    .HasName("fkIdx_controlasistencia_inscripcion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Asistio)
                    .HasColumnName("asistio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAsistencia)
                    .HasColumnName("fecha_asistencia")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdInscripcion).HasColumnName("id_inscripcion");

                entity.HasOne(d => d.IdInscripcionNavigation)
                    .WithMany(p => p.Controlasistencia)
                    .HasForeignKey(d => d.IdInscripcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_controlasistencia_incripcion");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasIndex(e => e.IdInstructor)
                    .HasName("fkIdx_curso_instructor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("fecha_actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_curso_instructor");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasColumnName("apellido_materno")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnName("apellido_paterno")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_curso_incripcion");

                entity.HasIndex(e => e.IdEstudiante)
                    .HasName("fkIdx_estudiante_incripcion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("fecha_actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Inscripcion)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripcion_curso");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Inscripcion)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripcion_estudiante");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombresApellidos)
                    .IsRequired()
                    .HasColumnName("nombres_apellidos")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("valor")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasIndex(e => e.IdCurso)
                    .HasName("fkIdx_tema_curso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnName("fecha_actualizacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ponderacion)
                    .HasColumnName("ponderacion")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Tema)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tema_curso");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.IdRol)
                    .HasName("fkIdx_rol_usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rol_usuario");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

       //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
