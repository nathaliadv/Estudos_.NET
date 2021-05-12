using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    //ApplicationContext implementa DbContext. Herda da classe DbContext do namespace Entity Framework Core.
    //Uma instancia DbContext representa uma sessão com o banco de dados e pode ser usada para consultar e salvar instancias das suas entidades. O DbContext é uma combinação dos padrões Unit Of Work e Repository. 
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        //Quando estiver criando o modelo ele irá acessar esse método para fazer o mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Faremos o mapeamento a partir do parâmetro modelBuilder. Chamaremos o metodo Entity que registrará uma classe do nosso modelo e o mapearemos para que possa ser adicionado ao modelo. Caso o contrário o Entity não saberá que classes utilizará para gerar o banco de dados.
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);
        }
    }
}
