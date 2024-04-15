using GestionTareas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Infraestructure.Data.Configurations
{
	public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuarios");

			builder.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF979FA34C90");

			builder.Property(e => e.CorreoElectronico)
				.HasMaxLength(50)
				.IsUnicode(false);
			builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
			builder.Property(e => e.Nombre)
				.HasMaxLength(50)
				.IsUnicode(false);
		}
	}
}
