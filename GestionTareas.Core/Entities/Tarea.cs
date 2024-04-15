using System;
using System.Collections.Generic;

namespace GestionTareas.Core.Entities;

public class Tarea
{
    public int IdTarea { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaTarea { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
