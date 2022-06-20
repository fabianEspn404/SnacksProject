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
        public IEnumerable<Usuario> GetUsuarios()
        {
            try
            {
                IEnumerable<Usuario> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Usuario.ToList<Usuario>();
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public Usuario GetUsuario(string username,string clave)
        {
            Usuario usuario;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.
                        Where(p => p.Username.Equals(username) && p.Clave == clave).
                                     FirstOrDefault<Usuario>();
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
