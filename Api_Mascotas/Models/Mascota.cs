using System;
using System.Collections.Generic;

namespace Api_Mascotas.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public string? Descripcion { get; set; }
}
