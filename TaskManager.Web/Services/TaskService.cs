using System.Text.Json;
using TaskManager.Core.DTOs;

namespace TaskManager.Web.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<TaskDto?> GetTaskAsync(int id);
        Task<TaskDto> CreateTaskAsync(CreateTaskDto task);
        Task<bool> UpdateTaskAsync(int id, UpdateTaskDto task);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<TaskDto>> GetTasksByCategoryAsync(int categoryId);
        Task<IEnumerable<TaskDto>> GetCompletedTasksAsync();
        Task<IEnumerable<TaskDto>> GetPendingTasksAsync();
        Task<IEnumerable<TaskDto>> GetTasksByPriorityAsync(int priority);
    }

    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            try
            {
                Console.WriteLine("TaskService: Fazendo requisição para api/tasks");
                var response = await _httpClient.GetAsync("api/tasks");
                Console.WriteLine($"TaskService: Status Code: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TaskService: JSON recebido: {json.Length} caracteres");
                    var result = JsonSerializer.Deserialize<IEnumerable<TaskDto>>(json, _jsonOptions) ?? new List<TaskDto>();
                    Console.WriteLine($"TaskService: {result.Count()} tarefas deserializadas");
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TaskService: Erro na API: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TaskService: Exceção ao buscar tarefas: {ex.Message}");
            }
            return new List<TaskDto>();
        }

        public async Task<TaskDto?> GetTaskAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/tasks/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TaskDto>(json, _jsonOptions);
            }
            return null;
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto task)
        {
            try
            {
                Console.WriteLine($"TaskService: Criando tarefa - Título: {task.Title}, Prioridade: {task.Priority}");
                var json = JsonSerializer.Serialize(task, _jsonOptions);
                Console.WriteLine($"TaskService: JSON enviado: {json}");
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("api/tasks", content);
                Console.WriteLine($"TaskService: Status Code da criação: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TaskService: Resposta da criação: {responseJson}");
                    var result = JsonSerializer.Deserialize<TaskDto>(responseJson, _jsonOptions) ?? new TaskDto();
                    Console.WriteLine($"TaskService: Tarefa criada com sucesso - ID: {result.Id}");
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"TaskService: Erro na criação: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TaskService: Exceção ao criar tarefa: {ex.Message}");
            }
            return new TaskDto();
        }

        public async Task<bool> UpdateTaskAsync(int id, UpdateTaskDto task)
        {
            var json = JsonSerializer.Serialize(task, _jsonOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PutAsync($"api/tasks/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/tasks/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksByCategoryAsync(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/tasks/category/{categoryId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<TaskDto>>(json, _jsonOptions) ?? new List<TaskDto>();
            }
            return new List<TaskDto>();
        }

        public async Task<IEnumerable<TaskDto>> GetCompletedTasksAsync()
        {
            var response = await _httpClient.GetAsync("api/tasks/completed");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<TaskDto>>(json, _jsonOptions) ?? new List<TaskDto>();
            }
            return new List<TaskDto>();
        }

        public async Task<IEnumerable<TaskDto>> GetPendingTasksAsync()
        {
            var response = await _httpClient.GetAsync("api/tasks/pending");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<TaskDto>>(json, _jsonOptions) ?? new List<TaskDto>();
            }
            return new List<TaskDto>();
        }

        public async Task<IEnumerable<TaskDto>> GetTasksByPriorityAsync(int priority)
        {
            var response = await _httpClient.GetAsync($"api/tasks/priority/{priority}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<TaskDto>>(json, _jsonOptions) ?? new List<TaskDto>();
            }
            return new List<TaskDto>();
        }
    }
}
