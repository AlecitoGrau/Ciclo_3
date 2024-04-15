using GestionTareas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionTareas.Infraestructure.Data.Configurations
{
	public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
	{
		public void Configure(EntityTypeBuilder<Tarea> builder)
		{
			builder.ToTable("Tareas");

			builder.HasKey(e => e.IdTarea).HasName("PK__Tareas__EADE9098FE83B450");

			builder.Property(e => e.Descripcion)
				.HasMaxLength(500)
				.IsUnicode(false);
			builder.Property(e => e.FechaTarea).HasColumnType("datetime");
			builder.Property(e => e.Titulo)
				.HasMaxLength(100)
				.IsUnicode(false);

			builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tareas)
				.HasForeignKey(d => d.IdUsuario)
				.HasConstraintName("FK_Usuario");
		}
	}
}
