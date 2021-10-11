using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class ProyectoIPSDataBaseContext : DbContext
    {
        public ProyectoIPSDataBaseContext()
        {
        }

        public ProyectoIPSDataBaseContext(DbContextOptions<ProyectoIPSDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CitaMedica> CitaMedicas { get; set; }
        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Convenio> Convenios { get; set; }
        public virtual DbSet<Ip> Ips { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<MedicoPorSede> MedicoPorSedes { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Sede> Sedes { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Sintoma> Sintomas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SBG0MI3; Database=ProyectoIPSDataBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CitaMedica>(entity =>
            {
                entity.ToTable("CitaMedica");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCita).HasColumnType("datetime");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitaMedica_Medico");

                entity.HasOne(d => d.IdMedico1)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitaMedica_Paciente");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CitaMedica_Sede");

                entity.HasOne(d => d.IdSintomasNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.IdSintomas)
                    .HasConstraintName("FK_CitaMedica_Sintomas");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreCiudad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.ToTable("Convenio");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Horario).HasColumnType("date");
            });

            modelBuilder.Entity<Ip>(entity =>
            {
                entity.ToTable("IPS");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreIps)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("NombreIPS")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.Ips)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IPS_Sede");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("Medico");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CodigoMedico)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medico_Persona");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK_Medico_Servicios");
            });

            modelBuilder.Entity<MedicoPorSede>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MedicoPorSede");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MdicoPorSede_Medico");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MdicoPorSede_Sede");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Paciente");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.HasOne(d => d.IdConvenioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdConvenio)
                    .HasConstraintName("FK_Paciente_Convenio");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.ToTable("Sede");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DireccionSede)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NitSede)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombreSede)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Sedes)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_Ciudad");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sintoma>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
