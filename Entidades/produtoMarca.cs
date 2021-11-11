using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class produtoMarca
    {
        public int id { get; set; }
        public string marca_desc { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }
    }
}
