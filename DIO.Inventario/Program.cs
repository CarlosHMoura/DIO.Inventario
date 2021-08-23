using System;
using DIO.Inventario.Classes;
using DIO.Inventario.Enum;

namespace DIO.Inventario
{
    class Program
    {
		static InventarioRepositorio repositorio = new InventarioRepositorio();
        static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarInventário();
						break;
					case "2":
						InserirItem();
						break;
					case "3":
						AtualizarItem();
						break;
					case "4":
						ExcluirItem();
						break;
					case "5":
						VisualizarItem();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Inventário!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Inventário");
			Console.WriteLine("2- Inserir novo item");
			Console.WriteLine("3- Atualizar item");
			Console.WriteLine("4- Excluir item");
			Console.WriteLine("5- Visualizar item");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static void ListarInventário()
		{
			Console.WriteLine("Listar Itens");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma item cadastrado.");
				return;
			}

			foreach (var item in lista)
			{
				var excluido = item.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} Nº Série: {2}  {3}", item.retornaId(), item.retornaModelo(), item.retornanSerie(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void InserirItem()
		{
			Console.WriteLine("Inserir novo item");

            foreach (int i in System.Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Tipo), i));
			}
			
			Console.Write("Digite o tipo entre as opções acima: ");
			string entradaTipoS = Console.ReadLine();
			int entradaTipo = 0;
			if (!String.IsNullOrWhiteSpace(entradaTipoS))
				entradaTipo = int.Parse(entradaTipoS);

			Console.Write("Digite o Modelo: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Número de Série: ");
			string entradaSerie = Console.ReadLine();

			Console.Write("Digite o Número de Patrimonio: ");
			string entradaPatrimonio = Console.ReadLine();

			Classes.Inventario novoItem = new Classes.Inventario(id: repositorio.ProximoId(),
										tipo: (Tipo)entradaTipo,
										modelo: entradaModelo,
										nserie: entradaSerie,
										npatrimonio: entradaPatrimonio);

			repositorio.Insere(novoItem);
		}

		private static void AtualizarItem()
		{
			Console.Write("Digite o id do item: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in System.Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Número de Série: ");
			string entradaSerie = Console.ReadLine();

			Console.Write("Digite o Número de Patrimonio: ");
			string entradaPatrimonio = Console.ReadLine();

			Classes.Inventario atualizaItem = new Classes.Inventario(id: indiceSerie,
										tipo: (Tipo)entradaTipo,
										modelo: entradaModelo,
										nserie: entradaSerie,
										npatrimonio: entradaPatrimonio);

			repositorio.Atualiza(indiceSerie, atualizaItem);
		}

		private static void ExcluirItem()
		{
			Console.Write("Digite o id do item: ");
			int indiceItem = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceItem);
		}

		private static void VisualizarItem()
		{
			Console.Write("Digite o id do item: ");
			int indiceItem = int.Parse(Console.ReadLine());

			var item = repositorio.RetornaPorId(indiceItem);

			Console.WriteLine(item);
		}
	}
}
