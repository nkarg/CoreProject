using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class DataFutsalContext : DbContext
    {
        //public DataFutsalContext()
        //{
        //}

        public DataFutsalContext(DbContextOptions<DataFutsalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoJet> EstadoJet { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Jet> Jet { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<PrimeraRonda> PrimeraRonda { get; set; }
        public virtual DbSet<RolUsuario> RolUsuario { get; set; }
        public virtual DbSet<SegundaRonda> SegundaRonda { get; set; }
        public virtual DbSet<TerceraRonda> TerceraRonda { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer("Server=ASUSMAX\\SQLEXPRESS;Database=DataFutsal;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.Property(e => e.EscudoUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAfiliacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCorto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreLargo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoJet>(entity =>
            {
                entity.ToTable("EstadoJET");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Minuto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Equipo");

                entity.HasOne(d => d.IdJugadorNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Jugador");

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Partido");

                entity.HasOne(d => d.IdTorneoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdTorneo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Torneo");

                entity.HasOne(d => d.TipoEventoNavigation)
                    .WithMany(p => p.EventoNavigation)
                    .HasForeignKey(d => d.TipoEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_TipoEvento");
            });

            modelBuilder.Entity<Jet>(entity =>
            {
                entity.ToTable("JET");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Jet)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JET_Estado");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.Jet)
                    .HasForeignKey(d => d.IdEquipo)
                    .HasConstraintName("FK_JET_Equipo");

                entity.HasOne(d => d.IdJugadorNavigation)
                    .WithMany(p => p.Jet)
                    .HasForeignKey(d => d.IdJugador)
                    .HasConstraintName("FK_JET_Jugador");

                entity.HasOne(d => d.IdTorneoNavigation)
                    .WithMany(p => p.Jet)
                    .HasForeignKey(d => d.IdTorneo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_JET_Torneo");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasIndex(e => e.Dni)
                    .HasName("UQ__Jugador__C03085751367E606")
                    .IsUnique();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAfiliacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FotoUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmergencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.Property(e => e.FechaJugado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTorneoNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.IdTorneo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partido_Torneo");
            });

            modelBuilder.Entity<PrimeraRonda>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SegundaRonda>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TerceraRonda>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.Property(e => e.Evento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPrimeraRondaNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdPrimeraRonda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Torneo_PrimeraRonda");

                entity.HasOne(d => d.IdSegundaRondaNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdSegundaRonda)
                    .HasConstraintName("FK_Torneo_SegundaRonda");

                entity.HasOne(d => d.IdTerceraRondaNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdTerceraRonda)
                    .HasConstraintName("FK_Torneo_TerceraRonda");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Dni)
                    .HasName("UQ__Usuario__C0308575267ABA7A")
                    .IsUnique();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FotoUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_RolUsuario");
            });
        }
    }
}
