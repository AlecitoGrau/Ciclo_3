using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Core.DTOs
{
	public class TareaDto
	{
		public int IdTarea { get; set; }

		public string? Titulo { get; set; } 

		public string? Descripcion { get; set; } 

		public DateTime? FechaTarea { get; set; }

		public int? IdUsuario { get; set; }
	}
}
