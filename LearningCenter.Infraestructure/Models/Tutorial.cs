namespace LearningCenter.Infraestructure;

public class Tutorial : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }

    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}