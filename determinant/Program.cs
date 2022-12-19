using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace determinant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numarul de linii si coloane, separate printr-un spatiu!");
            double[,] A;
            int linii;
            int coloane;
            string[] t = Console.ReadLine().Split(' ');

            linii = int.Parse(t[0]);
            coloane = int.Parse(t[1]);

            A = new double[linii, coloane];

            for(int i = 0; i < linii; i++)
            {
                t = Console.ReadLine().Split(' ');
                for(int j = 0; j < coloane; j++)
                {
                    A[i, j] = int.Parse(t[j]);
                }
            }

            double determinant = calculatorDeterminant(A);
            Console.WriteLine($"Rezultatul este: {determinant}");

        }

        static double calculatorDeterminant(double[,] A)
        {
            double linii = A.GetLength(0);
            double coloane = A.GetLength(1);

            if(linii != coloane)
            {
                Console.WriteLine("Matricea trebuie sa fie patratica pentru a-i fi calculat determinantul");
            }

            if (linii == 1 && coloane == 1)
            {
                return A[0, 0];
            }
            else if (linii == 2 && coloane == 2)
            {
                return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
            }
            else
            {
                double determinant = 0;
                for (int i = 0; i < linii; i++)
                {
                    determinant += A[0, i] * Math.Pow(-1, i) * calculatorDeterminant(taie(A, 0, i));
                }
                return determinant;
            }
        }

        static double[,] taie(double[,] A, int linieT, int coloanaT) 
        {
            int l = A.GetLength(0);
            int c = A.GetLength(1);

            double[,] submatrice = new double[l-1, c-1];

            for(int i = 0, linieSM = 0; i < l; i++)
            {
                if(i == linieT)
                {
                    continue;
                }
                for(int j = 0, coloanaSM =0; j<c; j++)
                {
                    if (j == coloanaT)
                    {
                        continue;
                    }

                    submatrice[linieSM, coloanaSM] = A[i, j];
                    coloanaSM++;
                }
                linieSM++;
            }
            return submatrice;
        }
    }
}
