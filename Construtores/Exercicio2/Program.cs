using System;

namespace Exercicio2;

class Aluno
{
    private string matricula;
    public string Matricula
    {
        get { return matricula; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                matricula = value;
            else
                throw new Exception("Matrícula inválida.");
        }
    }

    private string nome;
    public string Nome
    {
        get { return nome; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                nome = value;
            else
                throw new Exception("Nome inválido.");
        }
    }

    private string curso;
    public string Curso
    {
        get { return curso; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                curso = value;
            else
                throw new Exception("Curso inválido.");
        }
    }

    private int periodo;
    public int Periodo
    {
        get { return periodo; }
        set
        {
            if (value > 0)
                periodo = value;
            else
                throw new Exception("O período deve ser maior que zero.");
        }
    }

    private double cra;
    public double CRA
    {
        get { return cra; }
        set
        {
            if (value >= 0 && value <= 100)
                cra = value;
            else
                throw new Exception("O CRA deve estar entre 0 e 100.");
        }
    }

    public Aluno(string matricula, string nome)
    {
        Matricula = matricula;
        Nome = nome;
    }

    public Aluno(string nome, string matricula, string curso, int periodo, double cra)
    {
        Nome = nome;
        Matricula = matricula;
        Curso = curso;
        Periodo = periodo;
        CRA = cra;
    }

    public void ExibirDadosAluno()
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Período: {Periodo}");
        Console.WriteLine($"CRA: {CRA:F2}");
    }

    public void AvancarAluno()
    {
        Periodo++;
    }

    public void AtualizarCRA(double novoCRA)
    {
        CRA = novoCRA;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Aluno[] xAluno = new Aluno[2];

        for (int i = 0; i < xAluno.Length; i++)
        {
            Console.WriteLine($"\n===== Cadastro do Aluno {i + 1} =====");

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Curso: ");
            string curso = Console.ReadLine();

            int periodo;
            while (true)
            {
                Console.Write("Período: ");

                if (int.TryParse(Console.ReadLine(), out periodo) && periodo > 0)
                    break;

                Console.WriteLine("Erro! Digite um número inteiro maior que zero.");
            }

            double cra;
            while (true)
            {
                Console.Write("CRA: ");

                if (double.TryParse(Console.ReadLine(), out cra) && cra >= 0 && cra <= 100)
                    break;

                Console.WriteLine("Erro! Digite um número entre 0 e 100.");
            }

            xAluno[i] = new Aluno(nome, matricula, curso, periodo, cra);
        }

        Console.WriteLine("\nDados dos alunos");

        foreach (Aluno aluno in xAluno)
        {
            aluno.ExibirDadosAluno();
        }

        Console.WriteLine("\n Atualização dos Dados");

        foreach (Aluno aluno in xAluno)
        {
            aluno.AvancarAluno();

            double novoCRA;

            while (true)
            {
                Console.Write($"\nDigite o novo CRA de {aluno.Nome}: ");

                if (double.TryParse(Console.ReadLine(), out novoCRA) && novoCRA >= 0 && novoCRA <= 100)
                    break;

                Console.WriteLine("Erro! Digite um número entre 0 e 100.");
            }

            aluno.AtualizarCRA(novoCRA);
        }

        Console.WriteLine("\nDados atualizados dos alunos");

        foreach (Aluno aluno in xAluno)
        {
            aluno.ExibirDadosAluno();
        }
    }
}