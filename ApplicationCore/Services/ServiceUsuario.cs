using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public IEnumerable<Usuario> GetUsuarios()
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarios();
        }

        public Usuario GetUsuarioByUsername(string username)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarioByUsername(username);
        }

        public Usuario GetUsuario(string username, string clave)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuario(username, clave);

        }

    }
}
