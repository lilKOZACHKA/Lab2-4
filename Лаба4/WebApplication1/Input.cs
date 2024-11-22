namespace SimpsonsIntegrationAPI
{
    public class IntegrationRequest
    {
        public double A { get; set; } // Нижний предел
        public double B { get; set; } // Верхний предел
        public int N { get; set; }    // Количество подотрезков (должно быть четным)
        public string Function { get; set; } = string.Empty; // Функция в виде строки, например "x^2"
    }

    public class IntegrationResponse
    {
        public double Result { get; set; } // Результат интегрирования
    }
}