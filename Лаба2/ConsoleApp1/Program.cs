using System;

class SimpsonIntegral
{
    // Метод Симпсона для вычисления интеграла
    public static double Integrate(Func<double, double> f, double a, double b, int n)
    {
        // Проверка на четное число разбиений
        if (n % 2 != 0)
        {
            throw new ArgumentException("Количество разбиений n должно быть четным.");
        }

        double h = (b - a) / n; // Шаг разбиения
        double sum = f(a) + f(b);

        // Суммируем значения функции в узловых точках по формуле Симпсона
        for (int i = 1; i < n; i++)
        {
            double x = a + i * h;
            if (i % 2 == 0) // если четный индекс
            {
                sum += 2 * f(x);
            }
            else // если нечетный индекс
            {
                sum += 4 * f(x);
            }
        }

        return (h / 3) * sum;
    }

    static void Main()
    {
        // Пример: интеграл от функции f(x) = x^2 на интервале [0, 1]
        Func<double, double> f = x => x * x;
        double a = 0;
        double b = 1;
        int n = 100; // Количество разбиений (четное)

        double result = Integrate(f, a, b, n);
        Console.WriteLine($"Приближенное значение интеграла: {result}");
    }
}