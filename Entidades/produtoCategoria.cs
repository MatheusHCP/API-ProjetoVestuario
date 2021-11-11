using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class produtoCategoria
    {
        public int id { get; set; }

        public string cat_descricao { get; set; }

        public ICollection<Produto> produtos { get; set; }

    }
}
