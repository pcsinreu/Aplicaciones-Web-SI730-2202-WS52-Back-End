using LearningCenter.Infraestructure;

namespace LearningCenter.Domain;

public interface ICategoryDomain
{
    Task<List<Category>> getAll(string name);
    Task<Category> getCategoryById(int id);
    Task<bool> createCategory(Category category);
    Task<bool> updateCategory(int id, Category category);
    Task<bool> deleteCategory(int id);
}