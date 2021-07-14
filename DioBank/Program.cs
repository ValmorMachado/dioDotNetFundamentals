using System;
using System.Collections.Generic;

namespace DioBank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            Padroes();

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.Write("Opção Inválida! Escolha uma opção válida!");
                        Console.ReadKey();
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Rodape();

        }

        public static void Padroes()
        {
            Console.Clear();

            Console.Title = "DIO BANK - Seu banco na Digital Innovation One";

            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Transferir()
        {

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");

                Console.ReadKey();

                return;
            }

            Console.Clear();

            Console.Write("Digite o número da conta de origem: ");

            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");

            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: R$ ");

            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);

            Console.ReadKey();
        }

        private static void Sacar()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");

                Console.ReadKey();

                return;
            }

            Console.Clear();

            Console.Write("Digite o número da conta: ");

            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: R$ ");

            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);

            Console.ReadKey();
        }

        private static void Depositar()
        {
            
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");

                Console.ReadKey();

                return;
            }

            Console.Clear();

            Console.Write("Digite o número da conta: ");

            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: R$ ");

            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);

            Console.ReadKey();
        }

        private static void InserirConta()
        {
            Console.Clear();

            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");

            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o nome do Cliente: ");

            string entradaNome = Console.ReadLine();
            
            Console.WriteLine();

            Console.Write("Digite o Saldo Inicial: R$ ");

            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o crédito: R$ ");

            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listaContas.Add(novaConta);

            Console.ReadKey();
        }

        private static void ListarContas()
        {

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");

                Console.ReadKey();

                return;
            }

            Console.Clear();

            Console.WriteLine("Listar Contas");

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];

                Console.Write("#{0} - ", i);

                Console.WriteLine(conta);
            }

            Console.ReadKey();

        }        

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("############################################################################################################################## ");
            Console.WriteLine("######################################## DIO BANK - O BANCO DA DIGITAL INNOVATION ONE ######################################## ");
            Console.WriteLine("############################################################################################################################## ");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return opcaoUsuario;
        }

        public static void Rodape()
        {

            Console.WriteLine("############################################################################################################################## ");
            Console.WriteLine("######################################## OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS! ############################################## ");
            Console.WriteLine("############################################################################################################################## ");

            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
