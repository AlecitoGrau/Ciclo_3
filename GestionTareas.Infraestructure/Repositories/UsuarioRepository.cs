using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Core.Exceptions;
using GestionTareas.Core.Interfaces;
using GestionTareas.Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GestionTareas.Infraestructure.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly PruebaSyspotecContext _context;
        public UsuarioRepository(PruebaSyspotecContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAll()
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("@opc", "LISTAR")
				};

				string sql = $"dbo.Sp_Usuarios @opc = @opc";
				var response = await _context.Usuarios.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex) 
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Usuario>> GetUsuario(int id)
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("@opc", "LISTAR_ID"),
					new SqlParameter("@IdUsuario", id)
				};

				string sql = "[dbo].[Sp_Usuarios] @opc, @IdUsuario = @IdUsuario";
				var response = await _context.Usuarios.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex) 
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Respuesta>> InsertarUsuario(UsuarioDto usuario)
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
				new SqlParameter("@opc", "CREAR"),
				new SqlParameter("@Nombre", usuario.Nombre),
				new SqlParameter("@CorreoElectronico", usuario.CorreoElectronico)
				};

				string sql = $"[dbo].[Sp_Usuarios] @opc = @opc, @Nombre = @Nombre, @CorreoElectronico = @CorreoElectronico";
				var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex)
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDto usuario) 
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("opc", "ACTUALIZAR"),
					new SqlParameter("@IdUsuario", usuario.IdUsuario),
					new SqlParameter("@Nombre", usuario.Nombre),
					new SqlParameter("@CorreoElectronico", usuario.CorreoElectronico)
				};

				string sql = $"[dbo].[Sp_Usuarios] @opc = @opc, @IdUsuario = @IdUsuario, @Nombre = @Nombre, @CorreoElectronico = @CorreoElectronico";
				var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex) 
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Respuesta>> DeleteUsuario(int id) 
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("@opc", "ELIMINAR"),
					new SqlParameter("@IdUsuario", id)
				};

				string sql = $"[dbo].[Sp_Usuarios] @opc, @IdUsuario = @IdUsuario";
				var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex) 
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}
	}
}
