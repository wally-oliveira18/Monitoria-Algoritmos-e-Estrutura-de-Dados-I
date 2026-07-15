using System; 
namespace Exercicio1;

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
            if (!string.IsNullOrWhiteSpace(value) && value.Length >= 3)
                nome = value;
            else
                throw new Exception("Nome inválido.");
        }
    }

    public string Cargo { get; set; }
    public double Salario { get; set; }

    public Funcionario()
    {
        this.Nome = "Não Informado";
        this.Cargo = "Sem cargo";
        this.Salario = 0;
    }

    public Funcionario(string nome, string Cargo, double Salario)
    {
        this.Nome = nome;
        this.Cargo = Cargo;
        this.Salario = Salario;
    }

    public void AumentarSalario(double percentual)
    {
        if (percentual < 0)
        {
            throw new Exception("O percentual não pode ser negativo.");
        } else
        {
            Salario += Salario * percentual / 100;
        }

    }

    public double Bonificacao()
    {
        return Salario * 0.1;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {this.Nome}");
        Console.WriteLine($"Cargo: {this.Cargo}");
        Console.WriteLine($"Salario: {this.Salario}");
        Console.WriteLine($"Bonificação: {Bonificacao()}");
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Funcionario func1 = new Funcionario(); // instanciando o objeto func1 da Classe Funcionario
            Console.WriteLine($"\nNome: {func1.Nome} \nCargo: {func1.Cargo} \nSalario: {func1.Salario}");

            Funcionario func2 = new Funcionario("Wallison", "Programador", 7000);
            Console.WriteLine($"\nNome: {func2.Nome} \nCargo: {func2.Cargo} \nSalario: {func2.Salario}");

            Console.WriteLine($"Qual será o aumento do funcionario?");
            double percentual = double.Parse(Console.ReadLine());

            func2.AumentarSalario(percentual);

            func1.ExibirDados();
            func2.ExibirDados();

        }
    }
}