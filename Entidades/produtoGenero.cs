using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class produtoGenero
    {   // Gênero do tipo MASCULINO/FEMININO
        public int id { get; set; }
        public string genero_desc { get; set; }

        public virtual ICollection<Produto> produtos { get; set; }

    }
}
