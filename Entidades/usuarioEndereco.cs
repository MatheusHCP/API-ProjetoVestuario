using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class usuarioEndereco
    {
        public int id { get; set; }
        public int Usuarioid { get; set; }
        public string end_descricao { get; set; }
        public string end_endereco{ get; set; }
        public string end_numero { get; set; }
        public string end_complemento{ get; set; }
        public string end_bairro{ get; set; }
        public string end_cidade { get; set; }
        public string end_estado { get; set; }
        public string end_CEP { get; set; }
        public string end_referencia { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

    }
}
