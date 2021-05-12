using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

//Para gerar as tabelas no banco de dados a partir desse código será usado um intermediário, o framework Entity Framework Core. Ele faz o mapeamento do objeto relacional, e gerará a partir das classes as tabelas, campos e chaves necessárioas no banco de dados. Posteriormente, ele gerenciará esta troca de informações entre o banco e o sistema. 
//Entify Framework é um framework de Mapeamento Objeto-Relacional.

//Cada classe herda da classe base BaseModel, que contém a propriedade Id comum a todas as classes.

//Tendo as classes do modelo, é preciso criar um contexto para o Entity Framework Core saber como lidar com as entidades para fazer o mapeamento - Applicationontext.cs
namespace CasaDoCodigo.Models
{
    [DataContract] //Garante que a classe é serializavel, ou seja, que ela pode ser transformada em dados JSON/XML e vice-versa.
    public class BaseModel
    {
        [DataMember] //Garante que o atributo(propriedade) é serializável.
        public int Id { get; protected set; }
    }

    public class Produto : BaseModel
    {
        public Produto()
        {

        }

        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public decimal Preco { get; private set; }

        public Produto(string codigo, string nome, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }
    }

    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Endereco { get; set; } = "";
        [Required]
        public string Complemento { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Municipio { get; set; } = "";
        [Required]
        public string UF { get; set; } = "";
        [Required]
        public string CEP { get; set; } = "";
    }

    public class ItemPedido : BaseModel
    {   
        [Required]
        public Pedido Pedido { get; private set; }
        [Required]
        public Produto Produto { get; private set; }
        [Required]
        public int Quantidade { get; private set; }
        [Required]
        public decimal PrecoUnitario { get; private set; }

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }

    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();
        [Required]
        public virtual Cadastro Cadastro { get; private set; }
    }
}
