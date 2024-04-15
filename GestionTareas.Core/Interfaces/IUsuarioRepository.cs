using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Core.Interfaces
{
	public interface IUsuarioRepository
	{
		Task<IEnumerable<Usuario>> GetUsuariosAll();
		Task<IEnumerable<Usuario>> GetUsuario(int id);
		Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario);
		Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDto usuario);
		Task<IEnumerable<Respuesta>> DeleteUsuario(int id);
	}
}
