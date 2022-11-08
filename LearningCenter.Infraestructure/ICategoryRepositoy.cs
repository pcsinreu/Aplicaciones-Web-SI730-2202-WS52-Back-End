namespace LearningCenter.Infraestructure;

public interface ICategoryRepositoy
{
    Task<List<Category>> getAll(string name);

    Task<Category> getCategoryById(int id);
    Task<bool> create(Category category);
    Task<bool> Update(int id, Category category);

    Task<bool> Delete(int id);
}