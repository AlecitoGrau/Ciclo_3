using FluentValidation;
using GestionTareas.Core.DTOs;
using GestionTareas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Infraestructure.Validators
{
	public class UsuarioValidators : AbstractValidator<UsuarioDto>
	{
        public UsuarioValidators()
        {
            RuleFor(usuario => usuario.Nombre)
                .NotNull()
                .NotEmpty();
		}
    }
}
