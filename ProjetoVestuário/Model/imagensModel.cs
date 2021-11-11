using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVestuário.Model
{
    public class imagensModel
    {
        public int id { get; set; }
        public int Produtoid { get; set; } // id para consulta, insert, etc...
        public string img_caminho { get; set; }
        public produtoModel Produto { get; set; }
    }
}
