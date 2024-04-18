using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UrWaytoGoApp.Models;
using UrWaytoGoApp.Servicios.Contrato;

namespace UrWaytoGoApp.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
            private readonly UrWaytoGoContext _dbContext;

            public UsuarioService(UrWaytoGoContext dbContext) 
            {
                _dbContext = dbContext;
            }
            public async Task<Usuario> GetUsuarios(string correo, string clave)
            {
                Usuario usuarioEncontrado = await _dbContext.Usuarios.Where(u => u.CorreoUsuario == correo && u.PasswordUsuario == clave)
                    .FirstOrDefaultAsync();

                return usuarioEncontrado;
            }

            public async Task<Usuario> SaveUsuario(Usuario modelo)
            {
                _dbContext.Usuarios.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
    }
}
