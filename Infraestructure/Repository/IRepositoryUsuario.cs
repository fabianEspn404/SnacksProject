using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {
        IEnumerable<Usuario> GetUsuarios();

        Usuario GetUsuario(string username,string clave);


        Usuario GetUsuarioByUsername(string username);
    }
}
