using System;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        const int n = 3;
        static int [,] NewMatrix(bool f)
        {
            int[,] A = new int[n, n];
            Random rand = new Random();

            for (int j = 0; j < n; j++)
                for (int i = 0; i < n; i++)
                {
                    if(f==false)
                        A[i, j] = rand.Next(0, 10);
                    else
                        A[i, j] = 0;
                }
            return A;
        }
        static int[,] Multi(int [,] A, int[,] B, int [,] C)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    C[i,j] = 0;
                    for (int k = 0; k < n; k++)
                        C[i,j] += A[i,k] * B[k,j];
                }
            return C;
        }
        static void print (int [,] C)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{C[j, i]}   ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int [,] A = NewMatrix(false);
            int [,] B = NewMatrix(false);
            int[,] C = NewMatrix(true);

            Multi(A, B, C);
            print(C);
            Console.ReadKey();
        }
    }
}
