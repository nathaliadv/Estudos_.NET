using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    public class Cliente
    {
        private string _cpf;

        public string Nome {get; set;}
        public string Profissao {get; set;}

        public string CPF
        {
            get
            {
                return _cpf;
            }
            set
            {
                if (value.Length < 11)
                {
                    return;
                }

                _cpf = value;
            }
        }

    }
}
