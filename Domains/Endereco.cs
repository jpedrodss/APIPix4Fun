﻿using System;
using System.Collections.Generic;

namespace APIPix4Fun.Domains
{
    public partial class Endereco
    {
        public int IdEndereco { get; set; }
        public int? IdUsuario { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
