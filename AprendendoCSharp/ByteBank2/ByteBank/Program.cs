using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;


namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //CalcularBonificacao();
            UsarSistema();
            Console.ReadLine();
        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();
            
            Diretor roberta = new Diretor("Roberta", "159.753.398-04");
            roberta.Senha = "123";

            sistemaInterno.Logar(roberta, "123");
            sistemaInterno.Logar(roberta, "111");

            GerenteDeConta camila = new GerenteDeConta("Camila", "326.985.628-89");
            camila.Senha = "123123";

            sistemaInterno.Logar(camila, "123123");

            ParceiroComercial parceiroComercial = new ParceiroComercial();
            parceiroComercial.Senha = "123456";

            sistemaInterno.Logar(parceiroComercial, "123456");

        }

        public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Designer pedro = new Designer("Pedro", "833.222.048-39");

            Diretor roberta = new Diretor("Roberta", "159.753.398-04");

            Auxiliar igor = new Auxiliar("Igor", "981.198.778-53");

            GerenteDeConta camila = new GerenteDeConta("Camila", "326.985.628-89");

            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila);

            Console.WriteLine($"Total de bonificações no mês: {gerenciadorBonificacao.GetTotalBonificacao()}");
        }
    }
}
