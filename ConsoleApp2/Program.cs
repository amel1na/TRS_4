using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задання розмірів матриці
            int M = 5; // Кількість рядків
            int N = 5; // Кількість стовпців

            // Ініціалізація та заповнення матриці випадковими числами
            int[,] matrix = new int[M, N];
            Random random = new Random();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = random.Next(1, 10); // Випадкове число від 1 до 10
                }
            }

            // Виведення початкової матриці на екран
            Console.WriteLine("Початкова матриця:");
            PrintMatrix(matrix);
            Console.WriteLine("");
            // Знаходження пари рядків з найменшим скалярним добутком
            int minScalarProduct = int.MaxValue; // Початкове значення мінімального скалярного добутку
            int row1 = 0; // Індекс першого рядка з пари
            int row2 = 0; // Індекс другого рядка з пари

            Parallel.For(0, M, i =>
            {
                for (int j = i + 1; j < M; j++)
                {
                    int scalarProduct = 0; // Змінна для збереження поточного скалярного добутку
                    for (int k = 0; k < N; k++)
                    {
                        scalarProduct += matrix[i, k] * matrix[j, k]; // Обчислення скалярного добутку
                    }

                    // Оновлення мінімального скалярного добутку та індексів рядків
                    lock (matrix)
                    {
                        if (scalarProduct < minScalarProduct)
                        {
                            minScalarProduct = scalarProduct;
                            row1 = i;
                            row2 = j;
                        }
                    }
                }
            });

            // Виведення результатів
            Console.WriteLine("Пара рядкiв з найменшим скалярним добутком:");
            Console.WriteLine("Рядок 1: " + row1);
            Console.WriteLine("Рядок 2: " + row2);
            Console.WriteLine("Скалярний добуток: " + minScalarProduct);
            Console.ReadLine();
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(" ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }


        }
    }
}
