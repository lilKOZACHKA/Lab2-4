using LabsShareLibrary;

namespace LabsShareLibraryTests
{
    [TestClass]
    public class Lab2Tests
    {
        [TestMethod]
        public void Solve_CalculatesSquareFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 2;
            Func<double, double> f = x => x * x;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(0.3333, result, 0.0001, "Интеграл f(x) = x^2 от 0 до 1 должен быть приближенно равен 0.3333");
        }

        [TestMethod]
        public void Solve_CalculatesSinFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = Math.PI;
            int n = 100;
            Func<double, double> f = Math.Sin;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(2, result, 0.01, "Интеграл f(x) = sin(x) от 0 до π должен быть приближенно равен 2");
        }

        [TestMethod]
        public void Solve_CalculatesExpFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 4;
            Func<double, double> f = Math.Exp;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(1.7183, result, 0.0001, "Интеграл f(x) = e^x от 0 до 1 должен быть приближенно равен 1.7183");
        }

        [TestMethod]
        public void Solve_ThrowsException_WhenNIsOdd()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 3;
            Func<double, double> f = x => x * x;

            lab2.Solve(f, a, b, n);
        }

        [TestMethod]
        public void Solve_CalculatesConstantFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 2;
            int n = 4;
            Func<double, double> f = x => 1;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(2, result, 0.0001, "Интеграл f(x) = 1 от 0 до 2 должен быть равен 2");
        }

        [TestMethod]
        public void Solve_CalculatesLinearFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 2;
            Func<double, double> f = x => 2 * x + 1;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(2, result, 0.0001, "Интеграл f(x) = 2x + 1 от 0 до 1 должен быть равен 2");
        }

        [TestMethod]
        public void Solve_CalculatesCubicFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 4;
            Func<double, double> f = x => x * x * x;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(0.25, result, 0.0001, "Интеграл f(x) = x^3 от 0 до 1 должен быть равен 0.25");
        }

        [TestMethod]
        public void Solve_CalculatesZeroFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 10;
            int n = 10;
            Func<double, double> f = x => 0;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(0, result, 0.0001, "Интеграл f(x) = 0 на любом интервале должен быть равен 0");
        }

        [TestMethod]
        public void Solve_CalculatesNegativeBounds_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = -1;
            double b = 1;
            int n = 4;
            Func<double, double> f = x => x * x;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(2 / 3.0, result, 0.0001, "Интеграл f(x) = x^2 от -1 до 1 должен быть равен 2/3");
        }

        [TestMethod]
        public void Solve_CalculatesWithLargeIntervals_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 100;
            int n = 50;
            Func<double, double> f = x => x;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(5000, result, 0.0001, "Интеграл f(x) = x от 0 до 100 должен быть равен 5000");
        }

        [TestMethod]
        public void Solve_CalculatesSinFunctionOverMultiplePeriods_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 2 * Math.PI;
            int n = 100;
            Func<double, double> f = Math.Sin;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(0, result, 0.0001, "Интеграл f(x) = sin(x) от 0 до 2π должен быть равен 0");
        }

        [TestMethod]
        public void Solve_CalculatesCosFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = Math.PI / 2;
            int n = 4;
            Func<double, double> f = Math.Cos;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(1, result, 0.0001, "Интеграл f(x) = cos(x) от 0 до π/2 должен быть равен 1");
        }

        [TestMethod]
        public void Solve_CalculatesExponentialDecayFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 6;
            Func<double, double> f = x => Math.Exp(-x);

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(1 - 1 / Math.E, result, 0.0001, "Интеграл f(x) = e^(-x) от 0 до 1 должен быть равен 1 - 1/e");
        }

        [TestMethod]
        public void Solve_CalculatesLogFunction_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 1;
            double b = 2;
            int n = 10;
            Func<double, double> f = Math.Log;

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(0.3863, result, 0.0001, "Интеграл f(x) = ln(x) от 1 до 2 должен быть приближенно равен 0.3863");
        }

        [TestMethod]
        public void Solve_CalculatesWithMinimalIntervals_CorrectResult()
        {
            Lab2 lab2 = new Lab2();
            double a = 0;
            double b = 1;
            int n = 2;
            Func<double, double> f = x => Math.Sqrt(x);

            double result = lab2.Solve(f, a, b, n);

            Assert.AreEqual(2 / 3.0, result, 0.0001, "Интеграл f(x) = sqrt(x) от 0 до 1 должен быть равен 2/3");
        }
    }
}