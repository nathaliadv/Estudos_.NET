using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

//Para gerar as tabelas no banco de dados a partir desse c�digo ser� usado um intermedi�rio, o framework Entity Framework Core. Ele faz o mapeamento do objeto relacional, e gerar� a partir das classes as tabelas, campos e chaves necess�rioas no banco de dados. Posteriormente, ele gerenciar� esta troca de informa��es entre o banco e o sistema. 
//Entify Framework � um framework de Mapeamento Objeto-Relacional.

//Cada classe herda da classe base BaseModel, que cont�m a propriedade Id comum a todas as classes.

//Tendo as classes do modelo, � preciso criar um contexto para o Entity Framework Core saber como lidar com as entidades para fazer o mapeamento - Applicationontext.cs
namespace CasaDoCodigo_v2.Models
{
    [DataContract] //Garante que a classe � serializavel, ou seja, que ela pode ser transformada em dados JSON/XML e vice-versa.
    public class BaseModel
    {
        [DataMember] //Garante que o atributo(propriedade) � serializ�vel.
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
        [MinLength(5, ErrorMessage = "Nome deve ter, no m�nimo, 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Nome deve ter, no m�ximo, 50 caracteres.")]
        [Required(ErrorMessage ="Nome � obrigat�rio")]
        public string Nome { get; set; } = "";
        [Required(ErrorMessage = "E-mail � obrigat�rio")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Telefone � obrigat�rio")]
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "Endere�o � obrigat�rio")]
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "Completo � obrigat�rio")]
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "Bairro � obrigat�rio")]
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "Munic�pio � obrigat�rio")]
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "UF � obrigat�rio")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "CPF � obrigat�rio")]
        public string CEP { get; set; } = "";

        internal void Update(Cadastro novoCadastro)
        {
            this.Nome = novoCadastro.Nome;
            this.Email = novoCadastro.Email;
            this.Telefone = novoCadastro.Telefone;
            this.Endereco = novoCadastro.Endereco;
            this.Complemento = novoCadastro.Complemento;
            this.Bairro = novoCadastro.Bairro;
            this.Municipio = novoCadastro.Municipio;
            this.UF = novoCadastro.UF;
            this.CEP = novoCadastro.CEP;
        }
    }

    [DataContract]
    public class ItemPedido : BaseModel
    {   
        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }
        [Required]
        [DataMember]
        public Produto Produto { get; private set; }
        [Required]
        [DataMember]
        public int Quantidade { get; private set; }
        [Required]
        [DataMember]
        public decimal PrecoUnitario { get; private set; }
        [DataMember]
        public decimal Subtotal => Quantidade * PrecoUnitario; // � uma propriedade que s� contem get;

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

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
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
