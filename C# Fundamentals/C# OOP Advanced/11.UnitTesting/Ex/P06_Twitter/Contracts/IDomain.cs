namespace P06_Twitter.Contracts
{
    public interface IDomain
    {
        void ProcessMessage(string message);
    }
}