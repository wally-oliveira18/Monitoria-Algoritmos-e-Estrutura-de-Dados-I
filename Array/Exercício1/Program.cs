namespace E1;

public class Program
{
    public static void Main(string[] args)
    {
        double[] num = new double[10]; 

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Preencha o {i + 1}° elemento do vetor:");
            num[i] = double.Parse(Console.ReadLine()); 
        }

        Console.WriteLine("Os elementos do vetor são: ");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(num[i]);
        }

    }
}