using LearningCenter.Domain;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Sum_ReturmSum()
    {
        //AAA
        //Arange
        int number1 = 10;
        int number2 = 20;
        int expectedValue = 30; 
        var testableDomain = new TestableDomain();

        //Act
        var returnedValue = testableDomain.sum(number1, number2);

        //Assert
        Assert.Equal(expectedValue,returnedValue );
        //Assert.That(result, Is.EqualTo(expected));
    }    
    
    [Theory] 
    [InlineData(1,1,1)]
    [InlineData(2,2,4)]
    [InlineData(3,3,9)]
    public void Mul_ReturmMul(int number1,int number2,int expectedValue)
    {
        //AAA
        //Arange
        //int number1 = 1;
        //int number2 = 1;
        //int expectedValue = 1; 
        var testableDomain = new TestableDomain();

        //Act
        var returnedValue = testableDomain.multiply(number1, number2);

        //Assert
        //Assert.Equal(expectedValue,returnedValue );
        //Assert.That(result, Is.EqualTo(expected));
    }
}