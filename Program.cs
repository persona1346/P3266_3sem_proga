using System;

class Program
{

    static void Main()
    {
        // Часть 1
        const int N = 10; 
        int[] array = { 1, 0, -2, 3, 0, 5, 6, -7, 8, 9 }; 
        
        PrintArray(array);
        
        Console.WriteLine($"Номер максимального элемента массива: {FindMaxElementIndex(array) + 1}");
        Console.WriteLine($"Произведение элементов между первым и вторым нулевыми элементами: {ProductBetweenZeros(array)}");
        Console.WriteLine("Преобразованный массив: " + string.Join(" ", TransformArray(array)));
        
        // Часть 2
        const int MatrixSize = 8; 
        int[,] matrix = new int[MatrixSize, MatrixSize]; 
        
        FillMatrixRandom(matrix);
        PrintMatrix(matrix);
        
        int matchingRowColumn = FindMatchingRowColumn(matrix);
        Console.WriteLine($"k, при которых k-я строка матрицы совпадает с k-м столбцом: {matchingRowColumn + 1}");

        int sumOfRowsWithNegatives = SumOfRowsWithNegatives(matrix);
        Console.WriteLine($"Сумма элементов в строках с отрицательными элементами: {sumOfRowsWithNegatives}");
    }

    static void FillMatrixRandom(int[,] matrix)
    {
        Random rand = new Random();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(-100, 101); 
            }
        }
    }
    
    static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
    
    static int FindMaxElementIndex(int[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    static int ProductBetweenZeros(int[] array)
    {
        int firstZeroIndex = -1;
        int secondZeroIndex = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                if (firstZeroIndex == -1)
                {
                    firstZeroIndex = i;
                }
                else
                {
                    secondZeroIndex = i;
                    break;
                }
            }
        }

        if (firstZeroIndex == -1 || secondZeroIndex == -1)
        {
            // В массиве менее двух нулей
            return 0;
        }

        int product = 1;
        for (int i = firstZeroIndex + 1; i < secondZeroIndex; i++)
        {
            product *= array[i];
        }

        return product;
    }

    static int[] TransformArray(int[] array)
    {
        int[] transformedArray = new int[array.Length];
        int oddIndex = 0;
        int evenIndex = array.Length / 2;

        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                transformedArray[evenIndex] = array[i];
                evenIndex++;
            }
            else
            {
                transformedArray[oddIndex] = array[i];
                oddIndex++;
            }
        }

        return transformedArray;
    }
    

    static int FindMatchingRowColumn(int[,] matrix)
    {
        for (int k = 0; k < matrix.GetLength(0); k++)
        {
            bool isMatching = true;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[k, i] != matrix[i, k])
                {
                    isMatching = false;
                    break;
                }
            }

            if (isMatching)
            {
                return k;
            }
        }

        return -1; // Если совпадение не найдено
    }

    static int SumOfRowsWithNegatives(int[,] matrix)
    {
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            bool hasNegativeElement = false;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegativeElement = true;
                    break;
                }
            }

            if (hasNegativeElement)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
        }

        return sum;
    }
    
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}