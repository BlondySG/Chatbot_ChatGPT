using Microsoft.Extensions.Options;
using System.Text;
using Newtonsoft.Json;
using chatbot.Data;

namespace chatbot.Services
{
    public class OpenAIService
    {
        public async Task<GPTResponse> Preguntar(string prompt)
        {
            using HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer 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");

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                },
            };
            using StringContent jsonBody = new(System.Text.Json.JsonSerializer.Serialize(requestBody),Encoding.Latin1,"application/json");

            using HttpResponseMessage response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", jsonBody);

            
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            GPTResponse deserializeResponse = JsonConvert.DeserializeObject<GPTResponse>(jsonResponse)!;
            return deserializeResponse;
        }
    }
}
