using FluentValidation;
using GestionTareas.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Infraestructure.Validators
{
	public class TareaValidators : AbstractValidator<TareaDto>
	{
        public TareaValidators()
        {
            RuleFor(tarea => tarea.Descripcion)
                 .NotNull()
                 .NotEmpty();

            RuleFor(tarea => tarea.Titulo)
                .NotNull();
        }
    }
}
