using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ElectricalLearning.Services.IServices;
using Microsoft.Extensions.Configuration;

namespace ElectricalLearning.Services.Implementations
{
    public class AIService : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AIService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetCircuitJsonFromDescriptionAsync(string description)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];
            var endpoint = _configuration["OpenAI:Endpoint"];
            var model = _configuration["OpenAI:Model"];

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "https://electricallearning.local");
            _httpClient.DefaultRequestHeaders.Add("X-Title", "ElectricalLearning");

            var requestBody = new
            {
                model = model,
                messages = new[]
                {
            new {
    role = "system",
    content = @"You are an assistant that takes a circuit description in text and returns a JSON object like this:
{
  ""components"": [
    { ""id"": ""bat1"", ""type"": ""battery"", ""position"": { ""x"": 0, ""y"": 0 }, ""rotation"": 0 }
  ],
  ""connections"": [
    { ""from"": ""bat1.positive"", ""to"": ""sw1.input"", ""bent"": false }
  ]
}
Use the component names from the following list ONLY: [ammeter, battery, bulb, buzzer, capacitor, diode, inductor, integratedcircuit, led, motor, relay, resistor, rheostat, switch, transistor, wire].
Assign `id` by adding a number (e.g., bat1, sw1).
Place components in a straight line horizontally (x = 0, 1, 2, ...), y = 0.
Create logical `connections` based on series or simple path."
},
            new { role = "user", content = description }
        }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenRouter Error {response.StatusCode}:\n{responseText}");
            }

            // ✅ Parse phần "content" từ message
            using var document = JsonDocument.Parse(responseText);
            var contentJson = document.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            // ✅ Parse lại JSON trả về từ AI để làm đẹp
            var circuitJson = JsonDocument.Parse(contentJson!);
            var formatted = JsonSerializer.Serialize(circuitJson, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return formatted;
        }
    }
}
