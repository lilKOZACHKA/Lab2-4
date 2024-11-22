namespace LabsShareLibrary
{
    public class Lab2
    {
        public double Solve(Func<double, double> f, double a, double b, int n)
        {
            if (n % 2 != 0)
                throw new ArgumentException("Количество интервалов (n) должно быть четным.");

            double h = (b - a) / n;
            double sum = f(a) + f(b);

            // Считаем значения для нечетных индексове
            for (int i = 1; i < n; i += 2)
            {
                sum += 4 * f(a + i * h);
            }

            // Считаем значения для четных индексов
            for (int i = 2; i < n - 1; i += 2)
            {
                sum += 2 * f(a + i * h);
            }

            return (h / 3) * sum;
        }
    }
}