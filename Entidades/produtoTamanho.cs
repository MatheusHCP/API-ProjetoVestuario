using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class produtoTamanho
    {  // Tamanho das roupas
        public int id { get; set; }
        public string tamanho_desc { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }
    }
}
