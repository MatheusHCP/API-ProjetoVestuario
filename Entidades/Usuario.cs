using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {

        public int id { get; set; }
        public int UsuarioTipoid { get; set; } // TIPO DE USUÁRIO | 1 - ADMIN | 2 - USUÁRIO PADRÃO
        public string usu_nome { get; set; }
        public string usu_cpf { get; set; }
        public DateTime usu_dataCriacao { get; set; }
        public string usu_email { get; set; }
        public string usu_senha{ get; set; }
        public ICollection<Produto> usuarioEnderecos { get; set; }
    }
}
