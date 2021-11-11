using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class ProdutoRepositorio : BaseRepository<Produto>
    {
        public List<Produto> getAllDescricao(String descricao)
        {
            List<Produto> lista = null;
            using (AppDBContext db = new AppDBContext())
            {
                lista = (db.produtos.Where(p => p.prod_Descricao.Contains(descricao)).OrderBy(p => p.prod_Descricao)).ToList();
            }

            return lista;
        }

    }
}
