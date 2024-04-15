using AutoMapper;
using GestionTareas.Api.Responses;
using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using GestionTareas.Core.Interfaces;
using GestionTareas.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioServices _usuarioServices;
		private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServices usuarioServices, IMapper mapper)
        {
            _usuarioServices = usuarioServices;
			_mapper = mapper;
        }

        [HttpGet]
		public async Task<IActionResult> GetUsuarios() 
		{
			var usuarios = await _usuarioServices.GetUsuariosAll();
			var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

			return Ok(usuariosDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUsuario(int id)
		{
			var usuario = await _usuarioServices.GetUsuario(id);
			var usuarioDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuario);

			return Ok(usuarioDto);
		}

		[HttpPost]
		public async Task<IActionResult> PostUsuario(UsuarioDto usuarios)
		{
			var usuario = await _usuarioServices.InsertarUsuario(usuarios);
			var usuarioDto = _mapper.Map<IEnumerable<Respuesta>>(usuario);
			var response = new ApiResponse<IEnumerable<Respuesta>>(usuarioDto);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> PutUsuario(UsuarioDto usuarioDto)
		{
			var usuario = await _usuarioServices.UpdateUsuario(usuarioDto);
			var usuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(usuario);
			var response = new ApiResponse<IEnumerable<Respuesta>>(usuarioDTO);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var usuario = await _usuarioServices.DeleteUsuario(id);
			var usuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(usuario);
			var response = new ApiResponse<IEnumerable<Respuesta>>(usuarioDTO);
			return Ok(response);
		}
	}
}
