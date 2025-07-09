using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Proyecto_Cine.Models;

public partial class SarmiMovieDbContext : DbContext
{
    public SarmiMovieDbContext()
    {
    }

    public SarmiMovieDbContext(DbContextOptions<SarmiMovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<AsientosFuncion> AsientosFuncions { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    public virtual DbSet<Funcione> Funciones { get; set; }

    public virtual DbSet<MensajesContacto> MensajesContactos { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PreciosFuncion> PreciosFuncions { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<TiposBoleto> TiposBoletos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=SarmiMovieDB;user=Sarmiento;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asientos");

            entity.HasIndex(e => e.SalaId, "sala_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fila)
                .HasMaxLength(5)
                .HasColumnName("fila");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.SalaId).HasColumnName("sala_id");

            entity.HasOne(d => d.Sala).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.SalaId)
                .HasConstraintName("asientos_ibfk_1");
        });

        modelBuilder.Entity<AsientosFuncion>(entity =>
        {
            entity.HasKey(e => new { e.FuncionId, e.AsientoId })
                .HasName("PRIMARY");

            entity.ToTable("asientos_funcion");

            entity.Property(e => e.FuncionId).HasColumnName("funcion_id");
            entity.Property(e => e.AsientoId).HasColumnName("asiento_id");
            entity.Property(e => e.Disponible)
                .HasDefaultValueSql("'1'")
                .HasColumnName("disponible");

            entity.HasOne(d => d.Funcion).WithMany(p => p.AsientosFuncions)
                .HasForeignKey(d => d.FuncionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asientos_funcion_ibfk_1");

            entity.HasOne(d => d.Asiento).WithMany()
                .HasForeignKey(d => d.AsientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asientos_funcion_ibfk_asiento");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entradas");

            entity.HasIndex(e => e.ReservaId, "reserva_id");
            entity.HasIndex(e => e.TipoBoletoId, "tipo_boleto_id");
            entity.HasIndex(e => e.AsientoId, "asiento_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AsientoId).HasColumnName("asiento_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(6, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");
            entity.Property(e => e.TipoBoletoId).HasColumnName("tipo_boleto_id");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("entradas_ibfk_1");

            entity.HasOne(d => d.TipoBoleto).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.TipoBoletoId)
                .HasConstraintName("entradas_ibfk_2");

            entity.HasOne(d => d.Asiento).WithMany()
                .HasForeignKey(d => d.AsientoId)
                .HasConstraintName("entradas_ibfk_asiento");
        });

        modelBuilder.Entity<Funcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funciones");

            entity.HasIndex(e => e.PeliculaId, "pelicula_id");

            entity.HasIndex(e => e.SalaId, "sala_id");

            entity.HasIndex(e => e.SucursalId, "sucursal_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Formato)
                .HasMaxLength(20)
                .HasColumnName("formato");
            entity.Property(e => e.HoraFin)
                .HasColumnType("time")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .HasColumnName("idioma");
            entity.Property(e => e.PeliculaId).HasColumnName("pelicula_id");
            entity.Property(e => e.SalaId).HasColumnName("sala_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("funciones_ibfk_1");

            entity.HasOne(d => d.Sala).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.SalaId)
                .HasConstraintName("funciones_ibfk_2");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Funciones)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("funciones_ibfk_3");
        });

        modelBuilder.Entity<MensajesContacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mensajes_contacto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("metodos_pago");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.MetodoPagoId, "metodo_pago_id");

            entity.HasIndex(e => e.ReservaId, "reserva_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Detalle)
                .HasMaxLength(150)
                .HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.MetodoPagoId).HasColumnName("metodo_pago_id");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Referencia)
                .HasMaxLength(100)
                .HasColumnName("referencia");
            entity.Property(e => e.ReservaId).HasColumnName("reserva_id");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("pagos_ibfk_2");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("pagos_ibfk_1");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("peliculas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activa)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activa");
            entity.Property(e => e.Clasificacion)
                .HasMaxLength(10)
                .HasColumnName("clasificacion");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .HasColumnName("genero");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .HasColumnName("idioma");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<PreciosFuncion>(entity =>
        {
            entity.HasKey(e => new { e.FuncionId, e.TipoBoletoId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("precios_funcion");

            entity.HasIndex(e => e.TipoBoletoId, "tipo_boleto_id");

            entity.Property(e => e.FuncionId).HasColumnName("funcion_id");
            entity.Property(e => e.TipoBoletoId).HasColumnName("tipo_boleto_id");
            entity.Property(e => e.Precio)
                .HasPrecision(6, 2)
                .HasColumnName("precio");

            entity.HasOne(d => d.Funcion).WithMany(p => p.PreciosFuncions)
                .HasForeignKey(d => d.FuncionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("precios_funcion_ibfk_1");

            entity.HasOne(d => d.TipoBoleto).WithMany(p => p.PreciosFuncions)
                .HasForeignKey(d => d.TipoBoletoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("precios_funcion_ibfk_2");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refresh_tokens");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Token)
                .HasColumnType("text")
                .HasColumnName("token");
            entity.Property(e => e.Valido)
                .HasDefaultValueSql("'1'")
                .HasColumnName("valido");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("refresh_tokens_ibfk_1");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.FuncionId, "funcion_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(100)
                .HasColumnName("apellido_cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(150)
                .HasColumnName("correo_cliente");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.FuncionId).HasColumnName("funcion_id");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.Total)
                .HasPrecision(6, 2)
                .HasColumnName("total");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Funcion).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FuncionId)
                .HasConstraintName("reservas_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("reservas_ibfk_1");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("salas");

            entity.HasIndex(e => e.IdSucursal, "id_sucursal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("salas_ibfk_1");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sucursales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(200)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<TiposBoleto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipos_boleto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Telefono, "telefono").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.ContrasenaHash)
                .HasColumnType("text")
                .HasColumnName("contrasena_hash");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasColumnType("enum('Cliente','Admin')")
                .HasColumnName("rol");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}