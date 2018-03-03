public interface IBrowse
{
    string[] Urls { get; }
    string Browse(string url);
}
