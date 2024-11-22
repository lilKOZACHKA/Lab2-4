using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class SimpsonApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;

    public SimpsonApiClient(HttpClient httpClient, string baseAddress)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
    }

    // Метод для отправки запроса на расчет интеграла
    public async Task<double> IntegrateAsync(string functionExpression, double a, double b, int n)
    {
        if (n <= 0 || n % 2 != 0)
            throw new ArgumentException("Количество разбиений должно быть положительным и чётным");

        var requestPayload = new
        {
            Function = functionExpression,
            LowerLimit = a,
            UpperLimit = b,
            Partitions = n
        };

        var jsonContent = JsonSerializer.Serialize(requestPayload);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        HttpResponseMessage response;
        try
        {
            response = await _httpClient.PostAsync($"{_baseAddress}/integrate/simpson", content);
        }
        catch (HttpRequestException ex)
        {
            throw new InvalidOperationException("Ошибка при обращении к API", ex);
        }

        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException($"Ошибка API: {response.StatusCode} - {response.ReasonPhrase}");

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<IntegrationResult>(responseContent);

        return result?.Result ?? throw new InvalidOperationException("Некорректный ответ API");
    }

    private class IntegrationResult
    {
        public double Result { get; set; }
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        // Настройка HttpClient
        using var httpClient = new HttpClient();
        var apiClient = new SimpsonApiClient(httpClient, "https://mockapi.example.com");

        try
        {
            double result = await apiClient.IntegrateAsync("x^2", 0, 1, 1000);
            Console.WriteLine($"Интеграл от x^2 на [0, 1]: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}