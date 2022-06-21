using ApplicationCore.Utils;
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
            string crytpPasswd = Cryptography.EncrypthAES(clave);

            return repository.GetUsuario(username, crytpPasswd);

        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            usuario.Clave = Cryptography.EncrypthAES(usuario.Clave);
            return repository.Save(usuario);
        }

    }
}
