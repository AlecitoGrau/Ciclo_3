using System;
using System.Collections.Generic;
using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructure.Data;

public partial class PruebaSyspotecContext : DbContext
{
    public PruebaSyspotecContext()
    {
    }

    public PruebaSyspotecContext(DbContextOptions<PruebaSyspotecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Respuesta> Respuesta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TareaConfiguration());

        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }
}
