using System;

namespace DioSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Padroes();

            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
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

            Console.Title = "DIO SERIES - O seu sistema de séries da Digital Innovation One";

            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.ForegroundColor = ConsoleColor.White;
        }
        private static string ObterOpcaoUsuario()
		{
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("###################################################################################################################### ");
            Console.WriteLine("############################# DIO SERIES - O SISTEMA DE SERIES DA DIGITAL INNOVATION ONE ############################# ");
            Console.WriteLine("###################################################################################################################### ");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
        public static void Rodape()
        {

            Console.WriteLine("###################################################################################################################### ");
            Console.WriteLine("#################################### OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS! ########################################## ");
            Console.WriteLine("###################################################################################################################### ");

            Console.WriteLine("");

            Console.ReadKey();
        }
        private static void ListarSeries()
		{
			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");

                Console.ReadKey();

				return;
			}
            Console.Clear();

			Console.WriteLine("Lista de séries");
            Console.WriteLine();

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}

            Console.ReadKey();
		}
        private static void InserirSerie()
		{
            Console.Clear();

			Console.WriteLine("Inserir nova série");
            Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.Write("{0}-{1} | ", i, Enum.GetName(typeof(Genero), i));
			}

            Console.WriteLine();
            Console.WriteLine();
			Console.Write("Dentre os gêneros acima, escolha um e digite o número da opção: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}
        private static void AtualizarSerie()
		{
            var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");

                Console.ReadKey();

				return;
			}
            else
            {
                Console.Clear();

                Console.WriteLine("Lista de séries");
                Console.WriteLine();

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Escolha uma das séries acima: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine();

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.Write("{0}-{1} | ", i, Enum.GetName(typeof(Genero), i));
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Atualiza(indiceSerie, atualizaSerie);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Série Atualizada com sucesso!");

                Console.ReadKey();
            }
		}
        private static void ExcluirSerie()
		{
            var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");

                Console.ReadKey();

				return;
			}
            else
            {
                Console.Clear();

                Console.WriteLine();
                foreach (var listaSerie in lista)
                {
                    var excluido = listaSerie.retornaExcluido();
                    
                    Console.WriteLine("#ID {0}: - {1} {2}", listaSerie.retornaId(), listaSerie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Escolha uma das séries acima: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);

                Console.WriteLine("Série excluida com sucesso!");

                Console.ReadKey();
            }
		}

        private static void VisualizarSerie()
		{
            var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");

                Console.ReadKey();

				return;
			}
            else
            {
                Console.Clear();

                Console.WriteLine();
                foreach (var listaSerie in lista)
                {
                    var excluido = listaSerie.retornaExcluido();
                    
                    Console.WriteLine("#ID {0}: - {1} {2}", listaSerie.retornaId(), listaSerie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Escolha uma das séries acima: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine(serie);

                Console.ReadKey();
            }
		}
    }
}
