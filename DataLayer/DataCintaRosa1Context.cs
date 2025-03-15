using System;
using System.Collections.Generic;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public partial class DataCintaRosa1Context : DbContext
{
    public DataCintaRosa1Context()
    {
    }

    public DataCintaRosa1Context(DbContextOptions<DataCintaRosa1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Antecedente> Antecedentes { get; set; }

    public virtual DbSet<Cama> Camas { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Diagnostico> Diagnosticos { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<EspecialidadxProfesional> EspecialidadxProfesionals { get; set; }

    public virtual DbSet<Localidad> Localidads { get; set; }

    public virtual DbSet<ObraSocial> ObraSocials { get; set; }

    public virtual DbSet<ObraSocialxPaciente> ObraSocialxPacientes { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<PacientesCama> PacientesCamas { get; set; }

    public virtual DbSet<Profesionale> Profesionales { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<SignosVitale> SignosVitales { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.HasKey(e => e.IdAntecedentes).HasName("PK__Antecede__86490FC89E0D5835");

            entity.Property(e => e.IdAntecedentes).HasColumnName("Id_Antecedentes");
            entity.Property(e => e.AEnfermedad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_Enfermedad");
            entity.Property(e => e.AInternaciones)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_Internaciones");
            entity.Property(e => e.AMotivoConsulta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_Motivo_Consulta");
            entity.Property(e => e.APersonales)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_Personales");
            entity.Property(e => e.IdConsultas).HasColumnName("Id_Consultas");
            entity.Property(e => e.NotasAdicionales)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Notas_Adicionales");

            entity.HasOne(d => d.IdConsultasNavigation).WithMany(p => p.Antecedentes)
                .HasForeignKey(d => d.IdConsultas)
                .HasConstraintName("FK__Anteceden__Id_Co__6754599E");
        });

        modelBuilder.Entity<Cama>(entity =>
        {
            entity.HasKey(e => e.NroCama).HasName("PK__Camas__08E0021CD010E58E");

            entity.Property(e => e.NroCama).HasColumnName("Nro_Cama");
            entity.Property(e => e.IdSalas).HasColumnName("Id_Salas");

            entity.HasOne(d => d.IdSalasNavigation).WithMany(p => p.Camas)
                .HasForeignKey(d => d.IdSalas)
                .HasConstraintName("FK__Camas__Id_Salas__6383C8BA");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__C658258883ED9E3D");

            entity.Property(e => e.IdConsulta).HasColumnName("Id_Consulta");
            entity.Property(e => e.FechaConsulta).HasColumnName("Fecha_consulta");
            entity.Property(e => e.HoraConsulta).HasColumnName("Hora_consulta");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.IdProfesional).HasColumnName("Id_Profesional");
            entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(400)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Consulta__Id_Pac__5AEE82B9");

            entity.HasOne(d => d.IdProfesionalNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdProfesional)
                .HasConstraintName("FK__Consulta__Id_Pro__5CD6CB2B");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__Consulta__Id_Ser__5BE2A6F2");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.HasKey(e => e.IdDiagnostico).HasName("PK__Diagnost__E38ACD1D8F1E2688");

            entity.Property(e => e.IdDiagnostico).HasColumnName("Id_Diagnostico");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IdConsulta).HasColumnName("Id_Consulta");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdConsulta)
                .HasConstraintName("FK__Diagnosti__Id_Co__60A75C0F");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__9B7935BFE75B486C");

            entity.ToTable("Especialidad");

            entity.Property(e => e.IdEspecialidad).HasColumnName("Id_Especialidad");
            entity.Property(e => e.NombreEspecialidad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nombre_especialidad");
        });

        modelBuilder.Entity<EspecialidadxProfesional>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EspecialidadxProfesional");

            entity.Property(e => e.IdEspecialidad).HasColumnName("Id_Especialidad");
            entity.Property(e => e.IdProfesional).HasColumnName("Id_Profesional");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany()
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK__Especiali__Id_Es__5EBF139D");

            entity.HasOne(d => d.IdProfesionalNavigation).WithMany()
                .HasForeignKey(d => d.IdProfesional)
                .HasConstraintName("FK__Especiali__Id_Pr__5DCAEF64");
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.IdLocalidad).HasName("PK__Localida__F3621E7F19DCA5A0");

            entity.ToTable("Localidad");

            entity.Property(e => e.IdLocalidad).HasColumnName("Id_Localidad");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Nombre_localidad");
        });

        modelBuilder.Entity<ObraSocial>(entity =>
        {
            entity.HasKey(e => e.IdObraSocial).HasName("PK__Obra_Soc__18DDA894BD9EB5A5");

            entity.ToTable("Obra_Social");

            entity.Property(e => e.IdObraSocial).HasColumnName("Id_Obra_social");
            entity.Property(e => e.NombreObraSocial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nombre_obra_social");
        });

        modelBuilder.Entity<ObraSocialxPaciente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Obra_SocialxPaciente");

            entity.Property(e => e.IdObraSocial).HasColumnName("Id_Obra_social");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");

            entity.HasOne(d => d.IdObraSocialNavigation).WithMany()
                .HasForeignKey(d => d.IdObraSocial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Obra_Soci__Id_Ob__5812160E");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany()
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Obra_Soci__Id_Pa__59063A47");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__032CD4A6EF46D513");

            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_nacimiento");
            entity.Property(e => e.IdLocalidad).HasColumnName("Id_Localidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdLocalidad)
                .HasConstraintName("FK__Pacientes__Id_Lo__59FA5E80");
        });

        modelBuilder.Entity<PacientesCama>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaEgreso)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Egreso");
            entity.Property(e => e.FechaOcupacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ocupacion");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.NroCama).HasColumnName("Nro_Cama");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany()
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Pacientes__Id_Pa__656C112C");

            entity.HasOne(d => d.NroCamaNavigation).WithMany()
                .HasForeignKey(d => d.NroCama)
                .HasConstraintName("FK__Pacientes__Nro_C__6477ECF3");
        });

        modelBuilder.Entity<Profesionale>(entity =>
        {
            entity.HasKey(e => e.IdProfesional).HasName("PK__Profesio__9E04403F7943C198");

            entity.Property(e => e.IdProfesional).HasColumnName("Id_Profesional");
            entity.Property(e => e.ApellidoProfesional)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_profesional");
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.IdRoles).HasColumnName("Id_Roles");
            entity.Property(e => e.NombreProfesional)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nombre_profesional");

            entity.HasOne(d => d.IdRolesNavigation).WithMany(p => p.Profesionales)
                .HasForeignKey(d => d.IdRoles)
                .HasConstraintName("FK__Profesion__Id_Ro__66603565");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistros).HasName("PK__Registro__F9EE08E879FDDF4C");

            entity.Property(e => e.IdRegistros).HasColumnName("Id_Registros");
            entity.Property(e => e.IdRegistroAfectado).HasColumnName("Id_Registro_Afectado");
            entity.Property(e => e.Operacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Tabla_Afectada");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRoles).HasName("PK__Roles__2610294B778C0D01");

            entity.Property(e => e.IdRoles).HasColumnName("Id_Roles");
            entity.Property(e => e.Rol)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.IdSalas).HasName("PK__Salas__076762188CBFDC25");

            entity.Property(e => e.IdSalas)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Salas");
            entity.Property(e => e.IdServicios).HasColumnName("Id_Servicios");
            entity.Property(e => e.NombreSala)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Nombre_Sala");

            entity.HasOne(d => d.IdSalasNavigation).WithOne(p => p.Sala)
                .HasForeignKey<Sala>(d => d.IdSalas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Salas__Id_Salas__68487DD7");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicios).HasName("PK__Servicio__484E5DFF0BFDC909");

            entity.Property(e => e.IdServicios).HasColumnName("Id_Servicios");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nombre_servicio");
        });

        modelBuilder.Entity<SignosVitale>(entity =>
        {
            entity.HasKey(e => e.IdSigno).HasName("PK__Signos_V__EFF6D61F8776AE55");

            entity.ToTable("Signos_Vitales");

            entity.Property(e => e.IdSigno).HasColumnName("Id_Signo");
            entity.Property(e => e.Diastolica).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Diuresis).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FrecuenciaCardiaca)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Frecuencia_cardiaca");
            entity.Property(e => e.FrecuenciaRespiratoria)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Frecuencia_respiratoria");
            entity.Property(e => e.IdConsulta).HasColumnName("Id_Consulta");
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Sistolica).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.SignosVitales)
                .HasForeignKey(d => d.IdConsulta)
                .HasConstraintName("FK__Signos_Vi__Id_Co__619B8048");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratmientos).HasName("PK__Tratamie__74EC2450EDAC9948");

            entity.Property(e => e.IdTratmientos).HasColumnName("Id_Tratmientos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IdConsulta).HasColumnName("Id_Consulta");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdConsulta)
                .HasConstraintName("FK__Tratamien__Id_Co__5FB337D6");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurnos).HasName("PK__Turnos__2299387D4663EE72");

            entity.Property(e => e.IdTurnos).HasColumnName("Id_Turnos");
            entity.Property(e => e.DatosPacienteNoRegistrado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Datos_Paciente_No_Registrado");
            entity.Property(e => e.EsPacienteRegistrado)
                .HasDefaultValue(true)
                .HasColumnName("Es_Paciente_Registrado");
            entity.Property(e => e.FechaTurno).HasColumnName("Fecha_turno");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
            entity.Property(e => e.TipoDeConsulta)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_consulta");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__Turnos__Id_Pacie__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
