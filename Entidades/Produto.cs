using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Produto
    {
        
        public int id { get; set; }
        public string prod_Descricao  { get; set; }
        public decimal prod_preco{ get; set; }
        public DateTime prod_dataCadastro{ get; set; }
        public int prod_statuspublicacao { get; set; } // Relacionamento com usuário que publicou (criar tabela com status de punlicação)
        public int prod_usuariocadastro { get; set; } // Relacionamento com usuário que cadastrou
        public int produtoCategoriaid { get; set; } //Manter padrão para entity reconhecer
        public int produtoMarcaid { get; set; }
        public int produtoGeneroid { get; set; }
        public int produtoTamanhoid { get; set; }


        public produtoCategoria produtoCategoria { get; set; }
        public produtoMarca produtoMarca { get; set; }
        public produtoGenero produtoGenero { get; set; }
        public produtoTamanho produtoTamanho{ get; set; }

    }
}
