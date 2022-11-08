namespace LearningCenter.Infraestructure;

public class Category : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    
    public int? Quantity { get; set; }

    public List<Tutorial>? Tutorials { get; set; }
}