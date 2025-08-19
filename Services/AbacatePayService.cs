using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using teste_abacate_pay.Models;

namespace teste_abacate_pay.Services
{
    public class AbacatePayService : IAbacatePayService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        public AbacatePayService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _baseUrl = config["AbacatePay:BaseUrl"]!;
            _apiKey = config["AbacatePay:ApiKey"]!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<ResponseApi> CheckStatus(string id)
        {
            string url = $"{_baseUrl}pixQrCode/check?id={id}";
            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseApi>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ResponseApi> CreatePixQrCode(RequestApi requestApi)
        {
            string url = $"{_baseUrl}pixQrCode/create";
            var json = JsonSerializer.Serialize(requestApi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseApi>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ResponseApi> SimulatePayment(string id)
        {
            string url = $"{_baseUrl}pixQrCode/simulate-payment?id={id}";
            var response = await _httpClient.PostAsync(url, null);

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ResponseApi>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
