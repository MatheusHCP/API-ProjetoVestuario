using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class MarcaRepositorio : BaseRepository<produtoMarca>
    {
        public List<produtoMarca> getAllDescricao(String descricao)
        {
            List<produtoMarca> lista = null;
            using (AppDBContext db = new AppDBContext())
            {
                lista = (db.marcas.Where(p => p.marca_desc.Contains(descricao)).OrderBy(p => p.marca_desc)).ToList();
            }

            return lista;
        }

    }
}
