namespace LearningCenter.Domain;

public class TestableDomain : ITestableDomain
{
    public int sum(int number1, int number2)
    {
        return number1 + number2  ;
    }

    public int multiply(int number1, int number2)
    {
        return number1 * number2  ;
    }   
    
    public int multiplyv3(int number1, int number2)
    {
        return number1 * number2 * 3 ;
    }
}