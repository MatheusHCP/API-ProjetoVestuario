﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class usuarioTipo
    {

        public int id { get; set; }

        public string usuarioTipo_desc{ get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
