using TaskManager.Core.DTOs;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync(string userId);
        Task<TaskDto?> GetTaskByIdAsync(int id, string userId);
        Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto, string userId);
        Task<TaskDto?> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto, string userId);
        Task<bool> DeleteTaskAsync(int id, string userId);
        Task<IEnumerable<TaskDto>> GetTasksByCategoryAsync(int categoryId, string userId);
        Task<IEnumerable<TaskDto>> GetCompletedTasksAsync(string userId);
        Task<IEnumerable<TaskDto>> GetPendingTasksAsync(string userId);
        Task<IEnumerable<TaskDto>> GetTasksByPriorityAsync(TaskPriority priority, string userId);
    }
}
