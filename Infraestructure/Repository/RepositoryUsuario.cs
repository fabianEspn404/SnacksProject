using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public IEnumerable<Usuario> GetUsuario()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioByUsername(string username)
        {
            Usuario usuario;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.Find(username);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
