using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;

namespace GestionTareas.Core.Interfaces
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> GetUsuariosAll();
        Task<IEnumerable<Usuario>> GetUsuario(int id);

		Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario);
        Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDto usuario);
        Task<IEnumerable<Respuesta>> DeleteUsuario(int id);
	}
}