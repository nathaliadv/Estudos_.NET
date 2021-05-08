using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Para transformar a aplicação de console em um servidor http, usando o ASP .NET Core precisaremos usar um objeto para hospedar os pedidos web.
            //O tipo desse objeto é o IWebHost
            //Instalar o pacote AspNetCore com Nuget
            IWebHost host = new WebHostBuilder()
                .UseKestrel() //O servidor que implementa o modelo http, Kestrel
                .UseStartup<Startup>() //Classe que inicializa esse host. O nome do Tipo como Startup é apenas uma conveção. Poderia ser outro. Toda a configuração de inicialização ficará na classe startup
                .Build(); //Este método cria uma implementação a interface IWebHost
            host.Run(); //Subir o hospedeiro.


            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
