using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class produtoStatus
    {

        public int id { get; set; }

        public string status_desc { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }

    }
}
