using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        private string _cpf;

        public string Nome { get; set; }
        public string CPF
        {
            get
            {
                return _cpf;
            }
            set
            {
                // Escrevo minha lógica de validação de CPF
                _cpf = value;
            }
        }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            //Cliente outroCliente = (Cliente)obj; //conversão do tipo obj para cliente;
            Cliente outroCliente = obj as Cliente; //isso quer dizer que o Cliente pode receber um obj as Cliente
            //se não for possível ocorrer a conversão (o argumento recebido pelo Equal não for object e sim outro tipo)
            //ele retornará a variável outroCliente como nula.

            if(outroCliente == null)
            {
                return false;
            }
            return 
                Nome == outroCliente.Nome &&
                CPF == outroCliente.CPF &&
                Profissao == outroCliente.Profissao;
        }
    }
}
