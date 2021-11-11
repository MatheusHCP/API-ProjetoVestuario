using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Imagens
    {
        public int id { get; set; }
        public int Produtoid { get; set; } // id para consulta, insert, etc...
        public string img_caminho { get; set; }
        public Produto Produto { get; set; }
    }
}
