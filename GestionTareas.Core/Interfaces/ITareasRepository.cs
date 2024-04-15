using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Core.Interfaces
{
	public interface ITareasRepository
	{
		Task<IEnumerable<Tarea>> GetTareas();
		Task<IEnumerable<Tarea>> GetTarea(int id);
		Task<IEnumerable<Respuesta>> InsertarTarea(TareaDto tarea);
		Task<IEnumerable<Respuesta>> UpdateTarea(TareaDto tarea);
		Task<IEnumerable<Respuesta>> DeleteTarea(int id);
	}
}
