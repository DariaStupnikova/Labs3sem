namespace Task1;

public static class FirstTask
{
    public static void Main()
    {
        Console.WriteLine("Введите размер массива N:");
        var n = int.Parse(Console.ReadLine());
        
        var array = GenerateRandomArray(n);

        Console.WriteLine("Сгенерированный массив:");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }

        ProcessArray(array);

        Console.WriteLine("\nОтсортированный массив по возрастанию модулей:");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
    }

    public static int[] GenerateRandomArray(int size)
    {
        var random = new Random();
        var array = new int[size];
        for (var i = 0; i < size; i++)
        {
            array[i] = (random.Next(10) - 3);
        }
        return array;
    }

    public static void ProcessArray(int[] array)
    {
        var zeroCount = 0;
        foreach (var element in array)
        {
            if (element == 0)
            {
                zeroCount++;
            }
        }

        Console.WriteLine($"Количество элементов, равных нулю: {zeroCount}");

        var minElement = array[0];
        var minIndex = 0;
        for (var i = 1; i < array.Length; i++)
        {
            if (array[i] < minElement)
            {
                minElement = array[i];
                minIndex = i;
            }
        }

        double sumAfterMin = 0;
        for (var i = minIndex + 1; i < array.Length; i++)
        {
            sumAfterMin += array[i];
        }

        Console.WriteLine($"Сумма элементов после минимального элемента: {sumAfterMin}");

        Array.Sort(array, (x, y) => Math.Abs(x).CompareTo(Math.Abs(y)));
    }
}