using System.Security;
using LearningCenter.Infraestructure;
using LearningCenter.Shared;

namespace LearningCenter.Domain;

public class CategoryDomain : ICategoryDomain
{
    private readonly ICategoryRepositoy _categoryRepositoy;

    public CategoryDomain(ICategoryRepositoy categoryRepositoy)
    {
        _categoryRepositoy = categoryRepositoy;
    }

    public async Task<List<Category>> getAll(string name)
    {
        //Logica del negocia
        //Conect 
        return await _categoryRepositoy.getAll(name);
    }

    public async Task<Category> getCategoryById(int id)
    {
        return await _categoryRepositoy.getCategoryById(id);
    }

    public async Task<bool> createCategory(Category category)
    {
        if (category.Quantity > Constans.MaxQuantityInventory)
        {
            throw new VerificationException("Quantity exceeds the limit ");
        }

        if (category.Description == category.Name)
        {
            throw new ArgumentException("Description and Name are equeals");
        }

        category.Name = category.Name.ReplaceBlankByUndercores();
        //category.Name = category.Name.Replace(" ", "_"); extension methods
        category.Description = category.Description.ReplaceBlankByUndercores();

        return await _categoryRepositoy.create(category);
    }
  
    public async Task<bool> updateCategory(int id, Category category)
    {
        if (category.Quantity > Constans.MaxQuantityInventory)
        {
            throw new VerificationException("Quantity exceeds the limit ");
        }
        return await _categoryRepositoy.Update(id, category);
    }

    public async Task<bool> deleteCategory(int id)
    {
        return await _categoryRepositoy.Delete(id);
    }
}