using AutoMapper;
using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Infraestructure.Mappings
{
	public class AutomapperProfile : Profile
	{
        public AutomapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
			CreateMap<UsuarioDto, Usuario>();
			CreateMap<Tarea, TareaDto>();
			CreateMap<TareaDto, Tarea>();
		}
    }
}
