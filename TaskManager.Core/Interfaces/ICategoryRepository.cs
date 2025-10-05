using TaskManager.Core.DTOs;

namespace TaskManager.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string userId);
        Task<CategoryDto?> GetCategoryByIdAsync(int id, string userId);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto, string userId);
        Task<CategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto, string userId);
        Task<bool> DeleteCategoryAsync(int id, string userId);
    }
}
