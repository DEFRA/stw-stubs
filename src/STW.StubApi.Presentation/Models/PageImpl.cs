namespace STW.StubApi.Presentation.Models;

public class PageImpl<T>
    where T : class
{
    public IList<T> Content { get; set; } = new List<T>();

    public int TotalElements => Content.Count;
}
