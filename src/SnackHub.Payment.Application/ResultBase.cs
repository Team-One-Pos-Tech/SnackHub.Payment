namespace SnackHub.Payment.Application;

public class ResultBase<TOutput> where TOutput : class
{
    public bool Success { get; set; }
    public List<string> Errors { get; set; } = Enumerable.Empty<string>().ToList();
    public required TOutput Data { get; set; }
}