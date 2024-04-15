using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Core.Entities;

public  partial class Usuario
{
    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
