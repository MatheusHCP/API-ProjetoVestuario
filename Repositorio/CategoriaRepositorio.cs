using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class CategoriaRepositorio : BaseRepository<produtoCategoria>
    {
        public List<produtoCategoria> getAllDescricao(String descricao)
        {
            List<produtoCategoria> lista = null;
            using (AppDBContext db = new AppDBContext())
            {
                lista = (db.categorias.Where(p => p.cat_descricao.Contains(descricao)).OrderBy(p => p.cat_descricao)).ToList();
            }

            return lista;
        }

    }
}
