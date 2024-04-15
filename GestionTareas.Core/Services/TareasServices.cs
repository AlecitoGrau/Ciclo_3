using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Core.Services
{
	public class TareasServices : ITareasServices
	{
		private readonly ITareasRepository _tareasRepository;
        public TareasServices(ITareasRepository tareasRepository)
        {
            _tareasRepository = tareasRepository;
        }

		public async Task<IEnumerable<Tarea>> GetTareas()
		{
			var tareas = await _tareasRepository.GetTareas();
			return tareas;
		}

		public async Task<IEnumerable<Tarea>> GetTarea(int id)
		{
			var tarea = await _tareasRepository.GetTarea(id);
			return tarea;
		}

		public async Task<IEnumerable<Respuesta>> InsertarTarea(TareaDto tarea)
		{
			var insertTarea = await _tareasRepository.InsertarTarea(tarea);
			return insertTarea;
		}

		public async Task<IEnumerable<Respuesta>> UpdateTarea(TareaDto tarea)
		{
			var updateTarea = await _tareasRepository.UpdateTarea(tarea);
			return updateTarea;
		}

		public async Task<IEnumerable<Respuesta>> DeleteTarea(int id)
		{
			var deleteTarea = await _tareasRepository.DeleteTarea(id);
			return deleteTarea;
		}

	}
}
