  using System;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class TwitchApiClient
  {
      private static readonly HttpClient client = new HttpClient();
      
      // Метод для отримання даних про трансляцію за логіном стрімера
     public static async Task GetStreamInfo(string login)
     {
         // Формуємо URL для звернення до мікросервісу Twitch API
         string url = $"https://api.twitch.tv/helix/streams?user_login={login}";
         
         // Додаємо обов'язкові заголовки для авторизації
         client.DefaultRequestHeaders.Add("Client-ID", "YOUR_APP_CLIENT_ID");
         client.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_ACCESS_TOKEN");

         try
         {
             // Відправляємо запит до сервера
             HttpResponseMessage response = await client.GetAsync(url);
             response.EnsureSuccessStatusCode();
             
             // Читаємо відповідь у форматі JSON
             string responseBody = await response.Content.ReadAsStringAsync();
             Console.WriteLine($"Дані від сервера Twitch: {responseBody}");
         }
         catch (HttpRequestException e)
         {
             Console.WriteLine($"Помилка з'єднання: {e.Message}");
         }
     }
 }