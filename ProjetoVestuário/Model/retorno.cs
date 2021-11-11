using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVestuário.Model
{
    public class retorno<T>
    {
        public bool status  { get; set; }

        public String erro { get; set; }

        public T resultado { get; set; }

        public String mensagem{ get; set; }

    }
}
