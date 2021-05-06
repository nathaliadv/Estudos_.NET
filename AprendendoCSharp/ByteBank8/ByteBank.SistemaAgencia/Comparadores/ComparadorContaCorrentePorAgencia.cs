using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if(x == y)
            {
                return 0;
            }
            if(x == null)
            {
                return 1;
            }
            if(y == null)
            {
                return -1;
            }

            //Como o numero inteiro implementa a interface IComparable (é assim que o sort() funciona nele)
            //Podemos só utilizar o CompareTo aqui (já que estamos comparando dois numeros inteiros).
            return x.Agencia.CompareTo(y.Agencia);


            //if(x.Agencia < y.Agencia) // x antes de y
            //{
            //    return -1;
            //}
            //if(x.Agencia == y.Agencia) // são equivalentes
            //{
            //    return 0;
            //}
            //return 1; // y antes de x
        }
    }
}
