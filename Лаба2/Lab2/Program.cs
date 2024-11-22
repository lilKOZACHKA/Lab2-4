using LabsShareLibrary;

namespace AlgorithmConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите нижний предел интегрирования (a):");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите верхний предел интегрирования (b):");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите количество интервалов (n, должно быть четным):");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Выберите функцию для интегрирования:");
            Console.WriteLine("1. f(x) = x^2");
            Console.WriteLine("2. f(x) = sin(x)");
            Console.WriteLine("3. f(x) = e^x");

            Func<double, double> f;
            switch (Console.ReadLine())
            {
                case "1":
                    f = x => x * x;
                    break;
                case "2":
                    f = Math.Sin;
                    break;
                case "3":
                    f = Math.Exp;
                    break;
                default:
                    Console.WriteLine("Выбрана неверная функция. По умолчанию f(x) = x^2");
                    f = x => x * x;
                    break;
            }

            Lab2 lab2 = new Lab2();
            try
            {
                double result = lab2.Solve(f, a, b, n);
                Console.WriteLine($"Результат приближенного интегрирования: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}