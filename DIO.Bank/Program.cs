using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
        {
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
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}
		private static void Depositar()
		{
            try
            {
				Console.Write("Digite o número da conta: ");
				int indiceConta = int.Parse(Console.ReadLine());

				Console.Write("Digite o valor a ser depositado: ");
				double valorDeposito = double.Parse(Console.ReadLine());

				listContas[indiceConta].Depositar(valorDeposito);
			}catch(Exception e)
            {
				Console.WriteLine("digite o numero da conta e o valor a ser depositado");
            }
			
		}

		private static void Sacar()
		{
            try
            {
				Console.Write("Digite o número da conta: ");
				int indiceConta = int.Parse(Console.ReadLine());

				Console.Write("Digite o valor a ser sacado: ");
				double valorSaque = double.Parse(Console.ReadLine());

				listContas[indiceConta].Sacar(valorSaque);
			}catch(Exception e)
            {
				Console.WriteLine("digite somente os numeros da conta e o valor a ser sacado");
            }
			
		}

		private static void Transferir()
		{
            try
            {
				Console.Write("Digite o número da conta de origem: ");
				int indiceContaOrigem = int.Parse(Console.ReadLine());

				Console.Write("Digite o número da conta de destino: ");
				int indiceContaDestino = int.Parse(Console.ReadLine());

				Console.Write("Digite o valor a ser transferido: ");
				double valorTransferencia = double.Parse(Console.ReadLine());

				listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
			}catch(Exception e)
            {
				Console.WriteLine("insira somente o numero da conta de origem e destino e o valor da transferência");
            }
			
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");
            try
            {
				Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
				int entradaTipoConta = int.Parse(Console.ReadLine());

				Console.Write("Digite o Nome do Cliente: ");
				string entradaNome = Console.ReadLine();

				Console.Write("Digite o saldo inicial: ");
				double entradaSaldo = double.Parse(Console.ReadLine());

				Console.Write("Digite o crédito: ");
				double entradaCredito = double.Parse(Console.ReadLine());

				Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
											saldo: entradaSaldo,
											credito: entradaCredito,
											nome: entradaNome);

				listContas.Add(novaConta);
			}catch(Exception e)
            {
				Console.WriteLine("erro! insira o dado corretamente");
            }
			
		}

		private static void ListarContas()
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
		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
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
	}
}
