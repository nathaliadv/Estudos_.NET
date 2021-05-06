using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ListaDeObject
    {
        private object[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao; //coincide com o valor da proxima posição;
            }
        }

        public ListaDeObject(int capacidadeInicial = 5)
        {
            _itens = new object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(object item)
        {
            VerificarCapacidade(_proximaPosicao + 1); //Verifica a capacidade do array. 
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}...");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++; //Incrementar para que a variável aponte para a posição seguinte a ser preenchida com valores
        }

        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2; //Aumentando o tamanho do array como uma margem de espaço
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            Console.WriteLine("Aumentando capacidade da lista");

            object[] novoArray = new object[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray; //Fazer a referência do array antigo antigo apontar para a referência do novo array.
        }

        public void Remover(object item)
        {
            int indiceItem = -1; //-1 é um valor inválido. Eles está sendo usado para mostrar que essa variável ainda não foi inicializada

            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        public object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}
