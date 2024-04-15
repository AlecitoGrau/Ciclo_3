using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Core.DTOs
{
	public partial class UsuarioDto
	{
		
		public int? IdUsuario { get; set; }

		public string? Nombre { get; set; }

		public string? CorreoElectronico { get; set; }

		public DateTime FechaCreacion { get; set; }
	}
}
