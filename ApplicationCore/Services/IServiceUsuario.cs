using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceUsuario
    {

        Usuario GetUsuario(string username,string clave);

        IEnumerable<Usuario> GetUsuarios();

        Usuario GetUsuarioByUsername(string username);

        Usuario Save(Usuario usuario);


    }
}
