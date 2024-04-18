using System;
using System.Collections.Generic;

namespace UrWaytoGoApp.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? CorreoUsuario { get; set; }

    public string? PasswordUsuario { get; set; }
}
