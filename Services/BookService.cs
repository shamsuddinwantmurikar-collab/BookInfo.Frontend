using BookInfo.Frontend.Models;
using System.Net.Http.Headers;

namespace BookInfo.Frontend.Services
{
    public class BookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Book>> GetBooksAsync(string token)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // Will use the BaseAddress set in Program.cs
            var result = await _http.GetFromJsonAsync<List<Book>>("api/books");
            return result ?? new List<Book>();
        }
    }
}
