using System;
using System.Collections.Generic;

namespace Dio.Banco
{
    class Program
    {
		static List<Conta> listContas = new List<Conta>();

		static void Main(string[] args)
        {
			string opcao = PerguntarOpcao();

			while (opcao.ToUpper() != "X")
			{
				switch (opcao)
				{
					case "1":
						InserirConta();
						break;
					case "2":
						ListarConta();
						break;
					case "3":
						Depositar(); 
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Transferir();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcao = PerguntarOpcao();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

        
        private static void Sacar()
        {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

			listContas[indiceConta].Sacar(valorSaque);
		}

        private static void Transferir()
        {
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

        private static void InserirConta()
        {
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome =  Console.ReadLine().ToUpper();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,	saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

			listContas.Add(novaConta);
		}

		private static void ListarConta()
        {
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}
		private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

			listContas[indiceConta].Depositar(valorDeposito);
		}
		
		private static string PerguntarOpcao()
			{
				Console.WriteLine();
				Console.WriteLine("DIO Bank a seu dispor!!!");
				Console.WriteLine("Informe a opção desejada:");

				Console.WriteLine("1- Inserir nova conta");
				Console.WriteLine("2- Listar contas");
				Console.WriteLine("3- Depositar");
				Console.WriteLine("4- Sacar");
				Console.WriteLine("5- Transferir");
				Console.WriteLine("C- Limpar Tela");
				Console.WriteLine("X- Sair");
				Console.WriteLine();

				string opcaoUsuario = Console.ReadLine().ToUpper();
				Console.WriteLine();
				return opcaoUsuario;
			}

		}
    }

