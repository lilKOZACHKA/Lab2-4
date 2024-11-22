using NCalc;

namespace SimpsonsIntegrationAPI
{
    public static class SimpsonsSolver
    {
        public static double Solve(double a, double b, int n, Func<double, double> function)
        {
            if (n % 2 != 0)
                throw new ArgumentException("N must be even.");

            double h = (b - a) / n;
            double sum = function(a) + function(b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += (i % 2 == 0 ? 2 : 4) * function(x);
            }

            return (h / 3) * sum;
        }

        public static Func<double, double> ParseFunction(string function)
        {
            return x =>
            {
                // Создание выражения с помощью NCalc
                var expression = new Expression(function);

                // Установка параметра x
                expression.Parameters["x"] = x;

                // Вычисление результата
                return Convert.ToDouble(expression.Evaluate());
            };
        }
    }
}
