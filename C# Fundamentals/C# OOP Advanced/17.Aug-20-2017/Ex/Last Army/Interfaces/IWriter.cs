public interface IWriter
{
    void WriteLine(string output);

    void StoreMessage(string message);

    string StoredMessage { get; }
}
