using System;
namespace Exercicio4;

class Conta
{
    private string numero;
    public string Numero
    {
        get
        {
            return numero;
        }
        set
        {
            if (value.Length == 5 && int.TryParse(value, out _))
                numero = value;
            else
                throw new Exception("A conta deve possuir 5 dígitos numéricos.");
        }
    }

    private string titular;
    public string Titular
    {
        get
        {
            return titular;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                titular = value;
            else
                throw new Exception("Digite um nome válido");
        }
    }

    private double saldo;
    public double Saldo
    {
        get
        {
            return saldo;
        }
        set
        {
            saldo = value;
        }
    }

    private double limite;
    public double Limite
    {
        get
        {
            return limite;
        }
        set
        {
            if (value >= 0)
                limite = value;
            else
                throw new Exception("Limite inválido.");
        }
    }

    public Conta()
    {

    }

    public Conta(string numero, string titular)
    {
        this.Numero = numero;
        this.Titular = titular;
    }

    public Conta(string numero, string titular, double saldo)
    {
        this.Numero = numero;
        this.Titular = titular;
        this.Saldo = saldo;
    }

    public Conta(string numero, string titular, double saldo, double limite)
    {
        this.Numero = numero;
        this.Titular = titular;
        this.Saldo = saldo;
        this.Limite = limite;
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine("Depósito realizado.");
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }

    public void Sacar(double valor)
    {
        if (valor > 0 && valor <= Saldo + Limite)
        {
            Saldo -= valor;
            Console.WriteLine("Saque realizado.");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente.");
        }
    }

    public void Transferir(Conta destino, double valor)
    {
        if (valor > 0 && valor <= Saldo + Limite)
        {
            Sacar(valor);
            destino.Depositar(valor);

            Console.WriteLine("Transferência realizada.");
        }
        else
        {
            Console.WriteLine("Transferência não realizada.");
        }
    }

    public void ExibirDados()
    {
        Console.WriteLine("\n======================");
        Console.WriteLine($"Conta: {Numero}");
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo: R$ {Saldo:F2}");
        Console.WriteLine($"Limite: R$ {Limite:F2}");
    }
}

class Program
{
    public static Conta BuscarConta(Conta[] contas, string numero)
    {
        foreach (Conta conta in contas)
        {
            if (conta != null && conta.Numero == numero)
                return conta;
        }

        return null;
    }

    // Lê e valida um double >= 0 digitado pelo usuário
    public static double LerValorValido(string mensagem)
    {
        double valor;
        Console.Write(mensagem);

        while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.Write("Valor inválido. Digite novamente: ");
        }

        return valor;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("--- Cadastrar Contas --");

        Conta[] xConta = new Conta[3];

        for (int i = 0; i < xConta.Length; i++)
        {
            Console.WriteLine($"\n--- Conta {i + 1} ---");

            while (xConta[i] == null)
            {
                try
                {
                    Console.Write("Titular: ");
                    string titular = Console.ReadLine();

                    Console.Write("Número da conta (5 dígitos): ");
                    string numero = Console.ReadLine();

                    double saldo = LerValorValido("Saldo: ");
                    double limite = LerValorValido("Limite: ");

                    xConta[i] = new Conta(numero, titular, saldo, limite);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message} Tente novamente.");
                }
            }
        }

        int opcao;

        do
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Exibir Contas");
            Console.WriteLine("5 - Sair");

            Console.Write("Escolha: ");

            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Opção inválida. Escolha: ");
            }

            switch (opcao)
            {
                case 1:
                    {
                        Console.Write("Número da conta: ");
                        string numeroDeposito = Console.ReadLine();

                        Conta contaDeposito = BuscarConta(xConta, numeroDeposito);

                        if (contaDeposito != null)
                        {
                            double valor = LerValorValido("Valor do depósito: ");
                            contaDeposito.Depositar(valor);
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }

                        break;
                    }

                case 2:
                    {
                        Console.Write("Número da conta: ");
                        string numeroSaque = Console.ReadLine();

                        Conta contaSaque = BuscarConta(xConta, numeroSaque);

                        if (contaSaque != null)
                        {
                            double valor = LerValorValido("Valor do saque: ");
                            contaSaque.Sacar(valor);
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }

                        break;
                    }

                case 3:
                    {
                        Console.Write("Conta de origem: ");
                        string origem = Console.ReadLine();

                        Console.Write("Conta de destino: ");
                        string destino = Console.ReadLine();

                        Conta contaOrigem = BuscarConta(xConta, origem);
                        Conta contaDestino = BuscarConta(xConta, destino);

                        if (contaOrigem != null && contaDestino != null)
                        {
                            double valor = LerValorValido("Valor da transferência: ");
                            contaOrigem.Transferir(contaDestino, valor);
                        }
                        else
                        {
                            Console.WriteLine("Conta de origem ou destino não encontrada.");
                        }

                        break;
                    }

                case 4:
                    Console.WriteLine("\n===== CONTAS CADASTRADAS =====");

                    foreach (Conta conta in xConta)
                    {
                        conta.ExibirDados();
                    }

                    break;

                case 5:
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inexistente.");
                    break;
            }

        } while (opcao != 5);
    }
}