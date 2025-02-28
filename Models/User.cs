using System;
using System.Collections.Generic;

namespace VulnerabilidadProyecto.Models;

public partial class User
{
    public int Personid { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasena { get; set; }
}
