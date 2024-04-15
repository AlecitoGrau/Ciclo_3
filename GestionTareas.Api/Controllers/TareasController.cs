using AutoMapper;
using GestionTareas.Api.Responses;
using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Core.Interfaces;
using GestionTareas.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TareasController : ControllerBase
	{
		private readonly ITareasServices _tareasServices;
		private readonly IMapper _mapper;

        public TareasController(ITareasServices tareasServices, IMapper mapper)
        {
            _tareasServices = tareasServices;
			_mapper = mapper;
        }

        [HttpGet]
		public async Task<IActionResult> GetTareas()
		{
			var tareas = await _tareasServices.GetTareas();
			var tareasDto = _mapper.Map<IEnumerable<TareaDto>>(tareas);

			return Ok(tareasDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTarea(int id)
		{
			var tarea = await _tareasServices.GetTarea(id);
			var tareaDto = _mapper.Map<IEnumerable<TareaDto>>(tarea);

			return Ok(tareaDto);
		}

		[HttpPost]
		public async Task<IActionResult> PostTarea(TareaDto tareas)
		{
			var tarea = await _tareasServices.InsertarTarea(tareas);
			var tareaDto = _mapper.Map<IEnumerable<Respuesta>>(tarea);
			var response = new ApiResponse<IEnumerable<Respuesta>>(tareaDto);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> PutTarea(TareaDto tareas)
		{
			var usuario = await _tareasServices.UpdateTarea(tareas);
			var tareaDto = _mapper.Map<IEnumerable<Respuesta>>(usuario);
			var response = new ApiResponse<IEnumerable<Respuesta>>(tareaDto);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var tarea = await _tareasServices.DeleteTarea(id);
			var tareaDto = _mapper.Map<IEnumerable<Respuesta>>(tarea);
			var response = new ApiResponse<IEnumerable<Respuesta>>(tareaDto);
			return Ok(response);
		}
	}
}
