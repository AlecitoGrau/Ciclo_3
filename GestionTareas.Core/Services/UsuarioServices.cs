using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Core.Interfaces;

namespace GestionTareas.Core.Services
{
	public class UsuarioServices : IUsuarioServices
	{
		private readonly IUsuarioRepository _usuarioRepository;
		public UsuarioServices(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public async Task<IEnumerable<Usuario>> GetUsuariosAll()
		{
			var usuarios = await _usuarioRepository.GetUsuariosAll();
			return usuarios;
		}

		public async Task<IEnumerable<Usuario>> GetUsuario(int id)
		{
			var usuario = await _usuarioRepository.GetUsuario(id);
			return usuario;
		}

		public async Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario)
		{
			var insertUsuario = await _usuarioRepository.InsertarUsuario(usuario);
			return insertUsuario;
		}

		public async Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDto usuario) 
		{
			var updateUsuario = await _usuarioRepository.UpdateUsuario(usuario);
			return updateUsuario;
		}

		public async Task<IEnumerable<Respuesta>> DeleteUsuario(int id) 
		{
			var deleteUsuario = await _usuarioRepository.DeleteUsuario(id);
			return deleteUsuario;
		}
	}
}
