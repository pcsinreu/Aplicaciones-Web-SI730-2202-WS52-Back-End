using LearningCenter.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure;

public class CategoryRepository : ICategoryRepositoy
{
    private readonly LearningCentDBContext _learningCentDbContext;

    public CategoryRepository(LearningCentDBContext learningCentDbContext)
    {
        _learningCentDbContext = learningCentDbContext;
    }

    public async Task<List<Category>> getAll(string name)
    {
        //Conectar a la BD o APi , al file --> datos

        return await _learningCentDbContext.Categories
            .Include(category => category.Tutorials)
            .Where(category => category.IsActive && category.Name.Contains(name)) //listado &&= AND
            .ToListAsync();

        //Inner join
        /* var resul = from categorias in _learningCentDbContext.Categories 
                      join tutoriales in _learningCentDbContext.Tutorials  on categorias.Id equals  tutoriales.CategoryId
                      select tutoriales.Category */
    }

    public async Task<Category> getCategoryById(int id)
    {
        return await _learningCentDbContext.Categories
            .Include(category => category.Tutorials)
            .SingleOrDefaultAsync(categery => categery.Id == id); //LINQ
    }

    public async Task<bool> create(Category category)
    {
        /*Category category = new Category();
        category.Name = name;
        category.Description ="Description" + name;*/

    
                await _learningCentDbContext.Categories.AddAsync(category);
                await _learningCentDbContext.SaveChangesAsync();
                //await transacction.CommitAsync();


        return true;
    }

    public async Task<bool> Update(int id, Category category)
    {
        using (var transacction = await _learningCentDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingCategory = await _learningCentDbContext.Categories.FindAsync(id);

                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                existingCategory.DateUpdated = DateTime.Now;

                _learningCentDbContext.Categories.Update(existingCategory);
                await _learningCentDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _learningCentDbContext.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }

    public async Task<bool> Delete(int id)
    {

        var category = await _learningCentDbContext.Categories.FindAsync(id);

        //_learningCentDbContext.Categories.Remove(categorie);
        //_learningCentDbContext.SaveChanges();
        category.IsActive = false;
        category.DateUpdated = DateTime.Now;
        _learningCentDbContext.Categories.Update(category);
        await _learningCentDbContext.SaveChangesAsync();
        return true;
    }
}