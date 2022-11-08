using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using Moq;

namespace TestProject1;

public class CategoryDomainUnitTest
{
    [Fact]
    public void CreateCategory_ReturnTrue()
    {
        //AAA
        //Arrange
        
        //ICategoryRepositoy categoryRepositoy = new ICategoryRepositoy()

        var categoryRepositoy = new Mock<ICategoryRepositoy>();
        categoryRepositoy.Setup(categoryRepositoy => categoryRepositoy.create(It.IsAny<Category>()))
            .Returns(Task.FromResult(true));

        var expectedValue = Task.FromResult(true);
        var category = new Category()
        {
            Name = "Name fake",
            Description = "Description fake",
            Quantity = 50
        };

        var categoryDomain = new CategoryDomain(categoryRepositoy.Object);
    
        
        //Act
        var result=  categoryDomain.createCategory(category);

        //Assert
        //Assert.Equal(expectedValue, result);
        Assert.True(result.Result);
    }
}