using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Core.Exceptions;
using GestionTareas.Core.Interfaces;
using GestionTareas.Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructure.Repositories
{
	public class TareasRepository : ITareasRepository
	{
		private readonly PruebaSyspotecContext _context;

        public TareasRepository(PruebaSyspotecContext context)
        {
            _context = context;
        }

		public async Task<IEnumerable<Tarea>> GetTareas()
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("@opc", "LISTAR")
				};

				string sql = $"[dbo].[Sp_Tareas] @opc = @opc";
				var response = await _context.Tareas.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex)
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Tarea>> GetTarea(int id)
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("@opc", "LISTAR_ID"),
					new SqlParameter("@IdTarea", id)
				};

				string sql = "[dbo].[Sp_Tareas] @opc, @IdTarea = @IdTarea";
				var response = await _context.Tareas.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex)
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Respuesta>> InsertarTarea(TareaDto tarea)
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
				new SqlParameter("@opc", "CREAR"),
				new SqlParameter("@Titulo", tarea.Titulo),
				new SqlParameter("@Descripcion", tarea.Descripcion),
				new SqlParameter("@IdUsuario", tarea.IdUsuario)
				};

				string sql = $"[dbo].[Sp_Tareas] @opc = @opc, @Titulo = @Titulo, @Descripcion = @Descripcion, @IdUsuario = @IdUsuario";
				var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex)
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Respuesta>> UpdateTarea(TareaDto tarea)
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("opc", "ACTUALIZAR"),
					new SqlParameter("@Titulo", tarea.Titulo),
					new SqlParameter("@Descripcion", tarea.Descripcion),
					new SqlParameter("@IdUsuario", tarea.IdUsuario)
				};

				string sql = $"[dbo].[Sp_Tareas] @opc = @opc, @Titulo = @Titulo, @Descripcion = @Descripcion, @IdUsuario = @IdUsuario";
				var response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
				return response;
			}
			catch (Exception ex)
			{
				throw new BusinessException($"Error: {ex.Message}");
			}
		}

		public async Task<IEnumerable<Respuesta>> DeleteTarea(int id)
		{
			try
			{
				SqlParameter[] parameters = new[]
				{
					new SqlParameter("@opc", "ELIMINAR"),
					new SqlParameter("@IdTarea", id)
				};

				string sql = $"[dbo].[Sp_Tareas] @opc, @IdTarea = @IdTarea";
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
