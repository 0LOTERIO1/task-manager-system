using System.Text.Json;
using TaskManager.Core.DTOs;

namespace TaskManager.Web.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto?> GetCategoryAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category);
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            try
            {
                Console.WriteLine("CategoryService: Fazendo requisição para api/categories");
                var response = await _httpClient.GetAsync("api/categories");
                Console.WriteLine($"CategoryService: Status Code: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CategoryService: JSON recebido: {json.Length} caracteres");
                    var result = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(json, _jsonOptions) ?? new List<CategoryDto>();
                    Console.WriteLine($"CategoryService: {result.Count()} categorias deserializadas");
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CategoryService: Erro na API: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CategoryService: Exceção ao buscar categorias: {ex.Message}");
            }
            return new List<CategoryDto>();
        }

        public async Task<CategoryDto?> GetCategoryAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CategoryDto>(json, _jsonOptions);
            }
            return null;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category)
        {
            try
            {
                Console.WriteLine($"CategoryService: Criando categoria - Nome: {category.Name}, Cor: {category.Color}");
                var json = JsonSerializer.Serialize(category, _jsonOptions);
                Console.WriteLine($"CategoryService: JSON enviado: {json}");
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("api/categories", content);
                Console.WriteLine($"CategoryService: Status Code da criação: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CategoryService: Resposta da criação: {responseJson}");
                    var result = JsonSerializer.Deserialize<CategoryDto>(responseJson, _jsonOptions) ?? new CategoryDto();
                    Console.WriteLine($"CategoryService: Categoria criada com sucesso - ID: {result.Id}");
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"CategoryService: Erro na criação: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CategoryService: Exceção ao criar categoria: {ex.Message}");
            }
            return new CategoryDto();
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category)
        {
            var json = JsonSerializer.Serialize(category, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"api/categories/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/categories/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
