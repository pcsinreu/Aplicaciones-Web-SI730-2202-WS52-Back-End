namespace LearningCenter.Shared;

public static class Extensions
{
    public static string ReplaceBlankByUndercores(this string str)
    {
        return str.Replace(" ", "_");
    }   
    public static string ReplaceUndercoresByBlank(this string str)
    {
        return str.Replace("_", " ");
    }
}