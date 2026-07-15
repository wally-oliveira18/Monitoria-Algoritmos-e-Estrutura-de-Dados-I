using System;
namespace Exercicio3;

class Funcionario
{
    private string nome;
    public string Nome
    {
        get
        {
            return nome;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                nome = value;
            else
                throw new Exception("Nome inválido");
        }
    }

    private string cargo;

    public string Cargo
    {
        get
        {
            return cargo;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                cargo = value;
            else
                throw new Exception("Cargo inválido");
        }
    }

    private double salario;

    public double Salario
    {
        get
        {
            return salario;
        }
        set
        {
            if (value > 0)
                salario = value;
            else
                throw new Exception("O valor informado deve ser maior que 0");
        }
    }

    private string departamento;

    public string Departamento
    {
        get
        {
            return departamento;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                departamento = value;
        }
    }

    public Funcionario()
    {

    }

    public Funcionario(string nome, string cargo)
    {
        this.Nome = nome;
        this.Cargo = cargo;
    }

    public Funcionario(string nome, string cargo, double salario, string departamento)
    {
        this.Nome = nome;
        this.Cargo = cargo;
        this.Salario = salario;
        this.Departamento = departamento;
    }

    public void AumentarSalario(double NovoSalario)
    {
        Salario = NovoSalario;
    }

    public void TransferirDepartamento(string NovoDepartamento)
    {
        Departamento = NovoDepartamento;
    }

    public void DadosFuncionario()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salario: {Salario}");
        Console.WriteLine($"Departamento: {Departamento}");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Funcionario[] xFuncionario = new Funcionario[3];

        for (int i = 0; i < xFuncionario.Length; i++)
        {
            Console.WriteLine("Nome:");
            string Nome = Console.ReadLine();

            Console.WriteLine("Cargo:");
            string Cargo = Console.ReadLine();

            Console.WriteLine("Salario:");
            double Salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Departamento:");
            string Departamento = Console.ReadLine();

            Funcionario funcionario = new Funcionario(Nome, Cargo, Salario, Departamento);

            xFuncionario[i] = funcionario;
        }

        foreach (Funcionario funcionario in xFuncionario)
        {
            Console.WriteLine($"\nDigite o novo salario do Funcionario {funcionario.Nome}:");
            double NovoSalario = double.Parse(Console.ReadLine());

            funcionario.AumentarSalario(NovoSalario);

            ;
        }

        foreach (Funcionario funcionario in xFuncionario)
        {
            Console.WriteLine($"\nNovo departamento do Funcionario {funcionario.Nome}:");
            string NovoDepartamento = Console.ReadLine();

            funcionario.TransferirDepartamento(NovoDepartamento);
        }

        Console.WriteLine("Dados dos Funcionarios:");

        foreach (Funcionario funcionario in xFuncionario)
        {
            funcionario.DadosFuncionario();
        }
    }
}