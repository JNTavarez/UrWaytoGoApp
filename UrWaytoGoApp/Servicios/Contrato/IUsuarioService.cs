using Microsoft.EntityFrameworkCore;
using UrWaytoGoApp.Models;

namespace UrWaytoGoApp.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
