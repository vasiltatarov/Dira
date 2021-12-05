namespace Dira.ViewModels.Home;

public class IndexViewModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public IEnumerable<CategoryModelDto> Categories { get; set; }
}
