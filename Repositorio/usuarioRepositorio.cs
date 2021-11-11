using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class usuarioRepositorio : BaseRepository<Usuario>
    {
        public Usuario validarlogin(String email, String senha)
        {
            Usuario Usuario = null;
            using (AppDBContext db = new AppDBContext())
            {
                Usuario = db.Usuario.Where(p => p.usu_email.ToLower() == email.ToLower() && p.usu_senha == senha).FirstOrDefault();
            }
            return Usuario;
        }

        public Usuario emailecpfexistente(String email, String CPF)
        {
            Usuario Usuario = null;
            using (AppDBContext db = new AppDBContext())
            {
                Usuario = db.Usuario.Where(p => p.usu_email.ToLower() == email.ToLower() || p.usu_cpf.ToLower() == CPF.ToLower() ).FirstOrDefault();
            }
            return Usuario;
        }

    }
}
