/* Завдання 5: Створіть додатокдля роботи з масивом:
 * Видалити повторювані значення з масиву.
 * Сортування масиву (стартує після видалення дубльованих значень).
 * Бінарний  пошук  певного  значення  (стартує  після сортування).
 * Використовуйте continuation    tasksдля  вирішення  даного завдання.*/
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Початковий масив
        int[] arr = { 3, 2, 1, 2, 3, 4, 5, 4, 6, 7, 6, 8, 9, 10, 9, 11 };
        // Створення тасків
        Task<int[]> task1 = Task.Run(() => RemoveDuplicates(arr)); // Видалення дублікатів
        Task<int[]> task2 = task1.ContinueWith(t => SortArray(t.Result)); // Сортування масиву
        Task<int> task3 = task2.ContinueWith(t => BinarySearch(t.Result, 5)); // Бінарний пошук значення

        // Очікування завершення всіх тасків
        Task.WaitAll(task1, task2, task3);

        // Отримання результатів
        int[] result1 = task1.Result;
        int[] result2 = task2.Result;
        int result3 = task3.Result;

        // Виведення результатів
        Console.WriteLine("Початковий масив: " + string.Join(", ", arr));
        Console.WriteLine("Масив без дублікатів: " + string.Join(", ", result1));
        Console.WriteLine("Відсортований масив: " + string.Join(", ", result2));
        Console.WriteLine("Індекс числа 5 у відсортованому масиві: " + result3);
    }

    // Видалення дублікатів
    static int[] RemoveDuplicates(int[] arr)
    {
        return arr.Distinct().ToArray();
    }

    // Сортування масиву
    static int[] SortArray(int[] arr)
    {
        Array.Sort(arr);
        return arr;
    }

    // Бінарний пошук значення
    static int BinarySearch(int[] arr, int value)
    {
        return Array.BinarySearch(arr, value);
    }
}