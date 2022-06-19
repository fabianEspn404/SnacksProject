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
        public IEnumerable<Usuario> GetUsuario()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioByUsername(string username)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarioByUsername(username);
        }
    }
}
