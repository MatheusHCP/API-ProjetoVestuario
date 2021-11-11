using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVestuário.Model
{
    public class usuarioModel
    {
        public int id { get; set; }
        public int UsuarioTipoid { get; set; }
        public string usu_nome { get; set; }
        public string usu_cpf { get; set; }
        public DateTime? usu_dataCriacao { get; set; }
        public string usu_email { get; set; }
        public string usu_senha { get; set; }
        public usuarioEnderecoModel usuarioEnderecoModel { get; set; }
    }
}
