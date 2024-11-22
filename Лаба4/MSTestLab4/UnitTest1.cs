
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace WebApplication1
{
    [TestClass]
    public class ApiUnitTests
    {
        private static WebApplicationFactory<Program> _factory;
        private static HttpClient _client;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task Test_1()
        {
            // �������� ����������� �������
            var requestBody = new
            {
                a = 0,
                b = 1,
                n = 6,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(result.Contains("result"));
        }

        [TestMethod]
        public async Task Test_2()
        {
            // �������� �� ���������� �������
            var requestBody = new
            {
                a = 0,
                b = 1,
                n = 6,
                function = "invalid_function(x)"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(result.Contains("error"));
        }

        [TestMethod]
        public async Task Test_3()
        {
            // �������� � ������� ������ ����������
            var requestBody = new
            {
                a = 0,
                b = 1,
                n = 2,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_4()
        {
            // �������� � ������������� ������ ����������
            var requestBody = new
            {
                a = 0,
                b = 1,
                n = -2,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_5()
        {
            // �������� �� ������������ ������� ��������������
            var requestBody = new
            {
                a = 1,
                b = 2,
                n = 6,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_6()
        {
            // �������� � ������� ������ ����������
            var requestBody = new
            {
                a = 0,
                b = 1,
                n = 1000000,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(result.Contains("result"));
        }

        [TestMethod]
        public async Task Test_7()
        {
            // �������� � ������ ��������
            var requestBody = new
            {
                a = 0,
                b = 1,
                n = 6,
                function = ""
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_8()
        {
            // �������� ������������� ������� ���� �������
            var content = new StringContent("invalid body", Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_9()
        {
            // �������� � �������� ��������� ��������������
            var requestBody = new
            {
                a = 0,
                b = 1000,
                n = 6,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(result.Contains("result"));
        }

        [TestMethod]
        public async Task Test_10()
        {
            // �������� � �������� ���������
            var requestBody = new
            {
                a = 0.5,
                b = 2.5,
                n = 6,
                function = "x^2"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Integration/calculate", content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(result.Contains("result"));
        }
    }
}