using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.DTOs;
using TaskManager.Core.Interfaces;
using TaskManager.Core.Entities;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            // Para demonstração, usando um userId fixo
            // Em uma aplicação real, você obteria isso do token JWT
            var userId = "user-123";
            
            var tasks = await _taskRepository.GetAllTasksAsync(userId);
            return Ok(tasks);
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            var userId = "user-123";
            var task = await _taskRepository.GetTaskByIdAsync(id, userId);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            try
            {
                Console.WriteLine($"API: Recebendo criação de tarefa - Título: {createTaskDto.Title}, Prioridade: {createTaskDto.Priority}");
                
                if (string.IsNullOrWhiteSpace(createTaskDto.Title))
                {
                    Console.WriteLine("API: Erro - Título é obrigatório");
                    return BadRequest("Título é obrigatório");
                }

                var userId = "user-123";
                var task = await _taskRepository.CreateTaskAsync(createTaskDto, userId);
                Console.WriteLine($"API: Tarefa criada com sucesso - ID: {task.Id}");
                return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API: Erro ao criar tarefa: {ex.Message}");
                return BadRequest($"Erro ao criar tarefa: {ex.Message}");
            }
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto updateTaskDto)
        {
            var userId = "user-123";
            var task = await _taskRepository.UpdateTaskAsync(id, updateTaskDto, userId);

            if (task == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = "user-123";
            var result = await _taskRepository.DeleteTaskAsync(id, userId);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/tasks/category/5
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByCategory(int categoryId)
        {
            var userId = "user-123";
            var tasks = await _taskRepository.GetTasksByCategoryAsync(categoryId, userId);
            return Ok(tasks);
        }

        // GET: api/tasks/completed
        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetCompletedTasks()
        {
            var userId = "user-123";
            var tasks = await _taskRepository.GetCompletedTasksAsync(userId);
            return Ok(tasks);
        }

        // GET: api/tasks/pending
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetPendingTasks()
        {
            var userId = "user-123";
            var tasks = await _taskRepository.GetPendingTasksAsync(userId);
            return Ok(tasks);
        }

        // GET: api/tasks/priority/{priority}
        [HttpGet("priority/{priority}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByPriority(int priority)
        {
            var userId = "user-123";
            var tasks = await _taskRepository.GetTasksByPriorityAsync((TaskPriority)priority, userId);
            return Ok(tasks);
        }
    }
}
