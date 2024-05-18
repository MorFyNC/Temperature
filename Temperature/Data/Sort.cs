namespace Temperature.Data;

public class Sort(string title, Func<List<Weather>, List<Weather>> func)
{
    public string Title { get; set; } = title;
    public Func<List<Weather>, List<Weather>> SortingFunc { get; set; } = func;
}