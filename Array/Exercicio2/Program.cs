namespace E2;
public class Program
{
    public static void Main(string[] args)
    {
        double[] vetor = new double[10];
        double potencia;

        for (int i = 0; i < 10; i++)
        {
            if (i%2 == 0)
            {
                potencia = Math.Pow(i, 2);
                vetor[i] = potencia;
            } if (i%2 == 1)
            {
                potencia = Math.Pow(i, 3);
                vetor[i] = potencia;
            }
        }

        Console.WriteLine("Os elementos do vetor são");
        for (int i = 0; i<10; i++)
        {
            Console.WriteLine(vetor[i]);
        }
    }
}